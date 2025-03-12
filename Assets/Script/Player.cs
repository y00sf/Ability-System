using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float m_jumpForce = 5f;
    [SerializeField] private float m_speed = 5f;
    [SerializeField] private float m_range = 0.1f;
    [SerializeField] private LayerMask m_groundLayer;
    private Rigidbody2D m_rb;
    public bool m_isGrounded;
    
    public bool canDoubleJump;
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
        m_isGrounded = Physics2D.Raycast(transform.position, Vector2.down, m_range, m_groundLayer);
    }
    
    void Movement()
    {
        HorizontalMovement();
        Jump();
    }
    void HorizontalMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontal * m_speed, 0, 0) * Time.deltaTime;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (m_isGrounded)
            {
                m_rb.AddForce(Vector2.up * m_jumpForce, ForceMode2D.Impulse);
            }
            else if (canDoubleJump && !m_isGrounded)
            {
                m_rb.AddForce(Vector2.up * m_jumpForce, ForceMode2D.Impulse);
                canDoubleJump = false;
            }
        }
    }
}
