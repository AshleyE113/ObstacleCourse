using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This class was made to fix a jittering problem when the camera was a child to the player. This was possible thanks to Brackeys!*/
public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform p_transform;
    [SerializeField] float smoothSpeed = 0.125f;
    [SerializeField] Vector3 offset;
    private void LateUpdate()
    {
        transform.position = p_transform.position + offset; //sets the camera a certain distance away from the player.
    }
}
