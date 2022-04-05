using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        //transform.position = SpawnPoint.position + offset;

    }
    public void GetInput()
    {
        horizInput = Input.GetAxis("Horizontal");
        VertInput = Input.GetAxis("Vertical");
    }

    void Steer()
    {
        steeringAngle = maxSteerAngle * horizInput;
        frontWheelL.steerAngle = steeringAngle;
        frontWheelR.steerAngle = steeringAngle;
    }

    void Acceleration()
    {
        frontWheelL.motorTorque = VertInput * motorForce;
        frontWheelR.motorTorque = VertInput * motorForce;
    }
    void UpdateWheelPoses()
    {
        UpdateWheelPos(frontWheelL, transFrontWheelL);
        UpdateWheelPos(frontWheelR, transFrontWheelR);
        UpdateWheelPos(rearWheelL, transRearWheelL);
        UpdateWheelPos(rearWheelR, transFrontWheelR);
    }
    void UpdateWheelPos(WheelCollider _collider, Transform _transform) //Updates wheel position
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
    }

    void Update()
    {
        if (health <= 0)
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

    void CarColorChanger(Color color)
    {
        carBody.material.color = Color.red;
        frontWheelLMat.material.color = color;
        frontWheelRMat.material.color = color;
        rearWheelLMat.material.color = color;
        rearWheelRMat.material.color = color;
    }

    void NormalCarColors(Color bodyColor, Color wheelColor)
    {
        carBody.material.color = bodyColor;
        frontWheelLMat.material.color = wheelColor;
        frontWheelRMat.material.color = wheelColor;
        rearWheelLMat.material.color = wheelColor;
        rearWheelRMat.material.color = wheelColor;
    }

    IEnumerator TookDamage(float timeVal, Color damageColor)
    {
        //It makes the car flash a certain color over time
        health--;
        CarColorChanger(Color.red);
        yield return new WaitForSeconds(timeVal);
        NormalCarColors(Color.yellow, Color.black);
    }

}
