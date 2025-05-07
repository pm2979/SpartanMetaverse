using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkinController : MonoBehaviour
{
    BaseController playerController;
    AnimationHandler animationHandler;
    RidingController ridingController;

    string currentKey;
    [SerializeField] private GameObject playerPrefab;

    private void Awake()
    {
        ridingController = GetComponent<RidingController>();
        playerController = GetComponent<BaseController>();
        animationHandler = GetComponent<AnimationHandler>();

        // ����� ������ Ű �ҷ�����
        currentKey = PlayerPrefs.GetString("PlayerPrefabKey", "Default");
        LoadPrefab(currentKey);
    }

    Sprite LoadPrefab(string key) // Ű�� �´� �����ո� �����´�.
    {
        if (playerController.chracterRenderer != null) // null�� �ƴ϶�� ���� ������ ����
            Destroy(playerController.chracterRenderer.gameObject);

        playerPrefab = Resources.Load<GameObject>($"Prefabs/{key}");
        GameObject _playerPrefab = Instantiate(playerPrefab);
        _playerPrefab.transform.SetParent(transform, worldPositionStays: false);
        
        if(ridingController.IsRide == true)
        {
            _playerPrefab.transform.localPosition = new Vector3(0, 1);
        }

        playerController.chracterRenderer = _playerPrefab.GetComponent<SpriteRenderer>(); // �������� SpriteRenderer �Ҵ�
        animationHandler.playerAnimator = _playerPrefab.GetComponent<Animator>(); // �������� Animator �Ҵ�

        return _playerPrefab.GetComponent<SpriteRenderer>().sprite;
    }

    public Sprite ChangeSkin(string newKey) // �÷��̾� ������ ���� �� ȣ��
    {
        // ���ο� Ű ����
        PlayerPrefs.SetString("PlayerPrefabKey", newKey);
        PlayerPrefs.Save();

        //�̹��� ����
        return LoadPrefab(newKey);
    }
}
