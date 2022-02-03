using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class mesh : MonoBehaviour
{
    MeshFilter mf;
    Vector3[] point;
    public Vector3 p;
    public Vector2 p1;
    public List<Vector3> v = new List<Vector3>();
    public List<Vector2> uv = new List<Vector2>();
    public List<int> t = new List<int>();
    private void Awake()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        for (int i = 0; i < 10; i++)
        {
            for (int y = 0; y < 10; y++)
            {
                v.Add(new Vector3(y, i));
            }
        }

        float b = v.Count;
        for (int i = 0; i < v.Count; i++)
        {
            float a = i;
            uv.Add(new Vector2(a / b, a / b));
        }
        for (int i = 0; i < v.Count / 2; i++)
        {
            if (i == 0)
            {
                t.Add(i);
                t.Add(i + 1);
                t.Add(i + 10);
            }
            else
            {
                t.Add(i);
                t.Add(i + 10);
                t.Add(i + 9);
                t.Add(i);
                t.Add(i + 1);
                t.Add(i + 10);
            }
        }
        mesh.vertices = v.ToArray();
        mesh.uv = uv.ToArray();
        mesh.triangles = t.ToArray();
        mesh.RecalculateNormals();
    }
    private void Update()
    {
        //Mesh mesh = GetComponent<MeshFilter>().mesh;
        //mesh.Clear();
        //mesh.vertices = new Vector3[] {new Vector3(-2,0),new Vector3(0,0),new Vector3(2,0),new Vector3(-2,1), new Vector3(0, 1), new Vector3(2, 1), new Vector3(-0.5f, 1), new Vector3(0.5f, 1),
        //    new Vector3(-0.5f, 2),new Vector3(0.5f, 2), new Vector3(-0.5f, 3),new Vector3(0.5f, 3)};

       
        //mesh.vertices = new Vector3[]
        //{
        //    new Vector3(-2,0),
        //    new Vector3(0,0),
        //    new Vector3(-2,1),
        //    new Vector3(0,1),
        //};
        //mesh.uv = new Vector2[] { new Vector2(0.1f, .5f), new Vector2(0.2f, 0.5f), new Vector2(0.3f, 0.5f), new Vector2(0.4f, 0.5f) };
        //mesh.triangles = new int[] 
        //{ 0, 3, 1,
        //    4,3,1,
        //    1,2,4,
        //    4,2,5,
        //    6,7,8,
        //    8,9,7,
        //    8,9,10,
        //    9,10,11
        //};
        //mesh.triangles = new int[]
        //{
        //    0,1,2,
        //    1,3,2
        //};
    }
}