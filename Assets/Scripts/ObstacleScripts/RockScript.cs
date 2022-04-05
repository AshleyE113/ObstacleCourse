using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This class is made for a specific rock in the rock line. While it lerps the same colors that the rocks do, it does it
 at a different rate than the others so the player can notice it!*/

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
            rightRock.SetActive(false); //Allows the player to move through it once they touch it
    }
}
