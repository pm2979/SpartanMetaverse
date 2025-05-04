using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAppearance : MonoBehaviour
{
    BaseController playerController;
    AnimationHandler animationHandler;

    string currentKey;
    [SerializeField] private GameObject playerPrefab;

    private void Awake()
    {
        playerController = GetComponent<BaseController>();
        animationHandler = GetComponent<AnimationHandler>();

        // ����� ������ Ű �ҷ�����
        currentKey = PlayerPrefs.GetString("PlayerSpriteKey", "Default");
        LoadPrefab(currentKey);
    }


    void LoadPrefab(string key) // Ű�� �´� �����ո� �����´�.
    {
        if (playerController.chracterRenderer != null) // null�� �ƴ϶�� ���� ������ ����
            Destroy(playerController.chracterRenderer.gameObject);

        playerPrefab = Resources.Load<GameObject>($"Prefabs/{key}");
        GameObject _playerPrefab = Instantiate(playerPrefab);
        _playerPrefab.transform.SetParent(transform, worldPositionStays: false);

        playerController.chracterRenderer = _playerPrefab.GetComponent<SpriteRenderer>(); // �������� SpriteRenderer �Ҵ�
        animationHandler.animator = _playerPrefab.GetComponent<Animator>(); // �������� Animator �Ҵ�
    }

    public void ChangeAppearance(string newKey) // �÷��̾� ������ ���� �� ȣ��
    {
        // ���ο� Ű ����
        PlayerPrefs.SetString("PlayerSpriteKey", newKey);
        PlayerPrefs.Save();

        //�̹��� ����
        LoadPrefab(newKey);
    }
}
