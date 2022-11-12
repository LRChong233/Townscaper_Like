using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField]
    private int radius;
    [SerializeField]
    private float cellSize;

    private Grid grid;
    private void Awake()
    {
        grid = new Grid(radius, cellSize);
    }

    private void Update()
    {
        grid = new Grid(radius, cellSize);
    }

    private void OnDrawGizmos()
    {
        if (grid != null)
        {
            foreach (var vertex in grid.hexes)
            {
                Gizmos.DrawSphere(vertex.coord.worldPostion, 0.3f);
            }
            Gizmos.color = Color.yellow;
            foreach (var triangle in grid.triangles)
            {
                Gizmos.DrawLine(triangle.a.coord.worldPostion, triangle.b.coord.worldPostion);
                Gizmos.DrawLine(triangle.b.coord.worldPostion, triangle.c.coord.worldPostion);
                Gizmos.DrawLine(triangle.c.coord.worldPostion, triangle.a.coord.worldPostion);
                Gizmos.DrawSphere((triangle.a.coord.worldPostion + triangle.b.coord.worldPostion + triangle.c.coord.worldPostion) / 3, 0.05f);
            }
        }
    }
}
