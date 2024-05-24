using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class TriangleFromPlane : MonoBehaviour
{
    void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();

        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[]
        {
            new Vector3(-0.6f, 0, -0.5f),  // Vertex 0 - left base
            new Vector3(0.6f, 0, -0.5f),   // Vertex 1 - right base
            new Vector3(0, 0, 1.0f)        // Vertex 2 - tip

        };

        int[] triangles = new int[]
        {
            0, 1, 2     
        };

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        meshFilter.mesh = mesh;
    }
}