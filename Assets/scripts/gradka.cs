using UnityEngine;

public class gradka : MonoBehaviour
{
    public GameObject Line;
    private bool OnTrigger = false;
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Line.SetActive(true);
            OnTrigger = true;

        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Line.SetActive(false);
            OnTrigger = false;
        }
    }
}
