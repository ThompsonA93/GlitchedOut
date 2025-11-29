using UnityEngine;

//Default camera, only moves horizontally
public class CameraDefault : MonoBehaviour
{

    //Camera offset from player
    public float offsetX;
 

    public Player player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //y position of camera stays constant!
        transform.position = new Vector3(player.transform.position.x + offsetX, transform.position.y, transform.position.z);
        
    }
}
