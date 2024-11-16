using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    PlayerMovement PM;

    [SerializeField] private GameObject spawnPunchF;
    [SerializeField] private GameObject spawnPunchB;
    Animator kyleAnim;
    Animator PunchFAnim;
    Animator PunchBAnim;
    
  
    void Start()
    {
        PM = gameObject.GetComponent<PlayerMovement>();
       kyleAnim= GetComponent<Animator>();
        PunchFAnim= spawnPunchF.GetComponent<Animator>();
        PunchBAnim= spawnPunchB.GetComponent<Animator>();
    }

    private void Update()
    {
        if(spawnPunchF.activeInHierarchy)
        {
            spawnPunchB.SetActive(false);
        }
        if (spawnPunchB.activeInHierarchy)
        {
            spawnPunchF.SetActive(false);
        }

       
    }

    public void Attack(InputAction.CallbackContext ctx)
    {
        kyleAnim.Play("AttackGNT");
      


        if(ctx.performed)
        {
            if(PM.flipKyle == false)
            {
                if(spawnPunchF.activeInHierarchy)
                {
                    
                }
                else
                {   
                    spawnPunchF.SetActive(true);
                    PunchFAnim.Play("PunchAttack");

                }
                
                
            }
            else
            {
                if(spawnPunchB.activeInHierarchy)
                {
                    
                }
                else
                {
                    spawnPunchB.SetActive(true);
                    PunchBAnim.Play("BackPunch");
                }
               
                
            }
        }
    }
}
