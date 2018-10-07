using UnityEngine;




public class InstanceManager : MonoBehaviour
{

    [HideInInspector]
    [SerializeField]
    GameObject starsInstance;
    [HideInInspector]
    [SerializeField]
    GameObject constellationsInstance;


    public StarDatabaseLoader starDatabaseLoader;
    public ConstellationDatabaseLoader constellationDatabaseLoader;


    public StarMeshGenerator starMeshGenerator;
    public ConstellationMeshGenerator constellationMeshGenerator;

    public MeshPrefabGenerator starPrefabGenerator;
    public MeshPrefabGenerator constellationPrefabGenerator;


    public void GenerateAndInstantiatePrefab()
    {
        starDatabaseLoader.LoadDatabase();
        //constellation database must load after star database
        constellationDatabaseLoader.LoadDatabase();

        starMeshGenerator.Generate();
        constellationMeshGenerator.Generate();

        starPrefabGenerator.Generate();
        constellationPrefabGenerator.Generate();
        InstantiatePrefab();
    }


    public void InstantiatePrefab()
    {
        if (starsInstance != null)
            GameObject.DestroyImmediate(starsInstance);
        if (constellationsInstance != null)
            GameObject.DestroyImmediate(constellationsInstance);

        var starPrefab = AssetUtility.GetAssetsAtPath<GameObject>(starPrefabGenerator.folderPath)[0];
        starsInstance = GameObject.Instantiate(starPrefab, Vector3.zero, Quaternion.identity, transform);

        var constellationPrefab = AssetUtility.GetAssetsAtPath<GameObject>(constellationPrefabGenerator.folderPath)[0];
        constellationsInstance = GameObject.Instantiate(constellationPrefab, Vector3.zero, Quaternion.identity, transform);
    }


}