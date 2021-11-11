using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter)), RequireComponent(typeof(MeshRenderer))]
[ExecuteInEditMode]
public abstract class AbstractMeshGenerator : MonoBehaviour
{
    [SerializeField] protected Material material;
    
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

    protected abstract void SetVertices();
    protected abstract void SetTriangles();


}
