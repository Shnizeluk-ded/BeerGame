using TreeEditor;
using UnityEngine;
using System.Collections;

public class beerserks : MonoBehaviour
{
    private Player player;
    public Animator anim;
    public float speed1 = 1;
    public float speed2 = 1;
    [HideInInspector] public bool onRange;
    public enum State
    {
        one,
        two
    }
    public State state;
    public enum Type
    {
        bs1,
        bs2
    }
    public Type type;
    
    void Start()
    {
        
        player = FindObjectOfType<Player>();
        
    }



    private void OnTriggerStay2D(Collider2D other)
    {
        if (type == Type.bs2)
        {
            if (other.CompareTag("Player"))
            {
                speed2 = 0;
                onRange = true;
            }
        }
        if (state == State.one && type == Type.bs1)
        {
            if (other.CompareTag("Player"))
            {
                anim.SetBool("isReady", true);
                speed1 = 2.2f;
            }
        }
       
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (state == State.one && type == Type.bs1)
        {
            if (other.CompareTag("Player"))
            {
                anim.SetBool("isReady", false);
                speed1 = 1;
            }
        }
        if (type == Type.bs2)
        {
            if (other.CompareTag("Player"))
            {
                onRange = false;
                speed2 = 1;
            }
        }
    }
    private void OnTriggerEnter2D(Collider other)
    {
        if (state == State.two && type == Type.bs1)
        {
            if (other.CompareTag("Player"))
            {
                anim.SetTrigger("Attack");
               
            }
        }
    }
}
