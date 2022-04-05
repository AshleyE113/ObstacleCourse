using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This allows the platform that rings you to the last part of the course to move up and down! This was possible thanks to a number of Unity forum posts,
 especially this one: https://forum.unity.com/threads/making-a-platform-rise-and-fall.37540/ */
public class UpwardPlatform : MonoBehaviour
{
    Vector3 velocity;
    bool isMoving;
    [SerializeField] float duration;
    [SerializeField] float height = 5f;
    bool goingUp = true;
    [SerializeField] float speed = 2f;
    Vector3 firstPos;
    Vector3 SecPos;
    Rigidbody rb;

    private void Start()
    {
        firstPos = transform.position;
        SecPos = transform.position + new Vector3(0, height, 0); //the highest he platform will go
        rb = GetComponent<Rigidbody>();

        if (!goingUp)
            transform.position = SecPos;

        StartCoroutine(PlatformMovement(duration));
    }

    IEnumerator PlatformMovement(float duration)
    {
        while (true)
        {
            Vector3 direction;

            if (goingUp)
            {
                direction = new Vector3(0, speed, 0);
                if (rb.position.y > SecPos.y)
                {
                    goingUp = false;
                    yield return new WaitForSeconds(duration); //Keeps the platform here for a certain amoutn of time
                }
            }
            else
            {
                direction = new Vector3(0, -speed, 0);
                if (rb.position.y < firstPos.y)
                {
                    goingUp = true;
                    yield return new WaitForSeconds(duration);
                }
            }
            rb.MovePosition(rb.position + direction * Time.deltaTime);
            yield return null;
            
        }
    }
}
