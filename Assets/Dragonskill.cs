using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragonskill : MonoBehaviour
{
    public int damage = 10;
    public LayerMask whatIsPlayer;
    public GameObject bulletHoleGraphicPlayer;
    public GameObject weapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        
        //Debug.Log(other.gameObject);
        if (other.CompareTag("Player"))
        {
            swinming  PlayerDame = other.GetComponent<swinming>();
            if (PlayerDame != null)
            {
                PlayerDame.TakeDamage(damage);
            }
            
            if(whatIsPlayer != 0)
            {
                GameObject hole = Instantiate(bulletHoleGraphicPlayer, transform.position, Quaternion.Euler(0, 180, 0));
                Destroy(hole, 1f);
            }
        }/*
        if (((1 << other.gameObject.layer) & whatIsPlayer) != 0)
        {
            swinming PlayerDame = other.GetComponent<swinming>();
            //setdame EnemyDame = other.GetComponent<setdame>();
            if (PlayerDame != null)
            {
                PlayerDame.TakeDamage(damage);
            }
          GameObject hole = Instantiate(bulletHoleGraphicPlayer, transform.position, Quaternion.Euler(0, 180, 0));
                Destroy(hole, 1f);

        }*/
    }
    public void EnableWeaponCollider(int isEnable)
    {
        var col = weapon.GetComponentInChildren<BoxCollider>();
        var col1 = weapon.GetComponentInChildren<TrailRenderer>();
        if (col != null && col1 != null)
        {
            if (isEnable == 1)
            {
                col1.enabled = true;
                col.enabled = true;
            }
            else
            {
                col1.enabled = false;
                col.enabled = false;
            }
        }
    }

}
 