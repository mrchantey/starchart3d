using UnityEngine;




public class InstanceManager : MonoBehaviour
{

    [HideInInspector]
    [SerializeField]
    GameObject instance;

    public DatabaseLoader databaseLoader;
    public StarMeshGenerator starMeshGenerator;
    public MeshPrefabGenerator starPrefabGenerator;



    public void GenerateAndInstantiatePrefab()
    {
        databaseLoader.LoadDatabase();
        starMeshGenerator.Generate();
        starPrefabGenerator.Generate();
        InstantiatePrefab();
    }


    public void InstantiatePrefab()
    {
        if (instance != null)
        {
            GameObject.DestroyImmediate(instance);
        }
        var prefab = AssetUtility.GetAssetsAtPath<GameObject>(starPrefabGenerator.folderPath)[0];
        instance = GameObject.Instantiate(prefab, Vector3.zero, Quaternion.identity, transform);
    }


}