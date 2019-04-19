using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AstroRenderer : MonoBehaviour
{


    public bool reset;
    public Material rendererMaterial;

    protected virtual void Start()
    {
        Render();
        // if (rendererMaterial == null)
        //     Debug.LogWarning("Renderer material is unassigned");
    }


    protected virtual void Update()
    {
        if (reset)
        {
            reset = !reset;
            foreach (var child in transform)
            {
                Object.Destroy(((Transform)child).gameObject);
            }
            Render();
        }
    }


    protected void CreateMeshGameObject(string name, Mesh mesh, Material mat)
    {
        var go = new GameObject(name);
        go.transform.parent = transform;
        go.AddComponent<MeshRenderer>().material = mat;
        go.AddComponent<MeshFilter>().mesh = mesh;
    }

    protected abstract void Render();

}
