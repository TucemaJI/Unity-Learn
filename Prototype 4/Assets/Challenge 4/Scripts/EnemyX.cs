using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed;

    private Rigidbody EnemyRb { get; set; }
    private Vector3 PlayerGoalPosition { get; set; }
    private SpawnManagerX GameSpawnManager { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        EnemyRb = GetComponent<Rigidbody>();
        PlayerGoalPosition = GameObject.Find("Player Goal").transform.position;
        GameSpawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX>();
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (PlayerGoalPosition - transform.position).normalized;
        EnemyRb.AddForce(lookDirection * speed * Time.deltaTime * GameSpawnManager.waveCount);
    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }

    }

}
