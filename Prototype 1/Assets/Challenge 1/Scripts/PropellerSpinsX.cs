using UnityEngine;

public class PropellerSpinsX : MonoBehaviour
{
    private Vector3 Spin { get; set; } = new Vector3(0, 0, 10);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Spin);
    }
}
