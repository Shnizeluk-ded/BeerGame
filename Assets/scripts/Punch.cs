using UnityEngine;
using System.Collections;

public class Punch : MonoBehaviour
{
    public float offset;
    private bool isFollow = true;
    public float timeKD;
    private bool isKD = false;
    private Player player;
    public Camera cam;

    void Start()
    {
        
        player = FindObjectOfType<Player>();
    }
    void Update()
    {
        transform.position = player.transform.position;
        if(isFollow == true)
        {
            Vector3 difference = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        }

        if (isKD == false)
        {
            if (Input.GetMouseButton(0))
            {
                isKD = true;
                isFollow = false;
                StartCoroutine(swordUnActive());
                StartCoroutine(onKd());
            }
        }
        

    }

    IEnumerator swordUnActive()
    {
        yield return new WaitForSeconds(0.3f);
        isFollow = true;


    }
    IEnumerator onKd()
    {
        yield return new WaitForSeconds(timeKD);
        isKD = false;


    }
}
