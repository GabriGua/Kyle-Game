using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour
{
    [SerializeField] private PlayerHealth PH;
    [SerializeField] private MikeHealth MH;
    public bool collide = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Kyle")
        {
            PH.collide = true;
            PH.StartCoroutine(PH.Damage());
        }
        else if(collision.name == "Mike")
        {
            MH.collide = true;
            MH.StartCoroutine(MH.Damage());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Kyle")
        {
            PH.Smoke();
        }
        else if(collision.name == "Mike")
        {
            MH.Smoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.name == "Kyle")
        {
            PH.collide = false;
            PH.SmokeD();
        }
        else if(collision.name == "Mike")
        {
            MH.collide = false;
            MH.SmokeD();
        }
    }

}
