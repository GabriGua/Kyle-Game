using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class YetiWeapon : MonoBehaviour
{
    YetiBoss YB;

    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject spawnPointBullet;
    [SerializeField] private GameObject spawnPointBulletF;

    private void Start()
    {
        YB = gameObject.GetComponent<YetiBoss>();
    }

    Vector3 vectClone;
    private void Update()
    {
        if(YB.flip)
        {
            vectClone= spawnPointBulletF.transform.position;

        }
        else
        {
            vectClone = spawnPointBullet.transform.position;
        }
        
    }

    public void Attack()
    {
        Instantiate(Bullet, vectClone, Quaternion.identity);
    }
}
