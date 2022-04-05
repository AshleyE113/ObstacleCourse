using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*This class fixes an issue with the car. It uses a rigidbody and the Gizmo class to change the car's center of mass (COM) within
 * the scene itself. This was possible thanks to this tutorial: https://www.youtube.com/watch?v=n2VOu5d2wVM&ab_channel=DitzelGames!
 */
[RequireComponent(typeof(Rigidbody))]
public class CenterOfMass : MonoBehaviour
{
    public Vector3 v_centerofMass;
    public bool onAwake;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.centerOfMass = v_centerofMass;
        rb.WakeUp(); //Makes the rigidbody wake up
        onAwake = !rb.IsSleeping();
    }

    //This function creates a cyan sphere that shows the car's COM. It moves depending on the Vector3 vals.
    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(transform.position + transform.rotation * v_centerofMass, 0.3f);
    }
}
