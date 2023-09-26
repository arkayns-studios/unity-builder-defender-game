using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingManager : MonoBehaviour {

    // -- Variables --
    public static BuildingManager Instance { get; private set; }

    private BuildingTypeListSO buildingTypeList;
    private BuildingTypeSO activeBuildingType;
    private Camera mainCamera;

    // -- Events --
    public event EventHandler<OnActiveBuildingTypeChangedEventArgs> OnActiveBuildingTypeChanged;
    
    // -- Class --
    public class OnActiveBuildingTypeChangedEventArgs : EventArgs {

        // -- Variables --
        public BuildingTypeSO activeBuildingType;

    } // Class OnActiveBuildingTypeChangedEventArgs
    
    // -- Built-In Methods --
    private void Awake () {
        Instance = this;
        buildingTypeList = Resources.Load<BuildingTypeListSO> (nameof(BuildingTypeListSO));
    } // Awake

    private void Start () {
        mainCamera = Camera.main;
    } // Start

    private void Update () {
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject()) {
            if(activeBuildingType != null) Instantiate (activeBuildingType.prefab, Utils.GetMouseWorldPosition (), Quaternion.identity);
        }
    } // Update
    
    // -- Custom Methods --
    public void SetActiveBuildingType (BuildingTypeSO buildingType) {
        activeBuildingType = buildingType;
        OnActiveBuildingTypeChanged?.Invoke(this, new OnActiveBuildingTypeChangedEventArgs { activeBuildingType = activeBuildingType});
    } // SetActiveBuildingType

    public BuildingTypeSO GetActiveBuildingType () {
        return activeBuildingType;
    } // GetActiveBuildingType

} // Class BuildingManager