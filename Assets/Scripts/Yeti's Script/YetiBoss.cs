using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YetiBoss : MonoBehaviour
{
    SpriteRenderer YetiRender;
    [SerializeField] private Transform Player;
    [SerializeField] private GameObject playerDetector;
    
    public bool flip;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(playerDetector, Player.position, Quaternion.identity);
        YetiRender = gameObject.GetComponent<SpriteRenderer>();
    }

    public void LookAtPlayer()
    {
        if(gameObject.transform.position.x > Player.position.x) //yeti a destra
        {
            YetiRender.flipX= true;
            flip = true;
        }
        else
        {
            YetiRender.flipX= false;
            flip = false;
        }
    }

    private void Update() //player target per i proiettili (bypass)
    {
        playerDetector.transform.position = Player.position;
    }
}