using UnityEngine;
using System.Collections;
public class Tong : MonoBehaviour
{
    public GameObject BossTongPos;
    private Player player;
    public Animator anim;
    void Start()
    {
        player = FindObjectOfType<Player>();
        StartCoroutine(Off());
        
    }

    
    void Update()
    {
        transform.Rotate(0, 0, 1);
        transform.position = BossTongPos.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.Damage();
        }
    }
    IEnumerator Off()
    {
        yield return new WaitForSeconds(4.8f);
        anim.SetTrigger("TongOff");



    }
}
