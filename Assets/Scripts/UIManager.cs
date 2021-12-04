using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private int score;


    [SerializeField] private List<GameObject> playerHearts;
    [SerializeField] private int currentHeart = 2;
    public static UIManager instance { get; private set; }

    void Start()
    {
        score = 0;
        instance = this;
    }

    public void AddScore(int count = 1)
    {
        score++;

        scoreText.text = $"Score: {score}";
    }

    public void DamageHealth()
    {
        if (currentHeart <= 2 && currentHeart >= 0)
        {
            playerHearts[currentHeart].SetActive(false);
            currentHeart--;
        }
    }

    public void Heal()
    {
        if (currentHeart + 1 <= 2 && currentHeart >= 0)
        {
            playerHearts[currentHeart + 1].SetActive(true);
            currentHeart++;
        }
    }
}
