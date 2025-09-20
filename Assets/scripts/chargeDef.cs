using UnityEngine;
using System.Collections;
public class chargeDef : MonoBehaviour
{
    public float Speed;
    public int Damage;
    private bool isSpawned = true;
    public GameObject Blast;
    void Start()
    {
        StartCoroutine(spawn());
    }

    
    void Update()
    {
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<enemy1>().TakeDamage(Damage);
            
        }
        if (other.CompareTag("Boss"))
        {
            other.GetComponent<boss1>().TakeDamage(Damage);

        }
        if (other.CompareTag("BossBS"))
        {
            other.GetComponent<BSKing>().TakeDamage(Damage);

        }
        if ((other.CompareTag("wall") || other.CompareTag("door")) && isSpawned == false)
        {
            Instantiate(Blast, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private IEnumerator spawn()
    {
        yield return new WaitForSeconds(0.1f);
        isSpawned = false;

    }
}
