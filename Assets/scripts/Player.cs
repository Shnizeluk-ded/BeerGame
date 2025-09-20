using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Player : MonoBehaviour
{
    public float speed;
    public float normalSpeed;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    private bool facingRight = true;
    private Animator anim;
    private bool isDash;
    private Vector3 rollDir;
    private float rollSpeed;
    public float x;
    public float y;
    public float z;
    private bool isRoll = false;
    public static float health = 10;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    private bool isDamaged = false;
    private SpriteRenderer sr;
    public Material defaultMaterial;
    public Material redMaterial;
    public GameObject blood;
    private PlayerAttack pa;
    private float knockbackForce = 5;
    public static bool isCut = false;

    public enum State
    { 
        Normal,
        Roll
    }
    public State state;

    
    public void Start() 
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        state = State.Normal;
        sr = GetComponent<SpriteRenderer>();
        normalSpeed = speed;
        pa = FindObjectOfType<PlayerAttack>();
    }
    public void Update()
    {
        if (isCut == true)
        {
            speed = 0;
            
        }
        else if (isCut == false)
        {
            speed = normalSpeed;
        }
        if (health < 0)
        {
            health = 0;
        }
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        for(int i = 0; i < hearts.Length; i++)
        {
            if (i < Mathf.RoundToInt(health))
            {
                hearts[i].sprite = fullHeart;
                
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i< numOfHearts)
            {
                hearts[i].enabled = true;
                
            }
            else
            {
                hearts[i].enabled = false;
                
            }
        }

        switch (state)
        {
            case State.Normal:


                    moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                    moveVelocity = moveInput.normalized * speed;


                    if (moveInput.x == 0 & moveInput.y == 0)
                    {

                        anim.SetBool("isRunning", false);


                    }
                    else
                    {

                        anim.SetBool("isRunning", true);

                    }

                    if (!facingRight && moveInput.x > 0)
                    {
                        Flip();
                    }
                    else if (facingRight && moveInput.x < 0)
                    {
                        Flip();
                    }


                    if (Input.GetKeyDown(KeyCode.Space) && isDash == false)
                    {
                        if (moveInput.x != 0 || moveInput.y != 0)
                        {

                            anim.SetTrigger("roll");


                        }

                        isDash = true;
                        StartCoroutine(Dash());
                        rollDir = moveVelocity;
                        rollSpeed = x;
                        state = State.Roll;
                    }
                
                
                   
                break;
            case State.Roll:
                float rollSpeedDrop = y;
                rollSpeed -= rollSpeed * rollSpeedDrop * Time.deltaTime;
                moveVelocity = rollDir * rollSpeed;
                float rollMed = z;
                if (rollSpeed < rollMed)
                {
                    state = State.Normal;
                }
                break;
        }
    }
    public void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
    private void Flip()
    {
        
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        
       
    }
    private IEnumerator Dash()
    {
        yield return new WaitForSeconds(1f);
        isDash = false;
        
    }
    public void Damage()
    {
        if(isDamaged == false && state == State.Normal)
        {
            health--;
            isDamaged = true;
            sr.material = redMaterial;
            StartCoroutine(red());
            StartCoroutine(damaged());
            Instantiate(blood, transform.position, Quaternion.identity);
            
        }
        
    }
    private IEnumerator red()
    {
        yield return new WaitForSeconds(0.1f);
        sr.material = defaultMaterial;
        yield return new WaitForSeconds(0.1f);
        sr.material = redMaterial;
        yield return new WaitForSeconds(0.1f);
        sr.material = defaultMaterial;
        yield return new WaitForSeconds(0.1f);
        sr.material = redMaterial;
        yield return new WaitForSeconds(0.1f);
        sr.material = defaultMaterial;
        yield return new WaitForSeconds(0.1f);
        sr.material = redMaterial;
        yield return new WaitForSeconds(0.1f);
        sr.material = defaultMaterial;
        yield return new WaitForSeconds(0.1f);
        sr.material = redMaterial;
        yield return new WaitForSeconds(0.1f);
        sr.material = defaultMaterial;

    }
    private IEnumerator damaged()
    {
        yield return new WaitForSeconds(1.5f);
        isDamaged = false;

    }
    
}

