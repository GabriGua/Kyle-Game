using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviour
{
    //Other Scripts
    public JumpLaws JP;
    public WallsDetector WDR;
    public WallsDetector WDL;

    public SpriteRenderer fisherHat;

    //ui
    public TextMeshProUGUI Gems;
    public int totalGems = 0;

    //flip
    public bool flipKyle = false;
  

    //private
    SpriteRenderer thisSprite;
    Animator Animators;
    Rigidbody2D body;

    float force = 10f;
    float up;
    float horizontal;
    float speed = 7f;

    //stairs
    public bool stairs = false;
    bool theresWall = false;

    //loops
    int i = 0;

    

    private void Awake()
    {
       
        Animators = GetComponent<Animator>();
        thisSprite= GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
       // PlatformActifier();

        //stairs
        if(stairs)
        {
            body.velocity = new Vector2(body.velocity.x, up * speed);
        }
        

        //gems
        GemsCounter();

        //movement
        if(theresWall == false)
        {
            body.velocity = new Vector2(horizontal * speed, body.velocity.y);
        }    
       
        //flip player
        if(horizontal > 0 )
        {
            thisSprite.flipX= false;
            fisherHat.flipX = false;
            
            
        }
        else if(horizontal < 0 )
        {
            thisSprite.flipX = true;
            fisherHat.flipX = true;
            

        }
        //attacckFlip
        
            if(thisSprite.flipX == false)
            {
                flipKyle= false;
            }
            else
            {
                flipKyle = true;
             }
        
        
        //animation controller
        if(gameObject.name == "Kyle" )
        {
            if (JP.canJump == true && Animators.GetBool("isRun") == false)
            {
                Animators.Play("IdleGNT");
                i = 0;
            }
            else if (JP.canJump == true && Animators.GetBool("isRun") == true)
            {
                i++;
                if (i == 1)
                {
                    Animators.Play("RunGNT");
                }

            }
        }
        
        

        //wall detector
        if(JP.canJump == false && (WDR.wallDetect == true || WDL.wallDetect == true))
        {
            theresWall = true;
            
        }
        else
        {
            theresWall= false;
            
        }
     
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if(JP.canJump == true)
        {
            
            if (context.performed)
            {
                
                    Animators.Play("JumpGNT");
                
                

               
                body.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            }

        }

    }

    public void MovementH(InputAction.CallbackContext ctx)
    {
        
            horizontal = ctx.ReadValue<Vector2>().x;

            if (ctx.started)
            {
                
                    Animators.Play("RunGNT");
                
                
                
                Animators.SetBool("isRun", true);
            }

            if (ctx.canceled)
            {
                Animators.Play("IdleGNT");
            Animators.SetBool("isRun", false);
            }

    }

    void GemsCounter()
    {
        Gems.text = "Gems : " + totalGems.ToString();
    }

    public void UpStairs(InputAction.CallbackContext ctx)
    {
        up = ctx.ReadValue<Vector2>().y;
    }

   
}
