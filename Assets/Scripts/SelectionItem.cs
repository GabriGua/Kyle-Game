using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectionItem : MonoBehaviour
{
    InputControl control;
    [SerializeField] private GameObject item1;
    [SerializeField] private GameObject item2;
    [SerializeField] private GameObject item3;
    Animator item1Anim;
    Animator item2Anim;
    Animator item3Anim;

    

    private void Awake()
    {
        item1Anim = item1.GetComponent<Animator>();
        item2Anim = item2.GetComponent<Animator>();
        item3Anim = item3.GetComponent<Animator>();
    }

   

    public void cotestItem(InputAction.CallbackContext ctx)
    {
        


        if(ctx.performed)
        {
            control = ctx.control;
            Debug.Log("ciao00");
            if(control.name == "1")
            {coclickItem();
                item1.SetActive(true);
                item1Anim.Play("Selection");
                
            }
            else if(control.name == "2")
            {coclickItem();
                item2.SetActive(true);
                item2Anim.Play("Selection");
                
            }
            else if(control.name == "3")
            {coclickItem();
                item3.SetActive(true);
                item3Anim.Play("Selection");
                
            }
        }
        
        
    }
    public void coclickItem()
    {
        StartCoroutine(ClickItem());
    }
   

    IEnumerator ClickItem()
    {
        if (item1.activeInHierarchy)
        {
            item1Anim.Play("Unselection");
            yield return new WaitForSeconds(0.3f);
            item1.SetActive(false);
        }
        else if(item2.activeInHierarchy )
        {
            item2Anim.Play("Unselection");
            yield return new WaitForSeconds(0.3f);
            item2.SetActive(false);
        }
        else if(item3.activeInHierarchy )
        {
            item3Anim.Play("Unselection");
            yield return new WaitForSeconds(0.3f);
            item3.SetActive(false);
        }
        else
        {
            Debug.Log("first");
        }

        yield return new WaitForSeconds(0.9f);
        if ((item1.activeInHierarchy && item2.activeInHierarchy) || (item2.activeInHierarchy && item3.activeInHierarchy) || (item3.activeInHierarchy && item1.activeInHierarchy))
        {
            item1Anim.Play("Unselection");
            item2Anim.Play("Unselection");
            item3Anim.Play("Unselection");
            yield return new WaitForSeconds(0.3f);
            item1.SetActive(false);
            item2.SetActive(false);
            item3.SetActive(false);
        }

    }

    

    
}
