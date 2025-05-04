using UnityEngine;

public class NpcInteraction : MonoBehaviour
{
    private bool playerInRange = false;
    [SerializeField] private UIState uiState;

    private void OnTriggerEnter2D(Collider2D other) // 상호작용 영역 안
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other) // 상호작용 영역 밖
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
            Interact();
    }

    private void Interact() // NPC와 상호작용
    {
        UIManager.Instance.ChangeState(uiState);
    }
}
