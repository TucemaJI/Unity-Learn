using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private readonly string HorizontalAxis = "Horizontal";
    private readonly string VerticalAxis = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;

    private byte ForwardRange { get; set; } = 15;
    private sbyte BackRange { get; set; } = 0;
    private byte XRange { get; set; } = 15;
    private float Speed { get; set; } = 10f;

    // Update is called once per frame
    void Update()
    {
        // Check for left and right bounds
        if (transform.position.x < -XRange)
        {
            transform.position = new(-XRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > XRange)
        {
            transform.position = new(XRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < BackRange)
        {
            transform.position = new(transform.position.x, transform.position.y, BackRange);
        }

        if (transform.position.z > ForwardRange)
        {
            transform.position = new(transform.position.x, transform.position.y, ForwardRange);
        }

        // Player movement left to right
        horizontalInput = Input.GetAxis(HorizontalAxis);
        verticalInput = Input.GetAxis(VerticalAxis);
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * Speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * Speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // No longer necessary to Instantiate prefabs
            // Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

            // Get an object object from the pool
            GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
            if (pooledProjectile != null)
            {
                pooledProjectile.SetActive(true); // activate it
                pooledProjectile.transform.position = transform.position; // position it at player
            }
        }
    }
}
