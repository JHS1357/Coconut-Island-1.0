using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInvenCtrl : MonoBehaviour
{
    static public WeaponInvenCtrl instance;
    public int WeaponCount = 4;
    public bool[] usingWeapon = new bool[4];
    public Color usableWeapon = Color.blue;
    public Color unusableWeapon = Color.gray;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        for (int i = 0; i < WeaponCount; i++) 
        {
            usingWeapon[i] = false;
        }
        usingWeapon[0] = true;

        SetWeaponInventoryImage();
    }



    public void SwapWeapon(int index)
    {
        if (usingWeapon[index] == false)
        {
            //무기교체신호 주기.
            Debug.Log(index);
            usingWeapon[index] = true;
        }

        for (int i = 0; i < WeaponCount; i++)
        {
            if (i != index)
                usingWeapon[i] = false;
        }

        SetWeaponInventoryImage();
    }

    void SetWeaponInventoryImage()
    {
        for (int i = 0; i < WeaponCount; i++)
        {
            if (usingWeapon[i] == true)
                this.transform.GetChild(i).GetComponent<Image>().color = unusableWeapon;
            else
                this.transform.GetChild(i).GetComponent<Image>().color = usableWeapon;
        }
    }
}
