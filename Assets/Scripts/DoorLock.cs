using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class DoorLock : MonoBehaviour
{
    [SerializeField] private GameObject door;
    public GameObject ombra;
    public Tilemap myTileMap;
    public TileBase cel1;
    public TileBase cel2;
    public TileBase cel3;
    public TileBase cel4;
    public TileBase cel5;
    public TileBase cel6;
    public GameObject Mike;
    public ParticleSystem PS;
    [SerializeField] private GameObject key;
    [SerializeField] private GameObject selected1;

    bool interactioneZone = false;

    Vector3Int positionCel1 = new Vector3Int(53, -5, 0);
    Vector3Int positionCel2 = new Vector3Int(53, -4, 0);
    Vector3Int positionCel3 = new Vector3Int(53, -3, 0);
    Vector3Int positionCel4 = new Vector3Int(54, -3, 0);
    Vector3Int positionCel5= new Vector3Int(54, -4, 0);
    Vector3Int positionCel6 = new Vector3Int(54, -5, 0);
    private void OnMouseDown()
    {
        if(key.activeInHierarchy && selected1.activeInHierarchy)
        {
            PS.Play();
           // Mike.SetActive(true);
            door.SetActive(false);
            myTileMap.SetTile(positionCel1, cel1);
            myTileMap.SetTile(positionCel2, cel2);
            myTileMap.SetTile(positionCel3, cel3);
            myTileMap.SetTile(positionCel4, cel4);
            myTileMap.SetTile(positionCel5, cel5);
            myTileMap.SetTile(positionCel6, cel6);
            ombra.SetActive(true);
        }
        
    }

    public void Interacted(InputAction.CallbackContext ctx)
    {
        if(interactioneZone)
        {
            if(ctx.performed && key.activeInHierarchy && selected1.activeInHierarchy)
            {
                PS.Play();
                // Mike.SetActive(true);
                door.SetActive(false);
                myTileMap.SetTile(positionCel1, cel1);
                myTileMap.SetTile(positionCel2, cel2);
                myTileMap.SetTile(positionCel3, cel3);
                myTileMap.SetTile(positionCel4, cel4);
                myTileMap.SetTile(positionCel5, cel5);
                myTileMap.SetTile(positionCel6, cel6);
                ombra.SetActive(true);
                key.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if(collision.name == "Kyle")
            {
                interactioneZone = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.name == "Kyle")
            {
                interactioneZone = false;
            }
        }
    }
}
