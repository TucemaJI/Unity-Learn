using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;

    private Vector3 SpawnPos { get; set; } = new(25, 0, 0);
    private float StartDelay { get; set; } = 2;
    private float RepeatRate { get; set; } = 2;
    private PlayerController PlayerControllerScript { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", StartDelay, RepeatRate);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacle()
    {
        if (!PlayerControllerScript.GameOver)
        {
            Instantiate(obstaclePrefab, SpawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
