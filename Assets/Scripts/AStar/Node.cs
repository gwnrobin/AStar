using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "HexagonData", menuName = "Hexagon", order = 1)]
public class Node : ScriptableObject
{
    public string hexagonName = "New hexagon";
    public int value = 0;
    public Texture2D texture = null;
}
