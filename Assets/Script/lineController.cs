using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineController : MonoBehaviour
{
    private LineRenderer Lr;
    private List<Transform> points = new List<Transform>();
    [SerializeField] GameObject Player;
    private bool Basla;

    private void Awake()
    {
        Basla = false;
           Lr = GetComponent<LineRenderer>();
    }


    public void SetUpLine(Transform points) 
    {
        Lr.positionCount++;
        this.points.Add(points);
        //this.points.Add(Player.transform);
       // Basla = true;
    }
    private void Update()
    {
       if (points.Count>1 && Input.GetMouseButton(0))
       {
            //points[points.Count]= Player.transform;
            for (int i = 0; i <= points.Count; i++)
            {
                if (i < points.Count)
                {
                    Lr.SetPosition(i, points[i].position);
                }
                else
                {

                    Lr.SetPosition(i, Player.transform.position);
                }
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Lr.positionCount=1;
        }
        if (Input.GetMouseButtonUp(0))
        {
           // Lr.positionCount = 0;
            Lr.positionCount =0;
            for (int i = 0; i < points.Count; i++)
            {
                Destroy(points[i].gameObject);
            }
            points.Clear();
        }

    }
}
