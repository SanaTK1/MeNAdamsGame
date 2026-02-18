using UnityEngine;
using System.Collections;

public class PlayerJumpModifiers : MonoBehaviour
{
    Rigidbody2D rb;

    public float gravityModifier = 2.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (gravityModifier - 1) * Time.deltaTime;
        }
    }
}
