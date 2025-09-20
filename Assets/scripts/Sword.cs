using UnityEngine;

public class Sword : MonoBehaviour
{
    public float knockbackForce = 5;
    public int damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<enemy1>().TakeDamage(damage);
            other.GetComponent<knockBack>().Knockback(transform, knockbackForce);
        }
        
        else if (other.tag == "Boss")
        {
            other.GetComponent<boss1>().TakeDamage(damage);
           
        }
        else if (other.tag == "BossBS")
        {
            other.GetComponent<BSKing>().TakeDamage(damage);

        }


    }
}
