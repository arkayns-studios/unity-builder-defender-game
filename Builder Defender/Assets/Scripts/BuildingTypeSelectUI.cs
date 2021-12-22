using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingTypeSelectUI : MonoBehaviour {

    [SerializeField] private Sprite arrowSprite;
    private Dictionary<BuildingTypeSO, Transform> btnTransformDictionary;
    private Transform arrowBtn;

    private void Awake () {
        Transform template = transform.Find ("Building Template");
        template.gameObject.SetActive (false);

        BuildingTypeListSO buildingTypeList = Resources.Load<BuildingTypeListSO> (typeof (BuildingTypeListSO).Name);
        btnTransformDictionary = new Dictionary<BuildingTypeSO, Transform> ();

        int index = 0;

        arrowBtn = Instantiate (template, transform);
        arrowBtn.gameObject.SetActive (true);

        float offsetAmount = 130f;
        arrowBtn.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (offsetAmount * index, 0);

        arrowBtn.Find ("Image").GetComponent<Image> ().sprite = arrowSprite;
        arrowBtn.Find ("Image").GetComponent<RectTransform> ().sizeDelta = new Vector2(0, -30);

        arrowBtn.GetComponent<Button> ().onClick.AddListener (() => {
            BuildingManager.Instance.SetActiveBuildingType (null);
        });

        index++;

        foreach (BuildingTypeSO buildingType in buildingTypeList.list) {
            Transform btnTransform = Instantiate (template, transform);
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

    private void Update () {
        UpdateActiveBuildingTypeButton ();
    } // Update

    private void UpdateActiveBuildingTypeButton () {
        arrowBtn.Find("Selected").gameObject.SetActive (false);
        foreach (BuildingTypeSO buildingType in btnTransformDictionary.Keys) {
            Transform btnTransform = btnTransformDictionary [buildingType];
            btnTransform.Find ("Selected").gameObject.SetActive(false);
        }

        BuildingTypeSO activeBuildingType = BuildingManager.Instance.GetActiveBuildingType ();
        if(activeBuildingType == null)
            arrowBtn.Find("Selected").gameObject.SetActive (true);
        else
            btnTransformDictionary [activeBuildingType].Find ("Selected").gameObject.SetActive (true);
    } // UpdateActiveBuildingTypeButton

} // Class BuildingTypeSelectUI