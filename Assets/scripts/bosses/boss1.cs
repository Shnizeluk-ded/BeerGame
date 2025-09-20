
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Unity.VisualScripting;
public class boss1 : MonoBehaviour
{
    public float speed;
    private float normalSpeed;
    public float speedJump;
    private Player player;
    private Rigidbody2D rb;
    public float health;
    private bool isDamaged = false;
    private SpriteRenderer sr;
    public Material defaultMaterial;
    public Material redMaterial;
    public GameObject blood;
    private Vector3 rollDir;
    private float rollSpeed;
    private bool isJumped = false;
    public float x;
    public float y;
    public float z;
    public float jumpTime;
    public GameObject bullet;
    public Transform rollT;
    private bool isAttack = false;
    private Animator anim;
    public Image hbImage;
    private float maxHp = 100f;
    public GameObject portal1;
    public GameObject portal2;
    public GameObject hpBar;
    public GameObject allKiller;
    public GameObject Tong;
    public enum State
    { 
        Normal,
        Roll
    }
    public State state;
    void Start()
    {
        maxHp = health;
        normalSpeed = speed;
        player = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

   
    void Update()
    {
        if (health <= 0)
        {
            portal1.SetActive(true);
            portal2.SetActive(true);
            hpBar.SetActive(false);
            gameObject.SetActive(false);
            allKiller.SetActive(true);
        }
        hbImage.fillAmount = health / maxHp;
        switch (state)
        {
            case State.Normal:
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                rb.linearVelocity = Vector2.zero;

                if (player.transform.position.x > transform.position.x)
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }

                
                if (!isAttack)
                {

                    int rand = Random.Range(0, 3);
                    if(rand == 0)
                    {
                        anim.SetTrigger("isJump");
                        StartCoroutine(kd());
                        isAttack = true;
                        speed = 0;
                        StartCoroutine(wfA1());
                    }
                    if (rand == 1)
                    {
                        anim.SetTrigger("isPluh");
                        StartCoroutine(kd());
                        isAttack = true;
                        speed = 0;
                        StartCoroutine(wfA2());
                    }
                    if (rand == 2)
                    {
                        Tong.SetActive(true);
                        isAttack = true;
                        StartCoroutine(wfA3());
                    }
                }


                break;

            case State.Roll:

                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speedJump * Time.deltaTime);
                if(isJumped == false)
                {
                    state = State.Normal;
                }
                
                
                break;


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
    IEnumerator Damaged()
    {
        yield return new WaitForSeconds(0.3f);
        isDamaged = false;


    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.Damage();
        }
    }
    IEnumerator Jump()
    {
        yield return new WaitForSeconds(jumpTime);
        isJumped = false;


    }
    IEnumerator kd()
    {
        yield return new WaitForSeconds(5f);
        isAttack = false;


    }
    

    private void Attack1()
    {
        state = State.Roll;
        isJumped = true;
        StartCoroutine(Jump());
    }
    IEnumerator wfA1()
    {
        yield return new WaitForSeconds(0.7f);
        speed = normalSpeed;
        Attack1();



    }
    private void Attack2()
    {
        Instantiate(bullet, rollT.position, rollT.rotation);
    }
    IEnumerator wfA2()
    {
        yield return new WaitForSeconds(0.7f);
        speed = normalSpeed;
        Attack2();



    }
    IEnumerator wfA3()
    {
        yield return new WaitForSeconds(5f);
        StartCoroutine(kd());
        Tong.SetActive(false);



    }
    
}
