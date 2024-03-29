using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float SpawnRate { get; set; } = 1f;
    private int Score { get; set; } = 0;

    internal bool IsGameActive { get; private set; } = true;

    public List<GameObject> targets;
    public TextMeshProUGUI liveText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    public GameObject pauseScreen;
    public byte liveScore = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Pause)) { ChangePause(); }
    }

    private IEnumerator<WaitForSeconds> SpawnTarget()
    {
        while (IsGameActive)
        {
            yield return new WaitForSeconds(SpawnRate);
            Instantiate(targets[Random.Range(0, targets.Count)]);
        }
    }

    private void ChangePause(){
        pauseScreen.SetActive(!pauseScreen.activeSelf);
        Time.timeScale = pauseScreen.activeSelf ? 0 : 1;
    }

    private void UpdateLives()=> liveText.text = $"Lives: {liveScore}"; 
    internal void UpdateScore(int scoreToAdd = 0) => scoreText.text = $"Score: {Score += scoreToAdd}";
    public void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    internal void GameOver()
    {
        if (--liveScore <= byte.MinValue)
        {
            UpdateLives();
            IsGameActive = false;
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
        if (IsGameActive) { UpdateLives(); }
    }

    internal void StartGame(byte difficulty)
    {
        SpawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
        UpdateScore();
        UpdateLives();

        titleScreen.SetActive(!IsGameActive);
    }
}
