using TMPro;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    public int Score { get; private set; }
    [SerializeField] private TextMeshProUGUI scoreText;

    protected override void Awake()
    {
        Score = 0;
    }

    public void AddScore(int coin)
    {
        Score += coin;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = $"{Score}";
    }

}
