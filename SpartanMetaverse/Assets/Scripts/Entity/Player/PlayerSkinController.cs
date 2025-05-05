using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinController : MonoBehaviour
{
    BaseController playerController;
    AnimationHandler animationHandler;

    string currentKey;
    [SerializeField] private GameObject playerPrefab;

    private void Awake()
    {
        playerController = GetComponent<BaseController>();
        animationHandler = GetComponent<AnimationHandler>();

        // 저장된 프리팹 키 불러오기
        currentKey = PlayerPrefs.GetString("PlayerPrefabKey", "Default");
        LoadPrefab(currentKey);
    }

    void LoadPrefab(string key) // 키에 맞는 프리팹를 가져온다.
    {
        if (playerController.chracterRenderer != null) // null이 아니라면 이전 프리팹 삭제
            Destroy(playerController.chracterRenderer.gameObject);

        playerPrefab = Resources.Load<GameObject>($"Prefabs/{key}");
        GameObject _playerPrefab = Instantiate(playerPrefab);
        _playerPrefab.transform.SetParent(transform, worldPositionStays: false);

        playerController.chracterRenderer = _playerPrefab.GetComponent<SpriteRenderer>(); // 프리팹의 SpriteRenderer 할당
        animationHandler.playerAnimator = _playerPrefab.GetComponent<Animator>(); // 프리팹의 Animator 할당
    }

    public void ChangeSkin(string newKey) // 플레이어 프리팹 변경 시 호출
    {
        // 새로운 키 저장
        PlayerPrefs.SetString("PlayerPrefabKey", newKey);
        PlayerPrefs.Save();

        //이미지 변경
        LoadPrefab(newKey);
    }
}
