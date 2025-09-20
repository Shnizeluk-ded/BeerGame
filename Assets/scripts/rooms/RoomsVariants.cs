using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class RoomsVariants : MonoBehaviour
{
    public static float rc;
    public float idk;
    public GameObject portal;
    public GameObject[] upRooms;
    public GameObject[] downRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public List<GameObject> rooms;


    private void Start()
    {
        Invoke("Minus", 2f);
    }
    void Update()
    {
        idk = rc;
        if (rc < 0)
        {
            rc = 0;
        }
        if (rc == 2)
        {
            portal.SetActive(true);
        }
        
    }
    void Minus()
    {
        rc -= 1;
    }
    
}
