using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    
    private RoomsVariants rl;
    void Start()
    {
        rl = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomsVariants>();
        rl.rooms.Add(this.gameObject);
        RoomsVariants.rc += 1;
    }
    


}
