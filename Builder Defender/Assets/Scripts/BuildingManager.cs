using UnityEngine;

public class BuildingManager : MonoBehaviour {

    private BuildingTypeListSO buildingTypeList;
    private BuildingTypeSO buildingType;
    private Camera mainCamera;

    private void Awake () {
        buildingTypeList = Resources.Load<BuildingTypeListSO> (typeof (BuildingTypeListSO).Name);
        buildingType = buildingTypeList.list [0];
    } // Awake

    private void Start () {
        mainCamera = Camera.main;
    } // Start

    private void Update () {
        if (Input.GetMouseButton(0)) 
            Instantiate (buildingType.prefab, GetMouseWorldPosition (), Quaternion.identity);

        if (Input.GetKey(KeyCode.T)) 
            buildingType = buildingTypeList.list [0];

        if (Input.GetKey (KeyCode.Y)) 
            buildingType = buildingTypeList.list [1];
    } // Update

    private Vector3 GetMouseWorldPosition () {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint (Input.mousePosition);
        mouseWorldPosition.z = 0f;
        return mouseWorldPosition;
    } // GetMouseWorldPosition

} // Class BuildingManager