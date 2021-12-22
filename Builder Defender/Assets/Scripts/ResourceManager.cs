using System;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {

    public static ResourceManager Instance { get; private set; }

    public event EventHandler OnResourceAmountChanged;
    private Dictionary<ResourceTypeSO, int> resourceAmountDictionary;

    private void Awake () {
        Instance = this;
        resourceAmountDictionary = new Dictionary<ResourceTypeSO, int> ();
        ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO> (typeof (ResourceTypeListSO).Name);

        foreach (ResourceTypeSO resourceType in resourceTypeList.list) 
            resourceAmountDictionary [resourceType] = 0;
    } // Awake

    public int GetResourceAmount (ResourceTypeSO resourceType) {
        return resourceAmountDictionary [resourceType];
    } // GetResourceAmount

    private void TestLogResourceAmountDictionary () {
        foreach (ResourceTypeSO resourceType in resourceAmountDictionary.Keys) 
            Debug.Log ($"{resourceType.nameString} : {resourceAmountDictionary [resourceType]}");
    } // TestLogResourceAmountDictionary

    public void AddResource(ResourceTypeSO resourceType, int interation) {
        resourceAmountDictionary [resourceType] = interation * 1; // 1 is how much it should increase
        //resourceAmountDictionary [resourceType] += amount;
        OnResourceAmountChanged?.Invoke (this, EventArgs.Empty);
    } // AddResource

} // Class ResourceManager