using System;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour {

    // -- Variables --
    private ResourceGeneratorData resourceGeneratorData;
    private float timer;
    private float timerMax;
    private int iteration;

    // -- Built-In Methods --
    private void Awake () {
        resourceGeneratorData = GetComponent<BuildingTypeHolder>().buildingType.resourceGeneratorData;
        timerMax = resourceGeneratorData.timerMax;
    } // Awake
 
    private void Start() {
        var colliderArray = Physics2D.OverlapCircleAll(transform.position, resourceGeneratorData.detectionRadius);
        var nearbyNodes = 0;
        foreach (var collider in colliderArray) {
            var resourceNode = collider.GetComponent<ResourceNode>();
            if (resourceNode != null) {
                if(resourceNode.resource == resourceGeneratorData.resourceType) nearbyNodes++;
            }
        }

        nearbyNodes = Mathf.Clamp(nearbyNodes, 0, resourceGeneratorData.maxResourceAmount);
        if (nearbyNodes == 0) {
            enabled = false;
        }
        else {
            timerMax = (resourceGeneratorData.timerMax / 2F) + 
                       resourceGeneratorData.timerMax * 
                       (1 - (float)nearbyNodes / resourceGeneratorData.maxResourceAmount);
        }
    } // Start ()

    private void Update () {
        timer -= Time.deltaTime;
        if(timer <= 0F) {
            //iteration++;
            //timer = timerMax;
            timer += timerMax;
            ResourceManager.Instance.AddResource (resourceGeneratorData.resourceType, 1);
        }
    } // Update

} // Class ResourceGenerator