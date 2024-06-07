using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject weapon;
    public void EnableWeaponCollider(int isEnable)
    {
        var col = weapon.GetComponentInChildren<MeshCollider>();
        if (col != null)
        {
            if (isEnable == 1)
            {
                col.enabled = true;
            }
            else
            {
                col.enabled = false;
            }
        }
    }
}
