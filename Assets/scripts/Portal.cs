using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class Portal : MonoBehaviour
{
    private Player player;
    public GameObject Boss;
    public GameObject Cam;
    public GameObject BossHB;
    public GameObject BossCut;
    private bool first = true;
    public enum portalType
    {
        p1,
        p2,
        nextLevel
    }
    public portalType pt;
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(pt == portalType.p1)
        {
            if (other.CompareTag("Player"))
            {
                if (first)
                {
                    Player.isCut = true;
                    StartCoroutine(Cut());
                    BossCut.SetActive(true);
                    player.transform.position = new Vector3(100, 100);

                }

                if (!first)
                {
                    player.transform.position = new Vector3(100, 100);
                    Cam.transform.position = new Vector3(100, 100);
                }

            }
        }
        if (pt == portalType.p2)
        {
            if (other.CompareTag("Player"))
            {
                

                
                    player.transform.position = new Vector3(-1, 0);
                    Cam.transform.position = new Vector3(-1, 0);
                

            }
        }
        if (pt == portalType.nextLevel)
        {
            if (other.CompareTag("Player"))
            {
                SceneManager.LoadScene("Dungeon 2");
            }
        }

    }
    private IEnumerator Cut()
    {
        yield return new WaitForSeconds(4f);
        BossCut.SetActive(false);
        Player.isCut = false;
        Boss.SetActive(true);
        BossHB.SetActive(true);
        first = false;


    }

}
