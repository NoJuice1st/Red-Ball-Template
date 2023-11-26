using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    #region Variables

    public Rigidbody2D rb;
    public float moveForce;
    public float jumpSpeed;
    public bool isGrounded;
    public GameObject deadPieces;
    public GameObject gameManager;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(gameManager);
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Death();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.Contains("Flag"))
        {
            GameManager.instance.Win();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump") && isGrounded)
        {
            rb.velocity += Vector2.up * jumpSpeed;
        }


        float hor = Input.GetAxis("Horizontal");
        
        rb.AddForce(new Vector2(hor,0) * moveForce * Time.deltaTime);
    }

    private void Death()
    {
        Destroy(gameObject);
        for (int i = 0; i < 5; i++)
        {
            var size = Random.Range(0.1f, 0.5f);
            var offset = transform.position + Random.insideUnitSphere / 2;
            var piece = Instantiate(deadPieces, offset, transform.rotation);
            piece.GetComponent<Rigidbody2D>().velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
            var color = piece.GetComponent<SpriteRenderer>().color;
            color.r = Random.Range(0.5f, 1.5f);
            piece.GetComponent<SpriteRenderer>().color = color;
            piece.transform.localScale = new Vector3(size, size, size);
        }

        GameManager.instance.Lose();
    }
}
