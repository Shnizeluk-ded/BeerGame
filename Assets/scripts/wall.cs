using UnityEngine;

public class wall : MonoBehaviour
{
    public GameObject blood;
    public GameObject moover;
    public GameObject door;
    public GameObject[] torches;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Bullet"))
        {
            Instantiate(blood, other.transform.position, Quaternion.identity);
            Destroy(other);
        }
        if (other.CompareTag("door"))
        {
            torches[0].SetActive(true);
            torches[1].SetActive(true);
            door.SetActive(true);
            moover.SetActive(true);
            Destroy(gameObject);
        }

    }
    
}
