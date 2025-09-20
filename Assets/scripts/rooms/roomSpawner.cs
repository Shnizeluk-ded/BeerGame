
using UnityEngine;
using System.Collections;
public class roomSpawner : MonoBehaviour
{
    public Direct direct;
    public enum Direct
    {
        up,
        down,
        left,
        right,
        none
    }
    private RoomsVariants rv;
    private int rand;
    private float rand2;
    private bool spawned = false;
    private float waitTime = 0.3f;

    void Start()
    {
        rand2 = Random.Range(0.1f, 0.2f);
        rv = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomsVariants>();
        Destroy(gameObject, waitTime);
        Invoke("Spawn", rand2);
    }

    public void Spawn()
    {
        if (spawned == false)
        {
          if(direct == Direct.up)
          {
                rand = Random.Range(0, rv.upRooms.Length);
                Instantiate(rv.upRooms[rand], transform.position, rv.upRooms[rand].transform.rotation);
          }
          if (direct == Direct.down)
          {
                rand = Random.Range(0, rv.downRooms.Length);
                Instantiate(rv.downRooms[rand], transform.position, rv.downRooms[rand].transform.rotation);
          }
          if (direct == Direct.left)
          {
                rand = Random.Range(0, rv.leftRooms.Length);
                Instantiate(rv.leftRooms[rand], transform.position, rv.leftRooms[rand].transform.rotation);
          }
          if (direct == Direct.right)
          {
                rand = Random.Range(0, rv.rightRooms.Length);
                Instantiate(rv.rightRooms[rand], transform.position, rv.rightRooms[rand].transform.rotation);
          }
            spawned = true;

        }

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("RoomPoint") && other.GetComponent<roomSpawner>().spawned && direct != Direct.none)
        {
            Destroy(gameObject);
        }
    }
    
}
