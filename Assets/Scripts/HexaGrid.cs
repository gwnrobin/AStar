using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexaGrid : MonoBehaviour
{
    [SerializeField]
    GameObject hexagon;

    public float gridWidth = 2;
    public float gridHeight = 2;

    float hexWidth;
    float hexHeight;

    Vector3 startPos = new Vector3(0, 0, 0);

    public void MakeGrid()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        CalcHexagonSize();
        CalcStartPos();
        CreateGrid();
    }

    void CalcHexagonSize()
    {
        hexWidth = hexagon.GetComponent<Renderer>().bounds.size.x;
        hexHeight = hexagon.GetComponent<Renderer>().bounds.size.z;
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

        if(gridPos.z % 2 != 0)
        {
            offset = hexWidth / 2;
        }
        float x = startPos.x + gridPos.x * hexWidth + offset;
        float z = startPos.z - gridPos.z * hexHeight * 0.75f;

        return new Vector3(x, 0, z);
    }

    void CreateGrid()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int z = 0; z < gridHeight; z++)
            {
                GameObject hex = Instantiate(hexagon);
                Vector3 gridPos = new Vector3(x, 0, z);
                hex.transform.position = CalcWorldPos(gridPos);
                hex.transform.parent = this.transform;
                hex.name = "Hexagon " + x + "/" + z;
            }
        }
    }

    public void SetGridWidth(float gridWidth)
    {
        this.gridWidth = gridWidth;
    }
    public void SetGridHeight(float gridHeight)
    {
        this.gridHeight = gridHeight;
    }
}


