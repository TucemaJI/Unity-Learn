using Unity.VisualScripting;
using UnityEngine;

public class FlyToEnemy : MonoBehaviour
{
    internal Transform Target { private get; set; }

    public float boltStrength;
    public float boltSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Target.IsDestroyed())
        {
            Destroy(gameObject);
            return;
        }

        if (Target is not null && !Target.IsDestroyed() && Target.transform.position.y > 0)
        {
            transform.position +=
                (Target.position - transform.position).normalized * boltSpeed * Time.deltaTime;
            transform.LookAt(Target);
            transform.Rotate(Vector3.right, 90);
        }
    }

    internal void Fire(Transform newTarget)
    {
        Target = newTarget;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameObject enemyRigidbody = collision.gameObject;
            Vector3 awayFromBolt = enemyRigidbody.transform.position - transform.position;

            enemyRigidbody.GetComponent<Rigidbody>()
                .AddForce(awayFromBolt * boltStrength, ForceMode.Impulse);

            Destroy(gameObject);
        }
    }
}
