using UnityEngine;

public class NpcInteraction : MonoBehaviour
{
    [SerializeField] private UIState uiState;
    [SerializeField] private StyleUI uiStyle;

    private PlayerAppearance playerAppearance;

    private void OnTriggerEnter2D(Collider2D col) // ��ȣ�ۿ� ���� ��
    {
        if (col.CompareTag("Player"))
        {
            playerAppearance = col.GetComponent<PlayerAppearance>();
        }
    }

    private void OnTriggerExit2D(Collider2D col) // ��ȣ�ۿ� ���� ��
    {
        if (col.CompareTag("Player"))
        {
            playerAppearance = null;
        }
    }

    private void Update()
    {
        if (playerAppearance != null && Input.GetKeyDown(KeyCode.F))
        {
            Interact();
            uiStyle.SetPlayerAppearance(playerAppearance);
        }
    }

    private void Interact() // NPC�� ��ȣ�ۿ� �� UI ����
    {
        UIManager.Instance.ChangeState(uiState);
    }
}
