using UnityEngine;
using System.Collections;
public class Spawner : MonoBehaviour
{
    public GameObject MicroChel;
    private bool isSpawned = false;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (!isSpawned)
        {
            isSpawned = true;
            anim.SetTrigger("Spawn");
            StartCoroutine(Spawn());
            StartCoroutine(SpawnKD());
        }
    }
    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(0.4f);
        Instantiate(MicroChel, transform.position, Quaternion.identity);

    }
    private IEnumerator SpawnKD()
    {
        yield return new WaitForSeconds(4f);
        isSpawned = false;

    }
}
