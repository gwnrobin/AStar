using System.Collections.Generic;
using Pathing;
using UnityEngine;

public class Hexagon : MonoBehaviour, IAStarNode
{
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
