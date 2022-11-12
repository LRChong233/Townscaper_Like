using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triangle
{
    public readonly Vertex_hex a;
    public readonly Vertex_hex b;
    public readonly Vertex_hex c;

    public Triangle(Vertex_hex a, Vertex_hex b, Vertex_hex c, List<Triangle> triangles)
    {
        this.a = a;
        this.b = b;
        this.c = c;

        triangles.Add(this);
    }

    public static void Triangles_Ring(int radius, List<Vertex_hex> vertices, List<Triangle> triangle)
    {
        List<Vertex_hex> inner = Vertex_hex.GrabRing(radius - 1, vertices);
        List<Vertex_hex> outer = Vertex_hex.GrabRing(radius, vertices);
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < radius; j++)
            {
                //创建两个顶点在外圈，一个顶点在内圈的三角形
                Vertex_hex a = outer[i * radius + j];
                Vertex_hex b = outer[(i * radius + j + 1) % outer.Count];
                Vertex_hex c = inner[(i * (radius - 1) + j) % inner.Count];
                new Triangle(a, b, c, triangle);
                //创建一个顶点在外圈，两个顶点在内圈的三角形
                if (j > 0)
                {
                    Vertex_hex d = inner[i * (radius - 1) + j - 1];
                    new Triangle(a, c, d, triangle);
                }
            }
        }
    }

    public static void Triangles_Hex(List<Vertex_hex> vertices, List<Triangle> triangles)
    {
        for (int i = 1; i < Grid.radius; i++)
        {
            Triangles_Ring(i, vertices, triangles);
        }
    }
    
}
