using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This class allows the three ramps at the beginning to lerp between two colors and makes only ONE of them solid while the player
 can fall through the other two.*/

public class RampScript : MonoBehaviour
{
    Color lerpColor = Color.blue;
    [SerializeField] GameObject disappearingRamp1;
    [SerializeField] GameObject disappearingRamp2;
    [SerializeField] GameObject regularRamp;
    MeshRenderer Dramp_renderer, Dramp_renderer2, Rramp_renderer;
    
    [SerializeField] float lerpTime;

    void Start()
    {
        Dramp_renderer = disappearingRamp1.GetComponent<MeshRenderer>();
        Dramp_renderer.material.color = Color.blue;
        Dramp_renderer2 = disappearingRamp2.GetComponent<MeshRenderer>();
        Dramp_renderer2.material.color = Color.blue;
        Rramp_renderer = regularRamp.GetComponent<MeshRenderer>();
        Rramp_renderer.material.color = Color.blue;
    }

    void Update() //Allows all of them to lerp.
    {
        Dramp_renderer.material.color = Color.Lerp(Color.blue, Color.magenta, Mathf.PingPong(Time.time, lerpTime));
        Dramp_renderer2.material.color = Color.Lerp(Color.blue, Color.magenta, Mathf.PingPong(Time.time, lerpTime));
        Rramp_renderer.material.color = Color.Lerp(Color.blue, Color.magenta, Mathf.PingPong(Time.time, lerpTime));
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.SetActive(false); //Makes the player fall if they choose the wrong ramp
        }
    }
}
