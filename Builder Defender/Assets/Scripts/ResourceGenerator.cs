using UnityEngine;

public class ResourceGenerator : MonoBehaviour {

    private BuildingTypeSO buildingType;
    private float timer;
    private float timerMax;
    private int iteration = 0;

    private void Awake () {
        buildingType = GetComponent<BuildingTypeHolder> ().buildingType;
        timerMax = buildingType.resourceGeneratorData.timerMax;
    } // Awake

    private void Update () {
        timer -= Time.deltaTime;
        if(timer <= 0f) {
            iteration++;
            timer = timerMax;
            ResourceManager.Instance.AddResource (buildingType.resourceGeneratorData.resourceType, iteration);
        }
    } // Update

} // Class ResourceGenerator