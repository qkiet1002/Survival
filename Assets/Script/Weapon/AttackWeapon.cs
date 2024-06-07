using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWeapon : MonoBehaviour
{
    public int damage = 10;
    public LayerMask whatIsPlayer;
    public GameObject bulletHoleGraphicPlayer;
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
        if (other.CompareTag("Enemy"))
        {
            setdame PlayerDame = other.GetComponent<setdame>();
            if (PlayerDame != null)
            {
                PlayerDame.TakeDamage(damage);
            }

            if (whatIsPlayer != 0)
            {
                GameObject hole = Instantiate(bulletHoleGraphicPlayer, transform.position, Quaternion.Euler(0, 180, 0));
                Destroy(hole, 1f);
            }
        }
    }
}

