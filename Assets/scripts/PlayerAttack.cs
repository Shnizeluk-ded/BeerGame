using UnityEngine;
using System.Collections;
using System;



public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float meleeSpeed;
    
    float timeUntilMelee;
    public float timeKD;
    public GameObject sword;
    private bool isKD = false;
    private bool isKDCharge = false;
    public GameObject slash;
    public GameObject charge;
    public Transform slashPoint;
    public GameObject chargeEffect;
    private Player player;
    public float timeKDCharge;
    [SerializeField] private float chargeSpeed;
    [SerializeField] private float chargeTime;
    [SerializeField] private float chargeTimeLimit;
    private bool isCharging;
    void Start()
    {
        player = FindObjectOfType<Player>();
        
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            sword.SetActive(false);
        }
        if(isKD == false)
        {
            if (Input.GetMouseButton(0) && chargeTime == 0)
            {
                isKD = true;
                sword.SetActive(true);
                Instantiate(slash, slashPoint.position, slashPoint.rotation);
                anim.SetTrigger("isAttack");
                StartCoroutine(swordUnActive());
                timeUntilMelee = meleeSpeed;
                StartCoroutine(onKd());
                
            }
        }
        if (Input.GetMouseButton(1) && chargeTime < chargeTimeLimit)
        {
            if(isKDCharge == false)
            {
                isCharging = true;
                if (isCharging == true)
                {
                    chargeTime += Time.deltaTime * chargeSpeed;
                }
            }
            
        }
        else if (Input.GetMouseButton(1) && chargeTime >= chargeTimeLimit)
        {
            ReleaseCharge();

        }
        if (Input.GetMouseButtonUp(1))
        {
            
            chargeTime = 0;
        }
        if (chargeTime == 0)
        {
            
            chargeEffect.SetActive(false);
            
        }
        else
        {
            
            chargeEffect.SetActive(true);
            
            
        }
    }
    
    IEnumerator swordUnActive()
    {
        yield return new WaitForSeconds(0.3f); 
        sword.SetActive(false);


    }
    IEnumerator onKd()
    {
        yield return new WaitForSeconds(timeKD);
        isKD = false;


    }

    void ReleaseCharge()
    {
        Instantiate(slash, slashPoint.position, slashPoint.rotation);
        Instantiate(charge, slashPoint.position, slashPoint.rotation);
        isCharging = false;
        chargeTime = 0;
        isKDCharge = true;
        StartCoroutine(kdCharge());
        
    }
    IEnumerator kdCharge()
    {
        yield return new WaitForSeconds(timeKDCharge);
        isKDCharge = false;


    }











}
