using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMeshData : MonoBehaviour
{
    public float height = 1;
    Vector3[] vertices;

    public CubeMeshData()
    {
        vertices = new Vector3[]{
            new Vector3(1, height, 1),
            new Vector3(-1, height, 1),
            new Vector3(-1, -1, 1),
            new Vector3(1, -1, 1),
            new Vector3(-1, height, -1),
            new Vector3(1, height, -1),
            new Vector3(1, -1, -1),
            new Vector3(-1, -1, -1)};
    }

    private void Update()
    {
        vertices = new Vector3[]{
            new Vector3(1, height, 1),
            new Vector3(-1, height, 1),
            new Vector3(-1, -1, 1),
            new Vector3(1, -1, 1),
            new Vector3(-1, height, -1),
            new Vector3(1, height, -1),
            new Vector3(1, -1, -1),
            new Vector3(-1, -1, -1)};
    }

    public int[][] faceTriangles =
    {
        new int[] { 0,1,2,3 },
        new int[] { 5,0,3,6 },
        new int[] { 4,5,6,7 },
        new int[] { 1,4,7,2 },
        new int[] { 5,4,1,0 },
        new int[] { 3,2,7,6 },
    };

    public Vector3[] faceVertices(int dir)
    {
        Vector3[] fv = new Vector3[4];
        for (int i = 0; i < fv.Length; i++)
        {
            fv[i] = vertices[faceTriangles[dir][i]];
        }
        return fv;
    }
}
