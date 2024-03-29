using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 StartPos { get; set; }
    private float RepeatWidth { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
        RepeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < StartPos.x - RepeatWidth)
        {
            transform.position = StartPos;
        }
    }
}
