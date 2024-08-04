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
            ObjectRb.AddRelativeForce(toPlayerPosition.normalized * speed);
        }

        //for chicken
        if (!toPlayer && toPlayerPosition.magnitude <= visibleRange)
        {
            toPlayerPosition = -toPlayerPosition.normalized;
            ObjectRb.AddRelativeForce(toPlayerPosition * speed);
        }
        if (!toPlayer && toPlayerPosition.magnitude > visibleRange)
        {
            ObjectRb.AddRelativeForce((PlaneTransform.position - transform.position).normalized * speed);
        }

        ConstrainPosition(bound);
    }
}
