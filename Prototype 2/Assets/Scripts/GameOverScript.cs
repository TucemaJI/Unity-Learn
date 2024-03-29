using Assets.Classes;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    private Lifes PlayerLifes = new();

    public void AddPlayerLife()
    {
        PlayerLifes.AddLive();
        LogPlayerLifes();
    }

    public void MinusPlayerLife()
    {
        PlayerLifes.MinusLive();
        LogPlayerLifes();

        if (PlayerLifes.GetLives() <= 0)
        {
            Debug.Log("Game Over");
        }
    }

    internal void LogPlayerLifes()
    {
        Debug.Log($"Lives: {PlayerLifes.GetLives()}");
    }
}
