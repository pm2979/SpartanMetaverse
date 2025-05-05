using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SkinUI : BaseUI
{
    [SerializeField] private Image playerImg;

    private PlayerSkinController playerAppearance;
    string currentKey;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        currentKey = PlayerPrefs.GetString("PlayerSpriteKey", "Default");
        playerImg.sprite = Resources.Load<Sprite>($"Sprites/{currentKey}");
    }

    protected override UIState GetUIState()
    {
        return UIState.Skin;
    }

    public void SetPlayerAppearance(PlayerSkinController playerAppearance)
    {
        this.playerAppearance = playerAppearance;
    }

    public void OnClickSkinChange(TextMeshProUGUI texts)
    {
        playerAppearance.ChangeSkin(texts.text.ToString());
    }

    public void OnClickExit()
    {
        UIManager.Instance.SetPlayGame();
    }
}
