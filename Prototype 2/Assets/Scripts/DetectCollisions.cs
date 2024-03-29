using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private byte piecesToFeed = 1;
    private GameOverScript GameOverManager { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        GameOverManager = GameObject.Find("GameManager").GetComponent<GameOverScript>();
        GameOverManager.LogPlayerLifes();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameOverManager.MinusPlayerLife();
            Destroy(gameObject);
            return;
        }
        
        gameObject.GetComponent<AnimalHunger>().FeedAnimal(piecesToFeed);
        other.gameObject.SetActive(false);
    }
}
