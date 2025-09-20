using UnityEngine;

public class bullet : MonoBehaviour
{
    public float Speed;
    public float SpeedFly;
    private Player player;
    public GameObject blood;
    private bool fly = true;
    private Rigidbody2D rb;
    private Vector2 ShootDirection;
    private BSKing bs;
    private bool isOver = false;
    public enum BulletType
    {
        Def,
        BSSword
    }
    public BulletType et;
    void Start()
    {
        bs = FindObjectOfType<BSKing>();
        player = FindObjectOfType<Player>();
        if (et == BulletType.Def)
        {
            Destroy(gameObject, 6f);
        }
        else
        {
            
            Invoke("FlyOver", 0.1f);
            Invoke("Over", 5f);
        }
        rb = GetComponent<Rigidbody2D>();
        ShootDirection = player.transform.position;
        rb.velocity = ShootDirection * Speed;

    }


    void Update()
    {
        
        if (et == BulletType.Def)
        {

            transform.Translate(Vector2.left * SpeedFly * Time.deltaTime);
        }
        
        else
        {
            if (isOver)
            {
                transform.position = Vector2.MoveTowards(transform.position, bs.transform.position, SpeedFly * Time.deltaTime);
            }
            
        }
        ShootDirection = player.transform.position;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && player.state == Player.State.Normal)
        {
            other.GetComponent<Player>().Damage();
            if (et == BulletType.Def)
            {
                Destroy(gameObject);
            }
            if (et == BulletType.BSSword)
            {
                
                    rb.velocity = ShootDirection * Speed;
                
                
            }

        }
        
        if (other.CompareTag("BossBS"))
        {

            if (isOver)
            {
                Destroy(gameObject);
                bs.Sword.SetActive(true);

            }
            else
            {
                rb.velocity = ShootDirection * Speed;
            }

        }
        if (other.CompareTag("wall") || other.CompareTag("door"))
        {
            
            if (et == BulletType.Def)
            {
                Destroy(gameObject);
            }
        }
    }
    private void FlyOver()
    {
        fly = false;
    }
    private void Over()
    {
        rb.velocity = Vector2.zero;
        isOver = true;
    }
}
