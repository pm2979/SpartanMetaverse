using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SkinUI : BaseUI
{
    [SerializeField] private Image playerImg;

    private PlayerSkinController playerSkinController;
    string currentKey;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        currentKey = PlayerPrefs.GetString("PlayerPrefabKey", "Default");
        playerImg.sprite = Resources.Load<GameObject>($"Prefabs/{currentKey}").GetComponent<SpriteRenderer>().sprite;
    }

    protected override UIState GetUIState()
    {
        return UIState.Skin;
    }

    public void SetPlayerSkinController(PlayerSkinController playerSkinController)
    {
        this.playerSkinController = playerSkinController;
    }

    public void OnClickSkinChange(TextMeshProUGUI texts)
    {
        playerImg.sprite = playerSkinController.ChangeSkin(texts.text.ToString());
    }

    public void OnClickExit()
    {
        UIManager.Instance.SetPlayGame();
    }
}
