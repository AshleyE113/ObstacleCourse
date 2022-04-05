using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampScript : MonoBehaviour
{
    Color lerpColor = Color.blue;
    [SerializeField] GameObject disappearingRamp1;
    [SerializeField] GameObject disappearingRamp2;
    [SerializeField] GameObject regularRamp;
    MeshRenderer Dramp_renderer, Dramp_renderer2, Rramp_renderer;
    
    [SerializeField] float lerpTime;

    // Start is called before the first frame update
    void Start()
    {
        Dramp_renderer = disappearingRamp1.GetComponent<MeshRenderer>();
        Dramp_renderer.material.color = Color.blue;
        Dramp_renderer2 = disappearingRamp2.GetComponent<MeshRenderer>();
        Dramp_renderer2.material.color = Color.blue;
        Rramp_renderer = regularRamp.GetComponent<MeshRenderer>();
        Rramp_renderer.material.color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        Dramp_renderer.material.color = Color.Lerp(Color.blue, Color.magenta, Mathf.PingPong(Time.time, lerpTime));
        Dramp_renderer2.material.color = Color.Lerp(Color.blue, Color.magenta, Mathf.PingPong(Time.time, lerpTime));
        Rramp_renderer.material.color = Color.Lerp(Color.blue, Color.magenta, Mathf.PingPong(Time.time, lerpTime));
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.SetActive(false); //Makes the incorrect ramps disappear
        }
    }
}
