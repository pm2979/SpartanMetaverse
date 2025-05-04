using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class StyleUI : BaseUI
{
    [SerializeField] private Image playerImg;

    private PlayerAppearance playerAppearance;
    string currentKey;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        currentKey = PlayerPrefs.GetString("PlayerSpriteKey", "Default");
        playerImg.sprite = Resources.Load<Sprite>($"Sprites/{currentKey}");
    }

    protected override UIState GetUIState()
    {
        return UIState.Style;
    }

    public void SetPlayerAppearance(PlayerAppearance playerAppearance)
    {
        this.playerAppearance = playerAppearance;
    }

    public void OnClickSkinChange(TextMeshProUGUI texts)
    {
        playerAppearance.ChangeAppearance(texts.text.ToString());
    }

    public void OnClickExit()
    {
        UIManager.Instance.SetPlayGame();
    }
}
