using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody TargetRigidbody { get; set; }
    private GameManager GameManager { get; set; }

    private float MinSpeed { get; set; } = 12;
    private float MaxSpeed { get; set; } = 16;
    private float MaxTorque { get; set; } = 10;
    private float XRange { get; set; } = 4;
    private float YSpawnPosition { get; set; } = -2;

    public ParticleSystem explotionParticle;

    public int pointValue;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        TargetRigidbody = GetComponent<Rigidbody>();
        TargetRigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        TargetRigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPosition();
    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void DestroyTarget()
    {
        if (!GameManager.IsGameActive) return;
        Destroy(gameObject);
        Instantiate(explotionParticle, transform.position, explotionParticle.transform.rotation);
        GameManager.UpdateScore(scoreToAdd: pointValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            GameManager.GameOver();
        }
    }

    private Vector3 RandomForce() => Vector3.up * Random.Range(MinSpeed, MaxSpeed);
    private Vector3 RandomSpawnPosition() => new(Random.Range(-XRange, XRange), YSpawnPosition);
    private float RandomTorque() => Random.Range(-MaxTorque, MaxTorque);
}
