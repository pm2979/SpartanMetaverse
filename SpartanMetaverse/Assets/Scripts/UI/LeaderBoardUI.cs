using TMPro;
using UnityEngine;

public class LeaderBoardUI : BaseUI
{
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TextMeshProUGUI gameNameText;

    public string highScore;
    public string gameName;

    protected override UIState GetUIState()
    {
        return UIState.LeaderBoard;
    }

    public void OnEnable()
    {
        bestScoreText.text = PlayerPrefs.GetInt(highScore, 0).ToString();
        gameNameText.text = gameName;
    }


}
