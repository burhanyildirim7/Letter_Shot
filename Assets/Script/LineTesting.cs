using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineTesting : MonoBehaviour
{
    public static List<Transform> points = new List<Transform>();
    public static List<GameObject> pointsObj = new List<GameObject>();
    [SerializeField] List<GameObject> HedefObj = new List<GameObject>();
    [SerializeField] private lineController line;

    private void Start()
    {
       
    }
    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
           
        }
       
        if (Input.GetMouseButton(0))
        {
            for (int i = 0; i < pointsObj.Count; i++)
            {
                points[i] = pointsObj[i].transform;
            }

            //line.SetUpLine(points);
        }

        if (Input.GetMouseButtonUp(0))
        {

           for (int i = 0; i < HedefObj.Count; i++)
            {
                HedefObj[i].GetComponent<BoxCollider>().isTrigger=true;
            }
            for (int i = 0; i < pointsObj.Count; i++)
            {
                
                Destroy(pointsObj[i].gameObject);
            }
            pointsObj.Clear();
        }

         
    }
}

