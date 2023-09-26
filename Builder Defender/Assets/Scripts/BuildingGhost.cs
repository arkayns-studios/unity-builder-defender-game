using System;
using UnityEngine;

public class BuildingGhost : MonoBehaviour {

    // -- Variables --
    private GameObject sprite;
    
    // -- Built-In Methods --
    private void Awake() {
        sprite = transform.GetComponentInChildren<SpriteRenderer>().gameObject;
        
        Hide();
    } // Awake ()

    private void Start() {
        BuildingManager.Instance.OnActiveBuildingTypeChanged += BuildingManager_OnActiveBuildingTypeChanged;
    } // Start ()

    private void Update() {
        transform.position = Utils.GetMouseWorldPosition();
    } // Update ()

    // -- Custom Methods --
    private void Show(Sprite ghost) {
        sprite.SetActive(true);
        sprite.GetComponent<SpriteRenderer>().sprite = ghost;
    } // Show ()

    private void Hide() {
        sprite.SetActive(false);
    } // Hide ()

    private void BuildingManager_OnActiveBuildingTypeChanged(object sender, BuildingManager.OnActiveBuildingTypeChangedEventArgs e) {
        if(e.activeBuildingType == null) Hide();
        else Show(e.activeBuildingType.sprite);
    } // BuildingManager_OnActiveBuildingTypeChanged ()
    
} // Class BuildingGhost