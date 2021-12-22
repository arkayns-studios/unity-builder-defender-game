using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingManager : MonoBehaviour {

    public static BuildingManager Instance { get; private set; }

    private BuildingTypeListSO buildingTypeList;
    private BuildingTypeSO activeBuildingType;
    private Camera mainCamera;

    private void Awake () {
        Instance = this;
        buildingTypeList = Resources.Load<BuildingTypeListSO> (typeof (BuildingTypeListSO).Name);
    } // Awake

    private void Start () {
        mainCamera = Camera.main;
    } // Start

    private void Update () {
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject()) {
            if(activeBuildingType != null)
                Instantiate (activeBuildingType.prefab, GetMouseWorldPosition (), Quaternion.identity);
        }
            
    } // Update

    private Vector3 GetMouseWorldPosition () {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint (Input.mousePosition);
        mouseWorldPosition.z = 0f;
        return mouseWorldPosition;
    } // GetMouseWorldPosition

    public void SetActiveBuildingType (BuildingTypeSO buildingType) {
        activeBuildingType = buildingType;
    } // SetActiveBuildingType

    public BuildingTypeSO GetActiveBuildingType () {
        return activeBuildingType;
    } // GetActiveBuildingType

} // Class BuildingManager