using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockColor : MonoBehaviour
{
    MeshRenderer rock_color;
    float lerpTime = 1.5f;
    void Start()
    {
        rock_color = GetComponent<MeshRenderer>();
        rock_color.material.color = Color.black;
    }

    void Update()
    {
        rock_color.material.color = Color.Lerp(Color.black, Color.cyan, Mathf.PingPong(Time.time, lerpTime));
    }
}
