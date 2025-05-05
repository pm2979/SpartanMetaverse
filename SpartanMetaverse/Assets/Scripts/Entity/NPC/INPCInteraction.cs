using UnityEngine;

public interface INPCInteraction
{
    UIState UIState { get; set; }

    void OnTriggerEnter2D(Collider2D col); // ��ȣ�ۿ� ���� ��

    void OnTriggerExit2D(Collider2D col); // ��ȣ�ۿ� ���� ��

    void Update();

    void Interact(); // NPC�� ��ȣ�ۿ� ȿ��
}
