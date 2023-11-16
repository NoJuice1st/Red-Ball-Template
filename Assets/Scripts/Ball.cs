using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float jumpSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * jumpSpeed;
        }

        float hor = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector2(hor,0) * speed);
    }
}
