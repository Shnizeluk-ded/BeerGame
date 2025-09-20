using UnityEngine;

public class house : MonoBehaviour
{
    public GameObject Krisha;
    private bool OnTrigger = false;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Krisha.SetActive(false);
            OnTrigger = true;

        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Krisha.SetActive(true);
            OnTrigger = false;
        }
    }
}
