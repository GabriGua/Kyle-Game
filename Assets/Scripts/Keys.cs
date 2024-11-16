using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public GameObject key;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Kyle" || collision.name == "Mike")
        {
            key.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
