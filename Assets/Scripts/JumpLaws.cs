using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpLaws : MonoBehaviour
{
    public Animator KyleAnimator;
    public bool canJump = true;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Collider")
        {
            canJump = true;
            KyleAnimator.SetBool("hasJump", false);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Collider")
        {
            canJump = false;
            KyleAnimator.SetBool("hasJump", true);
        }
        
       
        

      
    }
}
