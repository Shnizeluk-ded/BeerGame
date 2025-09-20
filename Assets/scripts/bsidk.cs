using UnityEngine;
using System.Collections;
public class bsidk : MonoBehaviour
{
    public Animator anim;
    private bool onKd = false;
    public GameObject Slash;
    public Transform SlashPoint;
    private Player player;
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

   
    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            if (!onKd)
            {
                anim.SetTrigger("Attack");
                player.Damage();
                onKd = true;
                Instantiate(Slash,SlashPoint.position, SlashPoint.rotation);
                StartCoroutine(kd());
            }
            

        }

    }
    IEnumerator kd()
    {
        yield return new WaitForSeconds(2f);
        onKd = false;


    }
}
