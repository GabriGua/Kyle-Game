using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private ParticleSystem smoke;
    SpriteRenderer SPkyle;
    public Image healthAmount;

    float health;
    float damage = 10;
    float healing = 10;

    public bool collide = false;

    private void Awake()
    {
        SPkyle = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        health = 100;
    }

    // Update is called once per frame
    void Update()
    {
        healthAmount.fillAmount = health / 100;
        if(health == 0)
        {
            SPkyle.color = Color.black;
        }
    }

    public IEnumerator Damage() 
    { 
        while(health > 0 && collide == true)
        {
            health = health - damage;
            yield return new WaitForSeconds(0.8f);
        }
        
      
        
    }

    public void Healing() 
    {
        health = health + healing;
    }

    public void Smoke()
    {
        smoke.Play();
    }

    public void SmokeD()
    {
        smoke.Stop();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider != null)
        {
            if(collision.collider.tag == "Bullet")
            {
                Debug.Log("Ahia");
                health = health - damage;
            }
        }
    }
}
