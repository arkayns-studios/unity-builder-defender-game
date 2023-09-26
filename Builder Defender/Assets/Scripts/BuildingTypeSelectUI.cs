using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingTypeSelectUI : MonoBehaviour {

    // -- Variables --
    [SerializeField] private Sprite arrowSprite;
    private Dictionary<BuildingTypeSO, Transform> btnTransformDictionary;
    private Transform arrowBtn;

    // -- Built-In Methods --
    private void Awake () {
        var template = transform.Find ("Building Template");
        template.gameObject.SetActive (false);

        var buildingTypeList = Resources.Load<BuildingTypeListSO> (nameof(BuildingTypeListSO));
        btnTransformDictionary = new Dictionary<BuildingTypeSO, Transform> ();

        var index = 0;

        arrowBtn = Instantiate (template, transform);
        arrowBtn.gameObject.SetActive (true);

        var offsetAmount = 130f;
        arrowBtn.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (offsetAmount * index, 0);

        arrowBtn.Find ("Image").GetComponent<Image> ().sprite = arrowSprite;
        arrowBtn.Find ("Image").GetComponent<RectTransform> ().sizeDelta = new Vector2(0, -30);

        arrowBtn.GetComponent<Button> ().onClick.AddListener (() => {
            BuildingManager.Instance.SetActiveBuildingType (null);
        });

        index++;

        foreach (var buildingType in buildingTypeList.list) {
            var btnTransform = Instantiate (template, transform);
            btnTransform.gameObject.SetActive (true);

            offsetAmount = 130f;
            btnTransform.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (offsetAmount * index, 0);

            btnTransform.Find ("Image").GetComponent<Image> ().sprite = buildingType.sprite;

            btnTransform.GetComponent<Button> ().onClick.AddListener (() => {
                BuildingManager.Instance.SetActiveBuildingType (buildingType);
            });

            btnTransformDictionary [buildingType] = btnTransform;

            index++;
        }

    } // Awake

    private void Start() {
        BuildingManager.Instance.OnActiveBuildingTypeChanged += BuildingManager_OnActiveBuildingTypeChanged;
        UpdateActiveBuildingTypeButton();
    } // Start ()

    // -- Custom Methods --
    private void UpdateActiveBuildingTypeButton () {
        arrowBtn.Find("Selected").gameObject.SetActive (false);
        foreach (var buildingType in btnTransformDictionary.Keys) {
            var btnTransform = btnTransformDictionary [buildingType];
            btnTransform.Find ("Selected").gameObject.SetActive(false);
        }

        var activeBuildingType = BuildingManager.Instance.GetActiveBuildingType ();
        if(activeBuildingType == null) arrowBtn.Find("Selected").gameObject.SetActive (true);
        else btnTransformDictionary [activeBuildingType].Find ("Selected").gameObject.SetActive (true);
    } // UpdateActiveBuildingTypeButton

    private void BuildingManager_OnActiveBuildingTypeChanged(object _sender, BuildingManager.OnActiveBuildingTypeChangedEventArgs _e) {
        UpdateActiveBuildingTypeButton();
    } // BuildingManager_OnActiveBuildingTypeChanged ()
    
} // Class BuildingTypeSelectUI