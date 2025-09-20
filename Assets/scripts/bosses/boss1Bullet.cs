using UnityEngine;

public class boss1Bullet : MonoBehaviour
{
    public GameObject blast;
    public GameObject enemy;
    private Player player;
    public float Speed;
    private int zv = 0;

   
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime);
        if(zv == 1 || zv == 2)
        {
            Instantiate(blast, transform.position, Quaternion.identity);
            Instantiate(enemy, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && player.state != Player.State.Roll)
        {
           
            player.Damage();
            Instantiate(blast,transform.position,Quaternion.identity);
            Instantiate(enemy, transform.position, Quaternion.identity);
            Destroy(gameObject);
            
        }
        else if (other.CompareTag("wall") || other.CompareTag("door"))
        {
            zv++;
            
        }
    }
}
