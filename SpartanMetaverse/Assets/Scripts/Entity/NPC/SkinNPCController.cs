using UnityEngine;

public class SkinNPCController : MonoBehaviour, INPCInteraction
{
    [SerializeField] private UIState uiState;
    public UIState UIState { get => uiState; set => uiState = value; }

    [SerializeField] private SkinUI skinUI;

    private PlayerSkinController playerAppearance;

    public void OnTriggerEnter2D(Collider2D col) // 상호작용 영역 안
    {
        if (col.CompareTag("Player"))
        {
            playerAppearance = col.GetComponent<PlayerSkinController>();
        }
    }

    public void OnTriggerExit2D(Collider2D col) // 상호작용 영역 밖
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
            skinUI.SetPlayerSkinController(playerAppearance);
        }
    }

    public void Interact() // NPC와 상호작용 후 UI 실행
    {
        UIManager.Instance.ChangeState(UIState);
    }
}
