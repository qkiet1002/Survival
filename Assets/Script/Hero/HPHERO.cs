using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPHERO : MonoBehaviour
{
    public Image thanhHP;
    [SerializeField] private Text hpText;

    public void UpdateHP(float thisHP, float MaxHP)
    {
        //thisHP = gameseasion.CapNhatMau();
        thanhHP.fillAmount = thisHP / MaxHP;
        //gameseasion.ReceiveMau(MaxHP);
        hpText.text = "HP: " + thisHP.ToString() + " / " + MaxHP.ToString();
        if (thisHP > 70)
        {
            thanhHP.color = Color.green;

        }
        else if (thisHP > 50)
        {
            hpText.color = Color.black;
            thanhHP.color = Color.yellow;

        }
        else
        {
            thanhHP.color = Color.red;

        }
    }
}
