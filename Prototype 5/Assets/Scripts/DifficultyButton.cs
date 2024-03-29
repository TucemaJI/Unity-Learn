using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button Button { get; set; }
    private GameManager GameManager { get; set; }

    public byte difficulty;
    // Start is called before the first frame update
    void Start()
    {
        Button = GetComponent<Button>();
        Button.onClick.AddListener(SetDifficulty);

        GameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetDifficulty(){
        GameManager.StartGame(difficulty);
    }
}
