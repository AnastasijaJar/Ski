using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputAction move;
    [SerializeField] private float rotationSpeed = 30, moveSpeed = -10;
    [SerializeField] private bool isGrounded = true;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Vector3 pushbackForce;
    [SerializeField] private bool disabled= false;
    [SerializeField] private float disableTime = 0.7f;
    private float lastDisableTime;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        move = InputSystem.actions.FindAction("Player/Move");
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        Obstacle.OnPlayerHit += TakeDamage;
    }

    void TakeDamage()
    {
        disabled =  true;
        lastDisableTime = Time.timeSinceLevelLoad;
        //Re-enable controls after x seconds
        rb.AddForce(pushbackForce);
        Debug.Log("I GOT HIT!");
    }
    
    void FixedUpdate()
    {
        Debug.DrawLine(transform.position, transform.position - transform.up, Color.red);
        isGrounded = Physics.Linecast(transform.position, transform.position - transform.up,groundLayer);
        if (Time.timeSinceLevelLoad > lastDisableTime + disableTime)
            disabled = false;
        if (isGrounded && !disabled)
        {
            Vector2 moveVector = move.ReadValue<Vector2>();
            float slopeAngle = Mathf.Abs(transform.localEulerAngles.y - 180);
            float speedMultiplier = Mathf.Cos(Mathf.Deg2Rad * slopeAngle);
            rb.AddForce(transform.forward * moveSpeed * Time.fixedDeltaTime * speedMultiplier);
            transform.Rotate(0, moveVector.x * rotationSpeed * Time.fixedDeltaTime, 0);
           
        }
    }
}
