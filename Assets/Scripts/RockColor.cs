using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This class makes all of the rocks lerp between two colors with the Color class. If you see that one rock is different from the others,
 it's not a mistake or bug. It's on purpose! */
public class RockColor : MonoBehaviour
{
    MeshRenderer rock_color;
    float lerpTime = 1.5f;

    void Start()
    {
        rock_color = GetComponent<MeshRenderer>();
        rock_color.material.color = Color.black; //Sets the material's color to black.
    }

    void Update()
    {
        rock_color.material.color = Color.Lerp(Color.black, Color.cyan, Mathf.PingPong(Time.time, lerpTime)); //Makes it lerp between these two colors over time
    }
}
