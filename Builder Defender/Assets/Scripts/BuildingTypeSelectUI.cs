using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTypeSelectUI : MonoBehaviour {

    private void Awake () {
        Transform template = transform.Find ("Building Template");
        template.gameObject.SetActive (false);

        BuildingTypeListSO buildingTypeList = Resources.Load<BuildingTypeListSO> (typeof (BuildingTypeListSO).Name);

        foreach (BuildingTypeSO buildingType in buildingTypeList.list) {
            Transform btnTransform = Instantiate (template, transform);
            btnTransform.gameObject.SetActive (true);


        }

    } // Awake

} // Class BuildingTypeSelectUI