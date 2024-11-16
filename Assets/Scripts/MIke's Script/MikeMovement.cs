using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class MikeMovement : MonoBehaviour
{
    //Other Scripts
    public JumpLaws JP;
    public WallsDetector WDR;
    public WallsDetector WDL;

    

    //ui
    public TextMeshProUGUI Gems;
    public int totalGems = 0;

   

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
    int e = 0;



    private void Awake()
    {
        
        Animators = GetComponent<Animator>();
        thisSprite = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
       // PlatformActifier();

        //stairs
        if (stairs)
        {
            body.velocity = new Vector2(body.velocity.x, up * speed);
        }


       

        //movement
        if (theresWall == false)
        {
            body.velocity = new Vector2(horizontal * speed, body.velocity.y);
        }

        //flip player
        if (horizontal > 0)
        {
            thisSprite.flipX = false;
            

        }
        else if (horizontal < 0)
        {
            thisSprite.flipX = true;
            

        }
        //animation controller
         if (gameObject.name == "Mike")
        {
            if (JP.canJump == true && Animators.GetBool("isRun") == false)
            {
                Animators.Play("MB_Anim");
                e = 0;
            }
            else if (JP.canJump == true && Animators.GetBool("isRun") == true)
            {
                e++;
                if (e == 1)
                {
                    Animators.Play("MB_run");
                }

            }
        }


        //wall detector
        if (JP.canJump == false && (WDR.wallDetect == true || WDL.wallDetect == true))
        {
            theresWall = true;

        }
        else
        {
            theresWall = false;

        }

    }
    public void Jump(InputAction.CallbackContext context)
    {
        if (JP.canJump == true)
        {

            if (context.performed)
            {
                Animators.Play("MB_Jump");



                body.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            }

        }

    }

    public void MovementH(InputAction.CallbackContext ctx)
    {

        horizontal = ctx.ReadValue<Vector2>().x;

        if (ctx.started)
        {
            
                Animators.Play("MB_run");
            

            Animators.SetBool("isRun", true);
        }

        if (ctx.canceled)
        {
            
                Animators.Play("MB_Anim");
            
            Animators.SetBool("isRun", false);
        }

    }

    

    public void UpStairs(InputAction.CallbackContext ctx)
    {
        up = ctx.ReadValue<Vector2>().y;
    }

    
}
