using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    public static int radius;
    public static float cellSize;
    public readonly List<Vertex_hex> hexes = new List<Vertex_hex>();
    public readonly List<Triangle> triangles = new List<Triangle>();

    public Grid(int radius, float cellSize)
    {
        Grid.radius = radius;
        Grid.cellSize = cellSize;
        Vertex_hex.Hex(hexes);
        Triangle.Triangles_Hex(hexes, triangles);
    }

}
