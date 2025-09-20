
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kolodec : MonoBehaviour
{
    public GameObject Line;
    private bool OnTrigger = false;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && OnTrigger == true)
        {
            SceneManager.LoadScene("Load1");
        }
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
