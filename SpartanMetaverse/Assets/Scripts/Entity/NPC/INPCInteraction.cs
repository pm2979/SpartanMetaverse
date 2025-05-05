using UnityEngine;

public interface INPCInteraction
{
    UIState UIState { get; set; }

    void OnTriggerEnter2D(Collider2D col); // 상호작용 영역 안

    void OnTriggerExit2D(Collider2D col); // 상호작용 영역 밖

    void Update();

    void Interact(); // NPC와 상호작용 효과
}
