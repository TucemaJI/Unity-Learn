using UnityEngine;

public class MoveFromToPlayer : BaseRules
{
    [SerializeField]
    private bool toPlayer;

    [SerializeField]
    private float speed = 14f;

    [SerializeField]
    private float bound = 24f;

    [SerializeField]
    private float visibleRange = 12f;

    private Rigidbody ObjectRb { get; set; }
    private Transform PlayerTransform { get; set; }
    private Transform PlaneTransform { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        ObjectRb = GetComponent<Rigidbody>();
        PlayerTransform = GameObject.Find("Player").transform;
        PlaneTransform = GameObject.Find("Plane").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 toPlayerPosition = PlayerTransform.position - transform.position;

        if (toPlayer) //for owner
        {
            RotateLookAt(toPlayerPosition);
            ObjectRb.MovePosition(ObjectRb.position + toPlayerPosition.normalized * speed * Time.fixedDeltaTime);
        }

        //for chicken
        if (!toPlayer && toPlayerPosition.magnitude <= visibleRange)
        {
            RotateLookAt(-toPlayerPosition);
            ObjectRb.MovePosition(ObjectRb.position + -toPlayerPosition.normalized * speed * Time.fixedDeltaTime);
        }
        if (!toPlayer && toPlayerPosition.magnitude > visibleRange)
        {
            RotateLookAt(PlaneTransform.position - transform.position);
            ObjectRb.MovePosition(ObjectRb.position + (PlaneTransform.position - transform.position).normalized * speed * Time.fixedDeltaTime);
        }

        ConstrainPosition(bound);
    }

    private void RotateLookAt(Vector3 position)
    {
        var targetRotation = Quaternion.LookRotation(position.normalized);
        targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360f * Time.fixedDeltaTime);
        ObjectRb.MoveRotation(targetRotation);
    }
}
