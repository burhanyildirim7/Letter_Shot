using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEfectDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Wait(0.8f));
    }
    IEnumerator Wait(float sure)
    {
        yield return new WaitForSecondsRealtime(sure);

        Destroy(gameObject);
    }


}
