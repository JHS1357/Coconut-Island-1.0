using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    MinimapIcon myMinimapicon = null;
    [Header("Move")]
    public float moveSpeed = 4.0f;
    public float SmoothMoveSpeed = 5.0f;


    //public GameObject[] weapons;
    //public bool[] hasWeapons;

    public enum WeaponType { Melee, Range };

    [Header("Weapon")]
    public WeaponType MyWeapon;
    //public bool joyStickType = true;    //기본 무기에 따라?
    [Tooltip("양손 조작")]
    public GameObject JoyStick_Double;
    [Tooltip("한손 조작")]
    public GameObject JoyStick_Single;

    Animator anim;


    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        GameObject obj = Instantiate(Resources.Load("Prefabs/MiniMapIcon") as GameObject);
        myMinimapicon = obj.GetComponent<MinimapIcon>();
        myMinimapicon.Initalize(this.transform);
        myMinimapicon.myColor = Color.blue;

        Init();
    }
    //void Start()
    //{
        

    //}

    void Init()
    {
        MyWeapon = WeaponType.Melee;
        JoyStick_Double.SetActive(false);
        JoyStick_Single.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        switch(MyWeapon)
        {
            case WeaponType.Melee:
                JoyStick_Double.SetActive(false);
                JoyStick_Single.SetActive(true);
                break;

            case WeaponType.Range:
                JoyStick_Double.SetActive(true);
                JoyStick_Single.SetActive(false);
                break;
        }
        
    }
    public void Attack()
    {
        anim.SetTrigger("doSwing");
    }
}
