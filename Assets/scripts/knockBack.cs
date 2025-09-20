using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class knockBack : MonoBehaviour
{
    private Rigidbody2D rb;
    private enemy1 enemy;
    public float timeKb;
    public static bool isKnock;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = GetComponent<enemy1>();
    }
   

    public void Knockback(Transform playerTransform, float knockbackForce)
    {
        isKnock = true;
        Vector2 direction = (transform.position - playerTransform.position).normalized;
        rb.linearVelocity = direction * knockbackForce;
        StartCoroutine(kb());
    }
    IEnumerator kb()
    {
        yield return new WaitForSeconds(timeKb);
        isKnock = false;
        rb.linearVelocity = Vector2.zero;


    }

}
