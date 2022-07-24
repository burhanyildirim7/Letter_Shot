using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHarfScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            transform.GetComponent<BoxCollider>().isTrigger = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            transform.GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}
