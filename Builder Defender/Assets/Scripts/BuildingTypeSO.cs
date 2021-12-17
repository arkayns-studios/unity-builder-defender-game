using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Building/Type")]
public class BuildingTypeSO : ScriptableObject {

    public string nameString;
    public Transform prefab;
    public ResourceGeneratorData resourceGeneratorData;

} // Class BuildingTypeSO