using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapAyarla : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<RectTransform>().sizeDelta=new Vector2(100,100);
    }
}
