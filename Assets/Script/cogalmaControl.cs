using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cogalmaControl : MonoBehaviour
{

    [SerializeField] private lineController line;
    [SerializeField] GameObject CogalacakObj;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider>().isTrigger = true;

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("içerdeyim");
            GetComponent<BoxCollider>().isTrigger = false;
            //LineTesting.pointsObj.Add(Instantiate(CogalacakObj, transform.position, Quaternion.identity));
            //line.SetUpLine(LineTesting.points);
            line.SetUpLine(Instantiate(CogalacakObj, transform.position, Quaternion.identity).transform);
            
        }
    }
}
