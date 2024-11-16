using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
  
    public PlayerHealth PH;
    [SerializeField] private MikeHealth MH;
    public PlayerMovement PM;

    Animator anim;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Kyle" || collision.name == "Mike")
        {
            if(gameObject.tag == "Gems")
            {
                anim.Play("Gems");
                
            }
            else
            {
                anim.Play("Heart");

                if(collision.name == "Kyle")
                {
                    if(PH.healthAmount.fillAmount < 1)
                    {
                        PH.Healing();
                    }
                }
                else if(collision.name == "Mike")
                {
                    if(MH.healthAmount.fillAmount < 1)
                    {
                        MH.Healing();
                    }
                }
                
                
            }
           
            yield return new WaitForSeconds(1);
            if(gameObject.tag == "Gems")
            {
                PM.totalGems++;
            }
            Destroy(gameObject);
        }
    }






}
