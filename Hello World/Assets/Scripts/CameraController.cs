using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player;
    public float yOffset;
    public float xOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            transform.position = new Vector3(player.position.x + xOffset, player.position.y + yOffset, transform.position.z);
        }
    }
}
