using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code sourced from https://youtu.be/v9E47DkckBE

[RequireComponent(typeof(MeshFilter))]
public class ProceduralMesh : MonoBehaviour
{
    Mesh mesh;
    int x = 0;

    Vector3[] vertices;
    int[] triangles;

    private void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }
    private void Start()
    {
        MakeMeshData();
        CreateMesh();
    }

    private void Update()
    {

        CreateMesh();
        if (Input.GetKey("right"))
        {
            x++;
            vertices = new Vector3[] { new Vector3(x, 0, 0), new Vector3(x, 0, 1), new Vector3(x + 1, 0, 0), new Vector3(x + 1, 0, 1) };
        }
        if (Input.GetKey("left"))
        {
            x--;
            vertices = new Vector3[] { new Vector3(x, 0, 0), new Vector3(x, 0, 1), new Vector3(x + 1, 0, 0), new Vector3(x + 1, 0, 1) };
        }
    }

    void MakeMeshData()
    {
        // Array of verticies
        vertices = new Vector3[] { new Vector3(x,0,0), new Vector3(x,0,1), new Vector3(x+1,0,0), new Vector3(x+1,0,1) };

        // What order should the verticies be drawn in
        triangles = new int[] { 0, 1, 2, 2, 1, 3 };
    }

    void CreateMesh()
    {
        // Clears the current mesh and then creates the new mesh
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }
}

