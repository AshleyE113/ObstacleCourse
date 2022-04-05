using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    public float freq;
    public float mag;
    public int dir_control;
    Vector3 pos;

    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos -= (transform.forward * dir_control) * Time.deltaTime * moveSpeed; //Allows the ball to move at a certain direction at a certain speed if it's a pos or neg number!
        transform.position = pos + transform.right * Mathf.Sin(Time.time * freq) * mag; //Gives that bouncing effect over time!
    }

    void OnTriggerEnter(Collider other)
    { //Destroys the ball once it hits an invisible wall!
        if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
