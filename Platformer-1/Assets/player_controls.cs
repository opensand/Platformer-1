using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controls : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerSpeed = 5.0f;
    public float jump = 5.0f;
    public Rigidbody2D rb;
    bool jumpAvailable;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        transform.position = transform.position + playerInput.normalized * playerSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && jumpAvailable)
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            jumpAvailable = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Floor")
        {
            jumpAvailable = true;
        }
    }
}
