using UnityEngine;

public class targeting : MonoBehaviour
{
    public float offset;
    private Player player;
    public Camera cam;
    private float rotZ;
    public float offset2;
    private Vector3 difference;
    public enum State
    {
        followPlayer,
        followPWeapon,
        followEnWeapon
    }
    public State state;
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if(state == State.followPlayer)
        {
            transform.position = player.transform.position;
        }
        else if (state == State.followPWeapon)
        {
            
        
        
            Vector3 difference = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        }
        else if (state == State.followEnWeapon)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset2);
            difference = player.transform.position - transform.position;
            rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        }
       

    }
}
