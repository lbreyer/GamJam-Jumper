using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float offsetY;

    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position.y - offsetY <= player.position.y)
        {
            Vector3 pos = transform.position;
            pos.y = player.position.x + offsetY;
            transform.position = pos;

        }
    }
}
