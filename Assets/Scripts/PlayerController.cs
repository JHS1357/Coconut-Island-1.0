using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    MinimapIcon myMinimapicon = null;
    [Header("Move")]
    public float moveSpeed = 4.0f;
    public float SmoothMoveSpeed = 5.0f;


    public GameObject[] weapons;
    public bool[] hasWeapons;
    Weapon equipWeapon;
    float fireDelay;

    bool sDown1;
    bool sDown2;
    bool sDown3;
    bool isSwap;
    bool fDown;
    bool isFireReady;

    Rigidbody rigid;
    void Update()
    {
        GetInput();
        Swap();

        switch (MyWeapon)
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
    void GetInput()
    {
        sDown1 = Input.GetButtonDown("Swap1");
        sDown2 = Input.GetButtonDown("Swap2");
        sDown3 = Input.GetButtonDown("Swap3");
    }

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
        rigid = GetComponent<Rigidbody>();
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
    public void Attack()
    {
        equipWeapon.Use();
        anim.SetTrigger("doSwing");
    }
    public void Swap()
    {
        int weaponIndex = -1;
        if (sDown1) weaponIndex = 0;
        if (sDown2) weaponIndex = 1;
        if (sDown3) weaponIndex = 2;


        if ((sDown1 || sDown2 || sDown3))
        {
            if (equipWeapon != null)
            {
                equipWeapon.gameObject.SetActive(false);
            }
            equipWeapon = weapons[weaponIndex].GetComponent<Weapon>();
            equipWeapon.gameObject.SetActive(true);

            anim.SetTrigger("doSwap");

            isSwap = true;

            Invoke("SwapOut", 0.4f);
        }
    }
    public void SwapOut()
    {
        isSwap = false;
    }
    public void FreezeRotatoin()
    {
        rigid.angularVelocity = Vector3.zero;
    }
    void FixedUpdate()
    {
        FreezeRotatoin();
    }
}
