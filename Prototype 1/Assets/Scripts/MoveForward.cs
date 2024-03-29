using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private byte speed = 10;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
