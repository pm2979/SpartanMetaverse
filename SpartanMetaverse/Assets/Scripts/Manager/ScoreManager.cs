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
        int bestScore = PlayerPrefs.GetInt(highScore, 0); // ����� �ְ� ���� �ҷ�����

        if (Score > bestScore)
        {
            PlayerPrefs.SetInt(highScore, Score); // �ְ� ���� ����
            PlayerPrefs.Save(); // ��� ����
        }

        ScoreText();
    }

    private void ScoreText()
    {
        currentScoreText.text = Score.ToString();
        bestScoreText.text = PlayerPrefs.GetInt(highScore, 0).ToString();
    }

}
