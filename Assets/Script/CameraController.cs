using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update

    public static Transform target;
    public float speed = 5f;

    private Vector3 vector3 = Vector3.zero;

    public static bool cameraMoving = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cameraMoving)
        {
            if (target)
                if(gameObject.transform.position != target.position)
                {
                    gameObject.transform.position = Vector3.SmoothDamp(target.position, target.position, ref vector3, speed * Time.deltaTime);
                }
                else
                {
                    //LevelController.yeniLeveleGecildi = true;
                    cameraMoving = false;
                }
                
        }
        
        
    }

}
