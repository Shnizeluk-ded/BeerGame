using UnityEngine;

public class RoomDestroyer : MonoBehaviour
{
    public bool isBaked = false;
    private void Start()
    {
        Invoke("Bake", 0.5f);
    }
    private void Bake()
    {
        isBaked = true;
    }
}

