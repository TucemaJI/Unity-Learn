using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed;
    public bool x;
    public bool y;
    public bool z;

    private float X { get { return BoolToFloat(x); } }
    private float Y { get { return BoolToFloat(y); } }
    private float Z { get { return BoolToFloat(z); } }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(X, Y, Z);
    }

    private float BoolToFloat(bool b) => b ? speed * Time.deltaTime : byte.MinValue;

}
