﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceUI : MonoBehaviour {

    private ResourceTypeListSO resourceTypeList;

    private Dictionary<ResourceTypeSO, Transform> resourceTypeTransformDictionary;

    private void Awake () {
        resourceTypeList = Resources.Load<ResourceTypeListSO> (typeof (ResourceTypeListSO).Name);

        resourceTypeTransformDictionary = new Dictionary<ResourceTypeSO, Transform> ();

        Transform resourceTemplate = transform.Find ("Resource Template");
        resourceTemplate.gameObject.SetActive (false);

        int index = 0;
        foreach (ResourceTypeSO resourceType in resourceTypeList.list) {
            Transform resourceTransform = Instantiate (resourceTemplate, transform);
            resourceTransform.gameObject.SetActive (true);

            float offsetAmount = -130f;
            resourceTransform.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (offsetAmount * index, 0);

            resourceTransform.Find ("Image").GetComponent<Image> ().sprite = resourceType.sprite;

            resourceTypeTransformDictionary [resourceType] = resourceTransform;

            index++;
        }

    } // Awake

    private void Start () {
        ResourceManager.Instance.OnResourceAmountChanged += ResourceManager_OnResourceAmountChanged;
        UpdateResourceAmount ();
    } // Start

    private void ResourceManager_OnResourceAmountChanged (object sender, System.EventArgs e) {
        UpdateResourceAmount ();
    } // ResourceManager_OnResourceAmountChanged

    private void UpdateResourceAmount () {
        foreach (ResourceTypeSO resourceType in resourceTypeList.list) {
            Transform resourceTransform = resourceTypeTransformDictionary [resourceType];

            int resourceAmount = ResourceManager.Instance.GetResourceAmount (resourceType);
            resourceTransform.Find ("Text").GetComponent<TextMeshProUGUI> ().SetText (resourceAmount.ToString ());
        }
    } // UpdateResourceAmount

} // Class ResourceUI