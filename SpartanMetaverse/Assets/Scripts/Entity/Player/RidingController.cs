using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RidingController : MonoBehaviour
{

    private AnimationHandler animationHandler;

    private string currentKey;
    private GameObject vehiclePrefab; // 탑승 프리팹 
    private GameObject vehicleObj; // 탑승 중 obj

    public bool IsRide { get; private set; } // 탑승 여부

    private void Awake()
    {
        animationHandler = GetComponent<AnimationHandler>();

        currentKey = PlayerPrefs.GetString("VehiclePrefabKey", "Default");
        vehiclePrefab = Resources.Load<GameObject>($"Prefabs/Vehicle/{currentKey}");

        IsRide = false;
    }

    public void VehicleOn() // 키에 맞는 프리팹를 가져온다.
    {

        vehicleObj = Instantiate(vehiclePrefab);
        vehicleObj.transform.SetParent(transform, worldPositionStays: false);

        animationHandler.vehicleAnimator = vehicleObj.GetComponent<Animator>(); // 프리팹의 Animator 할당

        IsRide = true;
    }

    public void ChangeVehicleSkin(string newKey) // 탈것 스킨 변경
    {
        // 새로운 키 저장
        PlayerPrefs.SetString("VehiclePrefabKey", newKey);
        PlayerPrefs.Save();

        // 새로운 프리팹으로 변경
        vehiclePrefab = Resources.Load<GameObject>($"Prefabs/Vehicle/{newKey}");

        if (IsRide == true) // 타는 중이라면
        {
            VehicleOff();
            VehicleOn();
            VehicleScaleUp();
        }
    }

    public void VehicleScaleUp()
    {
        vehicleObj.transform.localScale = new Vector3(1.5f, 1.5f, 1);
    }

    public void VehicleOff() // 탈것 off
    {
        Destroy(vehicleObj);
        IsRide = false;
    }

    public void VehicleRotate(bool isLeft) // 탈것 좌우 변경
    {
        if(vehicleObj != null)
        vehicleObj.GetComponent<SpriteRenderer>().flipX = isLeft;
    }
}
