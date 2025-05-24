using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;      // Швидкість руху
    public float jumpForce = 10f;     // Сила стрибка

    private Rigidbody2D rb;
    private bool isGrounded;

    // Це можна призначити через інспектор або знайти автоматично
    public Transform groundCheck;     // Точка перевірки дотику з землею
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;     // Шар, який позначає землю

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Рух вліво/вправо
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Перевірка, чи гравець на землі
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Стрибок при натисканні пробілу, якщо на землі
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    // Для візуалізації перевірки в інспекторі
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
