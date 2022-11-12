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
        }
    }
}
