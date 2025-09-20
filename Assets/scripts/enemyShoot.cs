using UnityEngine;
using System.Collections;
public class enemyShoot : MonoBehaviour
{
    
    private float rotZ;
    public float offset;
    private Vector3 difference;
    private Player player;
    private float timeBtwShoots;
    private float startTimeBtwShoots;
    public Transform shotPoint;
    public Animator anim;
    public GameObject bullet;
    public bool isStarted = false;
    public beerserks bs;
    public enum Type
    {
        Bottle,
        BS2
    }
    public Type type;

    void Start()
    {
        player = FindObjectOfType<Player>();
        if (type == Type.BS2)
        {
            startTimeBtwShoots = 0.5f;
        }
        
    }

    
    void Update()
    {
        if (type == Type.Bottle)
        {
            startTimeBtwShoots = Random.Range(2, 4);
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
            difference = player.transform.position - transform.position;
            rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            if (timeBtwShoots <= 0 && isStarted == false)
            {

                anim.SetTrigger("isShoot");
                StartCoroutine(Shoot());
                isStarted = true;
            }
            else
            {
                timeBtwShoots -= Time.deltaTime;
            }
        }
        else if(type == Type.BS2 && bs.onRange == true)
        {
            
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
            difference = player.transform.position - transform.position;
            rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            if (timeBtwShoots <= 0)
            {
                Instantiate(bullet, shotPoint.position, shotPoint.rotation);
                timeBtwShoots = startTimeBtwShoots;

                
               
            }
            else
            {
                timeBtwShoots -= Time.deltaTime;
            }
            
        }
        
    } 
    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.7f);
        Instantiate(bullet, shotPoint.position, shotPoint.rotation);
        timeBtwShoots = startTimeBtwShoots;
        isStarted = false;
        

    }
    
}
