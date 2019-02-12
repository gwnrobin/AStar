using UnityEngine;
using Pathing;
using System.Collections.Generic;

public class AStarNode : MonoBehaviour, IAStarNode
{
    public Node nodeData;

    void Start()
    {
        GetComponent<Renderer>().material.SetTexture("_MainTex", nodeData.texture);
    }

    public IEnumerable<IAStarNode> Neighbours
    {
        get
        {
            throw new System.NotImplementedException();
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
