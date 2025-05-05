using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RidingController : MonoBehaviour
{

    private AnimationHandler animationHandler;

    private string currentKey;
    private GameObject vehiclePrefab; // ž�� ������ 
    private GameObject vehicleObj; // ž�� �� obj

    public bool IsRide { get; private set; } // ž�� ����

    private void Awake()
    {
        animationHandler = GetComponent<AnimationHandler>();

        currentKey = PlayerPrefs.GetString("VehiclePrefabKey", "Default");
        vehiclePrefab = Resources.Load<GameObject>($"Prefabs/Vehicle/{currentKey}");

        IsRide = false;
    }

    public void VehicleOn() // Ű�� �´� �����ո� �����´�.
    {

        vehicleObj = Instantiate(vehiclePrefab);
        vehicleObj.transform.SetParent(transform, worldPositionStays: false);

        animationHandler.vehicleAnimator = vehicleObj.GetComponent<Animator>(); // �������� Animator �Ҵ�

        IsRide = true;
    }

    public void ChangeVehicleSkin(string newKey) // Ż�� ��Ų ����
    {
        // ���ο� Ű ����
        PlayerPrefs.SetString("VehiclePrefabKey", newKey);
        PlayerPrefs.Save();

        if(IsRide == true) // Ÿ�� ���̶��
        {
            VehicleOff();
            VehicleOn();
        }
    }

    public void VehicleScaleUp()
    {
        vehicleObj.transform.localScale = new Vector3(1.5f, 1.5f, 1);
    }

    public void VehicleOff() // Ż�� off
    {
        Destroy(vehicleObj);
        IsRide = false;
    }

    public void VehicleRotate(bool isLeft)
    {
        if(vehicleObj != null)
        vehicleObj.GetComponent<SpriteRenderer>().flipX = isLeft;
    }
}
