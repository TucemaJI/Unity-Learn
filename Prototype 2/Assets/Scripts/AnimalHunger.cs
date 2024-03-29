using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalHunger : MonoBehaviour
{
    public Slider hungerSlider;
    public byte amountToBeFed;
    public float timeToDestroy = 0.1f;

    private byte CurrentFeedAmount { get; set; } = byte.MinValue;
    private GameOverScript GameOverManager { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        hungerSlider.maxValue = amountToBeFed;
        hungerSlider.value = CurrentFeedAmount;
        hungerSlider.fillRect.gameObject.SetActive(false);

        GameOverManager = GameObject.Find("GameManager").GetComponent<GameOverScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FeedAnimal(byte amount)
    {
        CurrentFeedAmount += amount;
        hungerSlider.fillRect.gameObject.SetActive(true);
        hungerSlider.value = CurrentFeedAmount;

        if (CurrentFeedAmount >= amountToBeFed)
        {
            GameOverManager.AddPlayerLife();
            Destroy(gameObject, timeToDestroy);
        }
    }
}
