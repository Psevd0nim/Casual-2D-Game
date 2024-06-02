using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeTemplate
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private bool canMove;
        [SerializeField] private GameplayUI gameplayUI;
        private Rigidbody2D rb;
        private float speed = 10;

        private Vector2 startTouchPosition;
        private Vector2 endTouchPosition;

        private void Start()
        {
            gameplayUI = GameObject.Find("Gameplay").GetComponent<GameplayUI>();
            rb = GetComponent<Rigidbody2D>();
            canMove = true;
        }

        private void Update()
        {
            if (canMove)
            {
                WASDAndArrowsMove();
                SwipeMove();
            }
        }

        private void SwipeMove()
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startTouchPosition = Input.GetTouch(0).position;
            }
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                endTouchPosition = Input.GetTouch(0).position;
                Vector2 inputVector = endTouchPosition - startTouchPosition;
                if (Mathf.Abs(inputVector.x) > Mathf.Abs(inputVector.y))
                {
                    if (inputVector.x > 0)
                    {
                        rb.velocity = Vector2.right * speed;
                        DoSomething();
                    }
                    else
                    {
                        rb.velocity = Vector2.left * speed;
                        DoSomething();
                    }
                }
                else
                {
                    if (inputVector.y > 0)
                    {
                        rb.velocity = Vector2.up * speed;
                        DoSomething();
                    }
                    else
                    {
                        rb.velocity = Vector2.down * speed;
                        DoSomething();
                    }
                }
            }
        }

        void DoSomething()
        {
            canMove = false;
            AudioManager.instance.PlayFirstSound();
        }

        private void WASDAndArrowsMove()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                rb.velocity = Vector2.up * speed;
                DoSomething();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                rb.velocity = Vector2.down * speed;
                DoSomething();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                rb.velocity = Vector2.left * speed;
                DoSomething();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                rb.velocity = Vector2.right * speed;
                DoSomething();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            canMove = true;
            var xValue = Math.Round(gameObject.transform.position.x, 1);
            var yValue = Math.Round(gameObject.transform.position.y, 1);
            gameObject.transform.position = new Vector2((float)xValue, (float)yValue);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Win"))
            {
                gameplayUI.LevelWin();
                Destroy(gameObject, 3);
            }
        }
    }
}