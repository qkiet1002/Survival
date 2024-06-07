using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class setdame : MonoBehaviour
{
    Animator animator;
    public thanhmau Thanhmau;
    [SerializeField] private float thisHP;
    [SerializeField] private float MaxHP = 100;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //thisHP = gameseasion.CapNhatMau();
        //hp
        thisHP = MaxHP;
        Thanhmau.UpdateHP(thisHP, MaxHP);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int amout)
    {
        thisHP -= amout;
        Thanhmau.UpdateHP(thisHP, MaxHP);
        if (thisHP <= 0)
        {
            animator.SetTrigger("die");
            Destroy(gameObject, 5f);
        }
    }
  /*  private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dan"))
        {
           // Dame();
            thisHP -= 10;
            Thanhmau.UpdateHP(thisHP, MaxHP);
        }
        if (thisHP < 1)
            {
                animator.SetTrigger("die");
                Destroy(gameObject, 5f);
            }


    }*/
}
