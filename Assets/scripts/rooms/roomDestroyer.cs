using UnityEngine;

public class roomDestroyer : MonoBehaviour
{
    public bool isBaked = false;
    public GameObject room;
    public Type type;
    public enum Type
    {
        other,
        main


    }
    void Start()
    {
        Invoke("Bake", 0.1f);
        if(type == Type.main)
        {
            isBaked = true;
        }
    }

    public void Bake()
    {
        isBaked = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RoomDes"))
        {
            if (other.GetComponent<roomDestroyer>().isBaked == false && isBaked == true)
            {
                Destroy(other.GetComponent<roomDestroyer>().room);
            }
        }
    }
}
