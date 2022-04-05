using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This class handles the car behaviors, from movement to its reaction to being hit, to respawning it when needed. 
 * This script was made possible by the slides and the Unity wheel collider tutorial at this link: https://www.youtube.com/watch?v=j6_SMdWeGFI&t=579s&ab_channel=RenaissanceCoders
 * The respawn script was possible thanks to the Unity forums, specifically this post: https://answers.unity.com/questions/191822/make-a-spawn-point.html#:~:text=To%20make%20a%20spawn%20point%20just%20create%20an%20empty%20game,points%20are%20down%20to%20zero.
 * In the class you will se that there are "8 wheels" (4 wheel transforms, 4 colliders). This allows one portion of the code to handle the collider code while the other handles
 * the wheel's transform (it's explained in the tutorial)!
 */
public class CarController : MonoBehaviour
{
    //member varis
    [SerializeField] float horizInput;
    [SerializeField] float VertInput;
    [SerializeField] float steeringAngle;

    //varis for car
    [SerializeField] WheelCollider frontWheelL, frontWheelR, rearWheelL, rearWheelR;
    [SerializeField] Transform transFrontWheelL, transFrontWheelR, transRearWheelL, transRearWheelR;
    [SerializeField] float maxSteerAngle = 20;
    [SerializeField] float motorForce = 10;
    [SerializeField] MeshRenderer carBody, frontWheelLMat, frontWheelRMat, rearWheelLMat, rearWheelRMat;

    //Respawn Point
    [SerializeField] Transform SpawnPoint;
    bool respawn = false;
    int health = 3;
    [SerializeField] Vector3 offset = new Vector3(0, 0, 0);

    private void Start()
    {
        carBody.material.color = Color.yellow;
        frontWheelLMat.material.color = Color.black;
        frontWheelRMat.material.color = Color.black;
        rearWheelLMat.material.color = Color.black;
        rearWheelRMat.material.color = Color.black;

        transform.position = SpawnPoint.position + offset; //Allows the player to spawn on top of the spawn point.

    }
    public void GetInput()
    {
        horizInput = Input.GetAxisRaw("Horizontal");
        VertInput = Input.GetAxisRaw("Vertical") * -1; //To fix an inversion error

    }
    void Steer() //handles the steering for the car
    {
        steeringAngle = maxSteerAngle * horizInput;
        frontWheelL.steerAngle = steeringAngle;
        frontWheelR.steerAngle = steeringAngle;
    }
    void Acceleration() //allows car to move
    {
        frontWheelL.motorTorque = VertInput * motorForce;
        frontWheelR.motorTorque = VertInput * motorForce;
    }
    void UpdateWheelPoses() //Keeps the wheels aligned when the car is moving or turning
    {
        UpdateWheelPos(frontWheelL, transFrontWheelL);
        UpdateWheelPos(frontWheelR, transFrontWheelR);
        UpdateWheelPos(rearWheelL, transRearWheelL);
        UpdateWheelPos(rearWheelR, transFrontWheelR);
    }
    void UpdateWheelPos(WheelCollider _collider, Transform _transform) //Updates wheel position based on it's position in the world
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;

    }
    void FixedUpdate()
    {
        GetInput();
        Steer();
        Acceleration();

        /*if (Input.GetAxisRaw("Horizontal") == 0)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
        if (Input.GetAxisRaw("Vertical") * -1 == 0)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }*/
    }

    void Update()
    {
        if (health <= 0 || transform.position.y < -11) //Respawns the player at the starting point and resets their health when they die
        {
            respawn = true;
            health = 3;
        }
        else
            respawn = false;

        if (respawn)
            transform.position = SpawnPoint.position + offset; 

        if (transform.rotation.z >= 89 || transform.rotation.z <= -89)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            StartCoroutine(TookDamage(1f, Color.red));
        }
    }
    void CarColorChanger(Color color) //For TookDamage Coroutine
    {
        carBody.material.color = Color.red;
        frontWheelLMat.material.color = color;
        frontWheelRMat.material.color = color;
        rearWheelLMat.material.color = color;
        rearWheelRMat.material.color = color;
    }
    void NormalCarColors(Color bodyColor, Color wheelColor) //For TookDamage Coroutine
    {
        carBody.material.color = bodyColor;
        frontWheelLMat.material.color = wheelColor;
        frontWheelRMat.material.color = wheelColor;
        rearWheelLMat.material.color = wheelColor;
        rearWheelRMat.material.color = wheelColor;
    }

    IEnumerator TookDamage(float timeVal, Color damageColor) //Makes the car flash a certain color to show it was hit
    {
        health--;
        CarColorChanger(Color.red);
        yield return new WaitForSeconds(timeVal);
        NormalCarColors(Color.yellow, Color.black);
    }
}
