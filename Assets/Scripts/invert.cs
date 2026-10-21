using UnityEngine;
using System.Linq;

[RequireComponent(typeof(MeshFilter))]
public class InvertedSphere : MonoBehaviour
{
    void Awake()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter == null) return;

        // Clone the mesh so you don't break the original asset
        Mesh mesh = Instantiate(meshFilter.sharedMesh);
        meshFilter.mesh = mesh;

        // 1. Invert Normals
        Vector3[] normals = mesh.normals;
        for (int i = 0; i < normals.Length; i++)
        {
            normals[i] = -normals[i];
        }
        mesh.normals = normals;

        // 2. Reverse Triangles (Clockwise to Counter-Clockwise)
        int[] triangles = mesh.triangles;
        for (int i = 0; i < triangles.Length; i += 3)
        {
            int temp = triangles[i + 1];
            triangles[i + 1] = triangles[i + 2];
            triangles[i + 2] = temp;
        }
        mesh.triangles = triangles;

        // 3. Fix UVs so textures aren't mirrored horizontally
        Vector2[] uvs = mesh.uv;
        for (int i = 0; i < uvs.Length; i++)
        {
            uvs[i].x = 1f - uvs[i].x;
        }
        mesh.uv = uvs;

    }
}