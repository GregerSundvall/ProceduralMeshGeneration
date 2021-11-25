using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter)), RequireComponent(typeof(MeshRenderer))]
[ExecuteInEditMode]
public abstract class AbstractMeshGenerator : MonoBehaviour
{
    [SerializeField] protected Material material;
    [SerializeField] private Vector3[] vs = new Vector3[3];
    [SerializeField] private float size = 1;
    [SerializeField] private bool reverseTriangles;

    protected List<Vector3> vertices;
    protected List<int> triangles;

    protected int numVertices;
    protected int numTriangles;

    protected MeshFilter meshFilter;
    protected MeshRenderer meshRenderer;
    protected Mesh mesh;
    
    private void Update()
    {
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();

        meshRenderer.material = material;
        
        InitMesh();
        
        CreateMesh();
    }

    void SetVertices()
    {
        //vertices.AddRange( vs);
        vertices.Add(new Vector3(0, size, 0));
        vertices.Add(new Vector3(size, 0, 0));
        vertices.Add(new Vector3(0, 0, -size));
        vertices.Add(new Vector3(-size, 0, 0));
        vertices.Add(new Vector3(0, 0, size));
        vertices.Add(new Vector3(0, -size, 0));
        
        
    }

    void SetTriangles()
    {
        triangles.Add(0);
        triangles.Add(1);
        triangles.Add(2);
        triangles.Add(0);
        triangles.Add(2);
        triangles.Add(3);
        triangles.Add(0);
        triangles.Add(3);
        triangles.Add(4);
        triangles.Add(0);
        triangles.Add(4);
        triangles.Add(1);
        triangles.Add(5);
        triangles.Add(2);
        triangles.Add(1);
        triangles.Add(5);
        triangles.Add(3);
        triangles.Add(2);
        triangles.Add(5);
        triangles.Add(4);
        triangles.Add(3);
        triangles.Add(5);
        triangles.Add(1);
        triangles.Add(4);
        
        
        // if (!reverseTriangles)
        // {
        //     triangles.Add(0);
        //     triangles.Add(1);
        //     triangles.Add(2);
        // }
        // else
        // {
        //     triangles.Add(2);
        //     triangles.Add(1);
        //     triangles.Add(0);
        // }
    }
   

    private void InitMesh()
    {
        vertices = new List<Vector3>();
        triangles = new List<int>();
    }
    
    
    private void CreateMesh()
    {
        mesh = new Mesh();

        SetVertices();
        SetTriangles();
        
        // Always in this order in Unity!
        mesh.SetVertices(vertices);
        mesh.SetTriangles(triangles, 0);
        
        mesh.RecalculateNormals();

        meshFilter.mesh = mesh;
    }

    // protected abstract void SetVertices();
    // protected abstract void SetTriangles();
    private bool ValidateMesh()
    {
        var errorString = "";
        errorString += vertices.Count == numVertices
            ? ""
            : "Should be " + numVertices + " vertices, but there are " + vertices.Count + ". ";
        errorString += triangles.Count == numTriangles
            ? ""
            : "Should be " + numTriangles + " triangles, but there are " + triangles.Count + ". ";

        bool isValid = string.IsNullOrEmpty(errorString);
        if (isValid)
        {
            Debug.LogError("Not drawing mesh. " + errorString);
        }

        return isValid;
    }

}
