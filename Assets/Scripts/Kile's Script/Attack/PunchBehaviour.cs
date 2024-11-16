using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchBehaviour : MonoBehaviour
{

    Animator punch;

    private void Start()
    {
        punch = GetComponent<Animator>();
    }


    private IEnumerator OnBecameVisible()
    {
        yield return new WaitForSeconds(0.7f);
        gameObject.SetActive(false);
    }

}
