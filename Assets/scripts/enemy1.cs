
using UnityEngine;
using System.Collections;
public class enemy1 : MonoBehaviour
{
    public float health;
    
    public GameObject blood;
    public float speed;
    public float normalSpeed;
    private Player player;
    private Rigidbody2D rb;
    public GameObject deathEffect;
    public GameObject blast;
    public GameObject blastkb;
    private bool isDamaged = false;
    private SpriteRenderer sr;
    public Material defaultMaterial;
    public Material redMaterial;
    public enemyShoot es;
    public beerserks bs;
    private Animator anim;
    public GameObject Ghost;
    public GameObject GolemMage;
    public enum EnemyType
    {
        Bottle,
        Bomber,
        BS1,
        BS2,
        BSMicro,
        Knight,
        Golem,
        Other
    }
    public EnemyType et;
    void Start()
    {
        player = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (et == EnemyType.Golem)
        {
            if (GolemMage.GetComponent<enemy1>().health <= 0)
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        if (et == EnemyType.BS1)
        {
            speed = bs.speed1;
        }
        if (et == EnemyType.BS2)
        {
            speed = bs.speed2;
            if (bs.onRange == true)
            {
                anim.SetBool("Stay", true);
            }
            else
            {
                anim.SetBool("Stay", false);
            }
        }
        if (et == EnemyType.Bottle && es.isStarted == true)
        {
            speed = 0;
        }
        else if(et == EnemyType.Bottle && es.isStarted == false)
        {
            speed = normalSpeed;
        }
        if (health <= 0)
        {


            if (et != EnemyType.Bomber && et != EnemyType.Knight)
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            if (et == EnemyType.Knight)
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                Instantiate(Ghost, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            if (et == EnemyType.Bomber)
            {
                Instantiate(blast, transform.position, Quaternion.identity);
                Instantiate(blastkb, transform.position, Quaternion.identity);
                Destroy(gameObject);
                ScreenShake.start = true;
            }
        }
        if (knockBack.isKnock == false)
        {
            rb.linearVelocity = Vector2.zero;
        }
        
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        if(player.transform.position.x > transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else 
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
    public void TakeDamage(int damage)
    {
        if (isDamaged == false)
        {
            health -= damage;
            Instantiate(blood, transform.position, Quaternion.identity);
            sr.material = redMaterial; 
            StartCoroutine(redActive());
            isDamaged = true;
            StartCoroutine(Damaged());
        }
        
    }
    IEnumerator redActive()
    {
        yield return new WaitForSeconds(0.1f);
        sr.material = defaultMaterial;


    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && et != EnemyType.BS1 && et != EnemyType.BS2)
        {
            player.Damage();
            if (et == EnemyType.BSMicro)
            {
                health = 0;
            }
        }
        if (other.CompareTag("Player") && et == EnemyType.Bomber)
        {
            Instantiate(blast, transform.position, Quaternion.identity);
            Instantiate(blastkb, transform.position, Quaternion.identity);
            player.Damage();
            Destroy(gameObject);
            ScreenShake.start = true;
        }
        if (other.CompareTag("allKiller"))
        {
            health = 0;
        }

    }
    IEnumerator Damaged()
    {
        yield return new WaitForSeconds(0.3f);
        isDamaged = false;


    }
}
