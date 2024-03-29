using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float Speed { get; set; } = 20;
    private float LeftBound { get; set; } = -15;
    private PlayerController PlayerControllerScript { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerControllerScript.GameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
        }
        if (transform.position.x < LeftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
