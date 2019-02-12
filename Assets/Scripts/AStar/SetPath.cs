using Pathing;
using UnityEngine;

public class SetPath : MonoBehaviour
{
    IAStarNode start;
    IAStarNode end;

    bool setStart = true;

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.GetComponent<IAStarNode>() != null)
                {
                    if(setStart)
                    {
                        start = hit.transform.gameObject.GetComponent<IAStarNode>();
                    }
                    else
                    {
                        end = hit.transform.gameObject.GetComponent<IAStarNode>();
                        SetPathing();
                    }
                    setStart = !setStart;
                }
            }
        }
    } 

    void SetPathing()
    {
        AStar.GetPath(start, end);
    }
}