using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;


public class PlayerJumpModifiers : MonoBehaviour
{
    Rigidbody2D rb;
    InputAction jumpAction;

    public float gravityModifier = 2.5f;
    [SerializeField] private float LowJumpMultiplier = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (gravityModifier - 1) * Time.deltaTime;
        }else if (rb.linearVelocity.y > 0 && !jumpAction.IsInProgress())
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (LowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
