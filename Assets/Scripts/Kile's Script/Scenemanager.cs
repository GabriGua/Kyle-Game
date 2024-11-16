using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Scenemanager : MonoBehaviour
{

    public GameObject kyle;
    
    public Camera cam;
    float speed = 6f;
    

    private void Update()
    {
        if(kyle.transform.position.x >= -9.880001)
        {
            Vector3 pos = new Vector3(kyle.transform.position.x, 0.00999999f, -10);
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, pos, speed * Time.deltaTime);
            
            
        }
        else
        {
            Vector3 pos = new Vector3(-15.62413f, 0.00999999f, -10);
            cam.transform.position = Vector3.MoveTowards(cam.transform.position, pos, speed * Time.deltaTime);

        }

        
    }

  
    
}
