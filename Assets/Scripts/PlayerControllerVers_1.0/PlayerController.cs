using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Collider2D col;
    private Rigidbody2D rb;
    private KeyCode tempKeyCode;
    private bool canMove = true;
    private float speed = 10;
    private float time = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (canMove)
        {
            if(time < 0.2f)
                Move(tempKeyCode);
            else if (WhatIsPressed())
                Move(tempKeyCode);
        }
        if (!canMove)
        {
            if (WhatIsPressed())
            {
                time = 0;
            }
        }
        time += Time.deltaTime;
    }

    private bool WhatIsPressed()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            tempKeyCode = KeyCode.RightArrow;
            return true;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            tempKeyCode = KeyCode.LeftArrow;
            return true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            tempKeyCode = KeyCode.UpArrow;
            return true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            tempKeyCode = KeyCode.DownArrow;
            return true;
        }
        return false;
    }
    private void Move(KeyCode keyCode)
    {
        if (keyCode == KeyCode.RightArrow)
        {
            rb.velocity = Vector2.right * speed;
            canMove = false;
        }
        if (keyCode == KeyCode.LeftArrow)
        {
            rb.velocity = Vector2.left * speed;
            canMove = false;
        }
        if (keyCode == KeyCode.UpArrow)
        {
            rb.velocity = Vector2.up * speed;
            canMove = false;
        }
        if (keyCode == KeyCode.DownArrow)
        {
            rb.velocity = Vector2.down * speed;
            canMove = false;
        }
    }

    /*private void Move()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.velocity = Vector2.right * 10;
            canMove = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.velocity = Vector2.left * 10;
            canMove = false;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = Vector2.up * 10;
            canMove = false;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb.velocity = Vector2.down * 10;
            canMove = false;
        }
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("CollisionCheck");
        rb.velocity = Vector2.zero;
        col.enabled = true;
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        col.enabled = false;
        canMove = true;
    }
}