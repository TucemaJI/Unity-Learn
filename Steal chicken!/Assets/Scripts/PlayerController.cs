using UnityEngine;

public class PlayerController : BaseRules
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float bound;
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
        ConstrainPosition(bound);
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float mouseMove = Input.GetAxis("Mouse X");

        playerRb.MoveRotation(playerRb.rotation * UnityEngine.Quaternion.Euler(0, mouseMove, 0));
        
        playerRb.MovePosition(playerRb.position + playerRb.transform.TransformDirection(Vector3.right) * speed * horizontalInput * Time.fixedDeltaTime);
        playerRb.MovePosition(playerRb.position + playerRb.transform.TransformDirection(Vector3.forward) * speed * verticalInput * Time.fixedDeltaTime);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Chicken"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Owner"))
        {
            Debug.Log("Player has collided with Owner");
            Debug.Log("Game Over!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
        }
    }
}
