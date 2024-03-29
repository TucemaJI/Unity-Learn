using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private byte topLeftRightBound = 30;
    private float lowerBound = -10;
    private GameOverScript GameOverManager { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        GameOverManager = GameObject.Find("GameManager").GetComponent<GameOverScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topLeftRightBound)
        {
            gameObject.SetActive(false);
        }
        if (transform.position.z < lowerBound || transform.position.x > topLeftRightBound || transform.position.x < -topLeftRightBound)
        {
            Destroy(gameObject);
            GameOverManager.MinusPlayerLife();
        }
    }
}
