using UnityEngine;

public class NpcInteraction : MonoBehaviour
{
    private bool playerInRange = false;
    [SerializeField] private UIState uiState;

    private void OnTriggerEnter2D(Collider2D other) // ��ȣ�ۿ� ���� ��
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other) // ��ȣ�ۿ� ���� ��
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
            Interact();
    }

    private void Interact() // NPC�� ��ȣ�ۿ�
    {
        UIManager.Instance.ChangeState(uiState);
    }
}
