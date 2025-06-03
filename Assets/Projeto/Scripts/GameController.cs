using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public int score = 0;
    public Text scoreText; // UI para mostrar a pontuação

    void Awake()
    {
        // Singleton para fácil acesso
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore()
    {
        score += score;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Pontuação: " + score;
    }

    public int GetScore()
    {
        return score;
    }
}

