using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScrips : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float speed = 4.0f;
    Rigidbody2D rb;

    public bool turnedLeft = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
        turnedLeft = false;
        if (horizontal > 0)
        {
            GetComponent<Animator>().Play("Right");
        }
        else if (horizontal < 0)
        {
            GetComponent<Animator>().Play("Left");
            turnedLeft = true;
        }
        else if (vertical > 0)
        {
            GetComponent<Animator>().Play("Up");
        }
        else if (vertical < 0)
        {
            GetComponent<Animator>().Play("Down");
        }
    }
}
