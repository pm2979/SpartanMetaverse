using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleNPCController : MonoBehaviour
{
    [SerializeField] private UIState uiState;
    public UIState UIState { get => uiState; set => uiState = value; }

    [SerializeField] private VehicleUI vehicleUI;

    private PlayerSkinController playerAppearance;

    public void OnTriggerEnter2D(Collider2D col) // ��ȣ�ۿ� ���� ��
    {
        if (col.CompareTag("Player"))
        {
            playerAppearance = col.GetComponent<PlayerSkinController>();
        }
    }

    public void OnTriggerExit2D(Collider2D col) // ��ȣ�ۿ� ���� ��
    {
        if (col.CompareTag("Player"))
        {
            playerAppearance = null;
            UIManager.Instance.SetPlayGame();
        }
    }

    public void Update()
    {
        if (playerAppearance != null && Input.GetKeyDown(KeyCode.F))
        {
            Interact();
            //vehicleUI.SetPlayerAppearance(playerAppearance);
        }
    }

    public void Interact() // NPC�� ��ȣ�ۿ� �� UI ����
    {
        UIManager.Instance.ChangeState(UIState);
    }
}
