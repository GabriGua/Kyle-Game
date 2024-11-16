using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YetiHealth : MonoBehaviour
{
    public Image healthAmount;
    float health;
    Animator yetiAnim;

    void Start()
    {
        health = 100;
        yetiAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        healthAmount.fillAmount = health / 100;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null)
        {
            if(collision.collider.tag  == "Punch")
            {
                if(health > -10)
                {
                    Hit();

                }
                
            }
        }
    }

    
    void Hit()
    {
        if(health > 0)
        {
            health = health - 20;
        }
        else
        {
            yetiAnim.Play("YT_Dead");
        }
    }
}
