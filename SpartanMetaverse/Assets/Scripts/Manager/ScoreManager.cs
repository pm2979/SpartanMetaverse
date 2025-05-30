using TMPro;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    [SerializeField] private string highScore;

    public int Score { get; private set; }
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

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
            scoreText.text = Score.ToString();
    }

    public void SaveHighScore()
    {
        int bestScore = PlayerPrefs.GetInt(highScore, 0); // 저장된 최고 점수 불러오기

        if (Score > bestScore)
        {
            PlayerPrefs.SetInt(highScore, Score); // 최고 점수 갱신
            PlayerPrefs.Save(); // 즉시 저장
        }

        ScoreText();
    }

    private void ScoreText()
    {
        currentScoreText.text = Score.ToString();
        bestScoreText.text = PlayerPrefs.GetInt(highScore, 0).ToString();
    }

}
