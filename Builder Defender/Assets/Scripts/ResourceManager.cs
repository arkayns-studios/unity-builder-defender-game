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
        var resourceTypeList = Resources.Load<ResourceTypeListSO> (nameof(ResourceTypeListSO));
        foreach (var resourceType in resourceTypeList.list) resourceAmountDictionary [resourceType] = 0;
    } // Awake

    public int GetResourceAmount (ResourceTypeSO resourceType) {
        return resourceAmountDictionary [resourceType];
    } // GetResourceAmount

    public void AddResource(ResourceTypeSO resourceType, int amount) {
        //resourceAmountDictionary [resourceType] = amount * 1; // 1 is how much it should increase
        resourceAmountDictionary [resourceType] += amount;
        OnResourceAmountChanged?.Invoke (this, EventArgs.Empty);
    } // AddResource

} // Class ResourceManager