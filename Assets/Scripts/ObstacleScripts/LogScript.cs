using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This class makes the logs lerp between two points and disappear once it hits an invisble wall.*/

public class LogScript : MonoBehaviour
{
    public float start_val;
    public float end_val;
    public float inter_point;
    public float x_pos;
    public float y_pos;
    public float z_pos;

    void Update()
    {
        //Allows the log to lerp from one position to the other over a certain amount of time!
        transform.position = new Vector3(Mathf.Lerp(start_val, end_val, inter_point), y_pos, z_pos);
        inter_point += (0.5f * Time.deltaTime); //Allows it to happen over tme, can't be 0 or 1!
    }

    void OnTriggerEnter(Collider other)
    { 
        if (other.tag == "Wall") //Destroys the log once it hits an invisible wall!
        {
            Destroy(gameObject);
        }
    }
}
