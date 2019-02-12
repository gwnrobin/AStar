using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField]
    private GameObject input2;
    [SerializeField]
    private GameObject input3;
    [SerializeField]
    private GameObject hexGrid;
    [SerializeField]
    private GameObject button;



    void Start()
    {
        button.GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        HexaGrid hexaGrid = hexGrid.GetComponent<HexaGrid>();
        hexaGrid.SetGridWidth(float.Parse(input2.GetComponent<InputField>().text));
        hexaGrid.SetGridHeight(float.Parse(input3.GetComponent<InputField>().text));
        hexaGrid.MakeGrid();
    }
}
