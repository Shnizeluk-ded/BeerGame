using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class AfterImage : MonoBehaviour
{
    public GameObject AfIm;
    public GameObject BS;
    void Start()
    {
        StartCoroutine(In1());
    }

    
    void Update()
    {
        
    }
    IEnumerator In1()
    {
        yield return new WaitForSeconds(0.03f);
        
        StartCoroutine(In2());


    }
    IEnumerator In2()
    {
        yield return new WaitForSeconds(0.03f);
        Instantiate(AfIm, transform.position, BS.transform.rotation);
        StartCoroutine(In1());


    }
    public void SC1()
    {
        StartCoroutine(In1());
    }
}
