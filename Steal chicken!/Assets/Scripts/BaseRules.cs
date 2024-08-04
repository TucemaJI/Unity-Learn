using UnityEngine;

public class BaseRules : MonoBehaviour
{
    internal void ConstrainPosition(float bound = 24f)
    {
        if (transform.position.z < -bound)
        {
            transform.position = new UnityEngine.Vector3(transform.position.x, transform.position.y, -bound);
        }

        if (transform.position.z > bound)
        {
            transform.position = new UnityEngine.Vector3(transform.position.x, transform.position.y, bound);
        }

        if (transform.position.x < -bound)
        {
            transform.position = new UnityEngine.Vector3(-bound, transform.position.y, transform.position.z);
        }

        if (transform.position.x > bound)
        {
            transform.position = new UnityEngine.Vector3(bound, transform.position.y, transform.position.z);
        }
    }
}
