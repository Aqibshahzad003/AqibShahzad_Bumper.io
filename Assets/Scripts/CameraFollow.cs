using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;

    private Vector3 offset;
    public float SmoothSpeed;
    private void Start()
    {
        offset = transform.position - Player.position;  //setting the offset of camera as compared to the player
    }
    private void LateUpdate()
    {
        if (Player != null)
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, Player.position + offset, SmoothSpeed);  //following the player transform by using lerp method for smoothness
            transform.position = newPosition;  //asigning new value to the camera
        }
    }
}
