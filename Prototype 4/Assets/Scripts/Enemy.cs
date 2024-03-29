using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float lowBorder;

    private Rigidbody EnemyRigidbody { get; set; }
    private Transform PlayersTransform { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        EnemyRigidbody = GetComponent<Rigidbody>();
        PlayersTransform = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyRigidbody.AddForce((PlayersTransform.position - transform.position).normalized * speed);

        if (transform.position.y < lowBorder)
        {
            Destroy(gameObject);
        }
    }
}
