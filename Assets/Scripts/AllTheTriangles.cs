using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AllTheTriangles : AbstractMeshGenerator
{
    

    [SerializeField] private Vector3[] vs = new Vector3[3];
    [SerializeField] private bool reverseTriangles;
    

    

    protected override void SetVertices()
    {
        vertices.AddRange( vs);
    }

    protected override void SetTriangles()
    {
        if (!reverseTriangles)
        {
            triangles.Add(0);
            triangles.Add(1);
            triangles.Add(2);
        }
        else
        {
            triangles.Add(2);
            triangles.Add(1);
            triangles.Add(0);
        }
    }
}
