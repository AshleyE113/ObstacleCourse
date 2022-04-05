using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    MeshRenderer rRockColor;
    float lerpTime = 2.5f;
    [SerializeField] GameObject rightRock;

    private void Start()
    {
        rRockColor = rightRock.GetComponent<MeshRenderer>();
        rRockColor.material.color = Color.black;
    }

    private void Update()
    {
        rRockColor.material.color = Color.Lerp(Color.black, Color.cyan, Mathf.PingPong(Time.time, lerpTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            rightRock.SetActive(false);
    }
}
