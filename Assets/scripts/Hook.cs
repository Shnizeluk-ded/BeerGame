using UnityEngine;
using System.Collections;
public class Hook : MonoBehaviour
{
    private bool isFly;
    private Player player;
    public float Speed;
    public GameObject Target;
    public GameObject Hook1;
    private bool left;
    private bool right;
    public GameObject EmptyPos;
    private bool kd = true;

    void Start()
    {
        player = FindObjectOfType<Player>();
        Invoke("KdOver", 1f);
        
    }

    
    void Update()
    {
        if (!kd)
        {
            EmptyPos.SetActive(false);
            StartCoroutine(EmPos());
            left = true;
            StartCoroutine(hook());
            Target.SetActive(false);
            isFly = true;
            StartCoroutine(Left());
            kd = true;
            StartCoroutine(OnKd());
        }
        if (!isFly)
        {
            transform.position = EmptyPos.transform.position;
            
        }
        if (left)
        {
            transform.Translate(Vector2.left * Speed * Time.deltaTime);

        }

        if (right)
        {
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
        }
            Hook1.transform.rotation = Target.transform.rotation;
        /*if (Input.GetKeyDown(KeyCode.J))
        {
            EmptyPos.SetActive(false);
            StartCoroutine(EmPos());
            left = true;
            StartCoroutine(hook());
            Target.SetActive(false);
            isFly = true;
            StartCoroutine(Left());
        }*/
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isFly == true)
        {
            player.transform.position = transform.position;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && isFly == true)
        {
            player.Damage();
            StartCoroutine(Hit());

        }
        if (other.CompareTag("EmPos") && isFly == true)
        {
            isFly = false;
            left = false;
            right = false;
        }
    }

    private IEnumerator hook()
    {
        yield return new WaitForSeconds(1.15f);
        Target.SetActive(true);
        right = false;
        isFly = false;
    }
    private IEnumerator EmPos()
    {
        yield return new WaitForSeconds(0.2f);
        EmptyPos.SetActive(true);
        
    }
    private IEnumerator Left()
    {
        yield return new WaitForSeconds(0.575f);
        left = false;
        right = true;
    }
    private IEnumerator Hit()
    {
        yield return new WaitForSeconds(0.1f);
        left = false;
        right = true;
    }
    private IEnumerator OnKd()
    {
        yield return new WaitForSeconds(Random.Range(3,6));
        kd = false;
    }
    private void KdOver()
    {
        kd = false;
    }
}
