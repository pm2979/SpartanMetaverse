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

        // 저장된 스프라이트 키 불러오기
        currentKey = PlayerPrefs.GetString("PlayerSpriteKey", "Default");
        LoadSprites(currentKey);
        spriteRenderer.sprite = idleSprite;
    }

    void LoadSprites(string key) // 키에 맞는 sprite를 가져온다.
    {
        idleSprite = Resources.Load<Sprite>($"Sprites/{key}");
    }

    public void ChangeAppearance(string newKey) // 플레이어 이미지 변경 시 호출
    {
        // 새로운 키 저장
        PlayerPrefs.SetString("PlayerSpriteKey", newKey);
        PlayerPrefs.Save();

        //이미지 변경
        LoadSprites(newKey);
        spriteRenderer.sprite = idleSprite;
    }
}
