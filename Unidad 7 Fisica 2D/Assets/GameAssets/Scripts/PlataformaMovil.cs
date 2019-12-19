using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public float movSpeed = 2;

    SliderJoint2D sliderJ;

    // Start is called before the first frame update
    void Start()
    {
        sliderJ = GetComponent<SliderJoint2D>();
        ApplyMotorSpeed(movSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        JointLimitState2D limitState = sliderJ.limitState;

        if (limitState == JointLimitState2D.LowerLimit)
        {
            ApplyMotorSpeed(movSpeed);
        }
        else if (limitState == JointLimitState2D.UpperLimit) {
            ApplyMotorSpeed(-movSpeed);
        }
    }

    void ApplyMotorSpeed(float speed) {
        JointMotor2D myMotor = new JointMotor2D();
        myMotor.motorSpeed = speed;
        myMotor.maxMotorTorque = 10000;
        sliderJ.motor = myMotor;
    }

}
