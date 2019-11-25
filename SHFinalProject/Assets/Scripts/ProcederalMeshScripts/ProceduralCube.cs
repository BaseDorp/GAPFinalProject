using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code Sourced from https://youtu.be/bnmr_At2R0s

[RequireComponent (typeof(MeshFilter), typeof(MeshRenderer))]
public class ProceduralCube : MonoBehaviour
{
    [SerializeField]
    float Addheight = .01f;

    Mesh mesh;
    CubeMeshData data;
    List<Vector3> vertices;
    List<int> triangles;

    private void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        data = GetComponent<CubeMeshData>();
    }

    private void Update()
    {
        MakeCube();
        UpdateMesh();

        if (Input.GetKey("up"))
        {
            Debug.Log("Up");
            data.height+=Addheight;
        }
        if (Input.GetKey("down") && data.height > 1)
        {
            data.height-=Addheight;
        }
    }

    void MakeFace(int dir)
    {
        vertices.AddRange(data.faceVertices(dir));
        int vCount = vertices.Count;

        triangles.Add(vCount - 4);
        triangles.Add(vCount - 4 + 1);
        triangles.Add(vCount - 4 + 2);
        triangles.Add(vCount - 4);
        triangles.Add(vCount - 4 + 2);
        triangles.Add(vCount - 4 + 3);
    }

    void MakeCube()
    {
        vertices = new List<Vector3>();
        triangles = new List<int>();

        for (int i = 0; i < 6; i++)
        {
            MakeFace(i);
        }
    }

    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();
    }
}
