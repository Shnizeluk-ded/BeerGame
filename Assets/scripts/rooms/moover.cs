using UnityEngine;

public class moover : MonoBehaviour
{
    public Direct direct;
    public Type type;
    private Player player;
    public GameObject black;
    public Animator[] doorsAnim;
    public GameObject[] doors;
    public GameObject[] enemies;
    public GameObject w1;
    public GameObject w2;
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    public enum Direct
    {
        up,
        down,
        left,
        right,
        none

        
    }
    public enum Type
    {
        other,
        main


    }
    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.K))
        {
            black.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (direct == Direct.up)
            {
                player.transform.position += new Vector3(0, 2);
            }
            else if (direct == Direct.down)
            {
                player.transform.position += new Vector3(0, -2);
            }
            else if (direct == Direct.left)
            {
                player.transform.position += new Vector3(-2, 0);
            }
            else if (direct == Direct.right)
            {
                player.transform.position += new Vector3(2, 0);
            }
            if (direct == Direct.none)
            {

                black.SetActive(false);
                enemies[0].SetActive(true);

            }
        }
        
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (direct == Direct.none)
            {
                black.SetActive(true);
            }
            


        }
        if (other.CompareTag("Enemy") && type == Type.other)
        {
            if (direct == Direct.none)
            {
                
                doorsAnim[0].SetTrigger("isOpen");
                doorsAnim[1].SetTrigger("isOpen");
                doorsAnim[2].SetTrigger("isOpen");
                doorsAnim[3].SetTrigger("isOpen");
                Destroy(doors[0], 1f);
                Destroy(doors[1], 1f);
                Destroy(doors[2], 1f);
                Destroy(doors[3], 1f);
                w1.SetActive(false);
                w2.SetActive(true);
                RoomsVariants.rc -= 0.5f;


            }



        }


    }
}
