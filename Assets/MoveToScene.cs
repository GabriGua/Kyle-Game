using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToScene : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Kyle" || collision.gameObject.name == "Mike")
        {
            scene();
        }
    }


    public void scene()
    {
       SceneManager.LoadScene(1);
    }

    public void LoadMyScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
}
