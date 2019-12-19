using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float carSpeed;
    public float maxMotorForce = 10000;
    public SpriteRenderer playerSR;

    public WheelJoint2D backWheel;
    public WheelJoint2D frontWheel;

    bool canDrive = false;
    JointMotor2D motorJ = new JointMotor2D();
    JointSuspension2D frontSpensionJ = new JointSuspension2D();
    JointSuspension2D backSpensionJ = new JointSuspension2D();

    // Start is called before the first frame update
    void Start()
    {
        motorJ.maxMotorTorque = maxMotorForce;
        frontSpensionJ = frontWheel.suspension;
        backSpensionJ = backWheel.suspension;
    }

    // Update is called once per frame
    void Update()
    {
        if (canDrive) {
            float horizontal = Input.GetAxis("Horizontal");

            motorJ.motorSpeed = carSpeed * horizontal;
            frontSpensionJ.angle = 90 - frontWheel.gameObject.transform.rotation.eulerAngles.z;
            backSpensionJ.angle = 90 - backWheel.gameObject.transform.rotation.eulerAngles.z;

            backWheel.motor = motorJ;
            backWheel.suspension = backSpensionJ;
            frontWheel.motor = motorJ;
            frontWheel.suspension = frontSpensionJ;

        }
        
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player" && Input.GetKeyDown(KeyCode.E)) {
            canDrive = true;
            playerSR.enabled = true;
            Destroy(col.gameObject);
        }
    }

}
