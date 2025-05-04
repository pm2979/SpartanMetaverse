using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAppearance : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    string currentKey;

    Sprite idleSprite;

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        // ����� ��������Ʈ Ű �ҷ�����
        currentKey = PlayerPrefs.GetString("PlayerSpriteKey", "Default");
        LoadSprites(currentKey);
        spriteRenderer.sprite = idleSprite;
    }

    void LoadSprites(string key) // Ű�� �´� sprite�� �����´�.
    {
        idleSprite = Resources.Load<Sprite>($"Sprites/{key}");
    }

    public void ChangeAppearance(string newKey) // �÷��̾� �̹��� ���� �� ȣ��
    {
        // ���ο� Ű ����
        PlayerPrefs.SetString("PlayerSpriteKey", newKey);
        PlayerPrefs.Save();

        //�̹��� ����
        LoadSprites(newKey);
        spriteRenderer.sprite = idleSprite;
    }
}
