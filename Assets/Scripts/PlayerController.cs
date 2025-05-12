using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 12f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public float slowTimeScale = 0.3f; // how slow time becomes
    public KeyCode timeSlowKey = KeyCode.LeftShift;

    [Header("Time Energy")]
    public float maxTimeEnergy = 100f;
    public float currentTimeEnergy;
    public float drainRate = 20f; // Energy per second drained
    public float rechargeRate = 10f; // Energy per second regained
    public Slider timeEnergySlider;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1f; // Ensure normal time at start
        Time.fixedDeltaTime = 0.02f; // Reset physics timestep

        currentTimeEnergy = maxTimeEnergy;
    }

    void HandleTimeSlow()
    {
        bool holdingKey = Input.GetKey(timeSlowKey);

        if (holdingKey && currentTimeEnergy > 0f)
        {
            Time.timeScale = slowTimeScale;
            Time.fixedDeltaTime = 0.02f * Time.timeScale; // Make physics match
            currentTimeEnergy -= drainRate * Time.unscaledDeltaTime;
        }
        else
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f;
            if (currentTimeEnergy < maxTimeEnergy)
                currentTimeEnergy += rechargeRate * Time.unscaledDeltaTime;
        }

        // Clamp to keep energy in bounds
        currentTimeEnergy = Mathf.Clamp(currentTimeEnergy, 0f, maxTimeEnergy);
    }

    void Update()
    {
        HandleTimeSlow();

        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Check for jump
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        if (timeEnergySlider != null)
            timeEnergySlider.value = currentTimeEnergy;
    }
}
