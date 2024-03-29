using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    public Vector3 position = new(3, 4, 1);
    public float scale = 1.3f;
    public Color color = new(0.5f, 1.0f, 0.3f, 0.4f);

    public bool isTurnxAngle = true;
    public bool isTurnyAngle = false;
    public bool isTurnzAngle = false;

    private float XAngle { get { return isTurnxAngle ? 1.0f : byte.MinValue; } }
    private float YAngle { get { return isTurnyAngle ? 1.0f : byte.MinValue; } }
    private float ZAngle { get { return isTurnzAngle ? 1.0f : byte.MinValue; } }

    public float rotationSpeed = 1;

    void Start()
    {
        transform.position = position;
        transform.localScale = Vector3.one * scale;

        Renderer.material.color = color;
    }

    void Update()
    {
        if (transform.position != position)
        {
            transform.position = position;
        }

        if (transform.localScale != Vector3.one * scale)
        {
            transform.localScale = Vector3.one * scale;
        }

        if (Renderer.material.color != color)
        {
            Renderer.material.color = color;
        }

        transform.Rotate(XAngle * Time.deltaTime * rotationSpeed, YAngle * Time.deltaTime * rotationSpeed, ZAngle * Time.deltaTime * rotationSpeed);
    }
}
