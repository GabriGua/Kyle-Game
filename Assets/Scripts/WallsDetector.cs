using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsDetector : MonoBehaviour
{
    public bool wallDetect = false;

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Collider")
        {
            wallDetect = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Collider")
        {
            wallDetect = false;
         
        }
    }
}
