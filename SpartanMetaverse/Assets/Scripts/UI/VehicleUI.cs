using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VehicleUI : BaseUI
{
    [SerializeField] private Image vehicleImg;

    private RidingController ridingController;

    string currentKey;

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

        currentKey = PlayerPrefs.GetString("VehiclePrefabKey", "Default");
        vehicleImg.sprite = Resources.Load<GameObject>($"Prefabs/Vehicle/{currentKey}").GetComponent<SpriteRenderer>().sprite;
    }

    public void SetRidingController(RidingController ridingController)
    {
        this.ridingController = ridingController;
    }

    protected override UIState GetUIState()
    {
        return UIState.Vehicle;
    }

    public void OnClickSkinChange(TextMeshProUGUI texts) // 탑승 스킨 변경 버튼
    {
        ridingController.ChangeVehicleSkin(texts.text.ToString());
        vehicleImg.sprite = Resources.Load<GameObject>($"Prefabs/Vehicle/{texts.text}").GetComponent<SpriteRenderer>().sprite;
    }

    public void OnClickExit()
    {
        UIManager.Instance.SetPlayGame();
    }
}
