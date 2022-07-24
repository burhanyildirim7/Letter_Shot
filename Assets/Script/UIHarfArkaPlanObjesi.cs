using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHarfArkaPlanObjesi : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Destroy(gameObject);
        }
    }
}
