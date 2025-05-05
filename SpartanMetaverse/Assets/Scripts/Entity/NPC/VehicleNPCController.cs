using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleNPCController : MonoBehaviour
{
    [SerializeField] private UIState uiState;
    public UIState UIState { get => uiState; set => uiState = value; }

    [SerializeField] private VehicleUI vehicleUI;

    private RidingController ridingController;

    public void OnTriggerEnter2D(Collider2D col) // 상호작용 영역 안
    {
        if (col.CompareTag("Player"))
        {
            ridingController = col.GetComponent<RidingController>();
        }
    }

    public void OnTriggerExit2D(Collider2D col) // 상호작용 영역 밖
    {
        if (col.CompareTag("Player"))
        {
            ridingController = null;
            UIManager.Instance.SetPlayGame();
        }
    }

    public void Update()
    {
        if (ridingController != null && Input.GetKeyDown(KeyCode.F))
        {
            Interact();
            vehicleUI.SetRidingController(ridingController);
        }
    }

    public void Interact() // NPC와 상호작용 후 UI 실행
    {
        UIManager.Instance.ChangeState(UIState);
    }
}
