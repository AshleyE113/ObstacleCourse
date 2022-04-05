using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        SecPos = transform.position + new Vector3(0, height, 0);
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
                    yield return new WaitForSeconds(duration);
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

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            isMoving = true;
            //col.collider.transform.SetParent(transform); //makes the player's transform, the obj's
        }
    }

    private void OnCollisionExit(Collision col)
    {
        //col.collider.transform.SetParent(null); //makes the player's transform, the obj's
    }
}
