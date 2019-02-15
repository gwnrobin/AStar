using Pathing;
using System.Collections.Generic;
using UnityEngine;

public class HexaGrid : MonoBehaviour
{
    public int gridWidth = 2;
    public int gridHeight = 2;

    [SerializeField]
    private List<Node> nodes = new List<Node>();

    [SerializeField]
    private GameObject hexagon;

    public IAStarNode[,] hexagonTiles;

    float hexWidth;
    float hexHeight;

    Vector3 startPos = new Vector3(0, 0, 0);

    public void MakeGrid()
    {
        hexagonTiles = new IAStarNode[gridWidth, gridHeight];
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        GetHexagonSize();
        CalcStartPos();
        CreateGrid();
    }

    void GetHexagonSize()
    {
        hexWidth = hexagon.GetComponent<Renderer>().bounds.size.x;
        hexHeight = hexagon.GetComponent<Renderer>().bounds.size.y;
    }

    void CalcStartPos()
    {
        float offset = 0;
        if (gridHeight / 2 % 2 != 0)
            offset = hexWidth / 2;

        float x = -hexWidth * (gridWidth / 2) - offset;
        float y = hexHeight * 0.75f * (gridHeight / 2);

        startPos = new Vector3(x, y, 0);
    }

    Vector3 CalcWorldPos(Vector3 gridPos)
    {
        float offset = 0;

        if(gridPos.y % 2 != 0)
        {
            offset = hexWidth / 2;
        }
        float x = startPos.x + gridPos.x * hexWidth + offset;
        float y = startPos.y - gridPos.y * hexHeight * 0.75f;

        return new Vector3(x, y, 0);
    }

    void CreateGrid()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                GameObject hex = Instantiate(hexagon);
                Vector3 gridPos = new Vector3(x, y, 0);
                hex.transform.position = CalcWorldPos(gridPos);
                hex.transform.parent = this.transform;
                hex.name = "Hexagon " + x + "/" + y;
                hex.GetComponent<AStarNode>().SetNodeData(nodes[Random.Range(0, nodes.Count)]);

                hexagonTiles[x, y] = hex.GetComponent<IAStarNode>();
            }
        }
        IAStarNode[] hexagonNeighbours;
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                hexagonTiles[x, y].Neighbours = hexagonNeighbours[];
            }
        }
    }

    public void SetGridWidth(int gridWidth)
    {
        this.gridWidth = gridWidth;
    }
    public void SetGridHeight(int gridHeight)
    {
        this.gridHeight = gridHeight;
    }
}


