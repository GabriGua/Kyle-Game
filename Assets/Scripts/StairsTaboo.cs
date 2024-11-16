using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsTaboo : MonoBehaviour
{
    public PlayerMovement PM;
    public MikeMovement MM;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Kyle")
        {
            PM.stairs = true;
        }
        else if(collision.gameObject.name == "Mike")
        { 
            MM.stairs = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Kyle")
        {
            PM.stairs = false;
        }
        else if (collision.gameObject.name == "Mike")
        {
            MM.stairs = false;
        }
    }
}
