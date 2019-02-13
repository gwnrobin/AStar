using UnityEngine;
using Pathing;
using System.Collections.Generic;

public class AStarNode : MonoBehaviour, IAStarNode
{
    private Node nodeData;

    void Start()
    {
        GetComponent<Renderer>().material.SetTexture("_MainTex", nodeData.texture);
    }

    public void SetNodeData(Node Data)
    {
        nodeData = Data;
    }

    public IEnumerable<IAStarNode> Neighbours
    {
        set
        {
            Neighbours = value;
        }
        get
        {
            return Neighbours;
        }
    }

    public float CostTo(IAStarNode neighbour)
    {
        throw new System.NotImplementedException();
    }

    public float EstimatedCostTo(IAStarNode goal)
    {
        throw new System.NotImplementedException();
    }
}
