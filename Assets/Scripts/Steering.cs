using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Riyezu.CarSystem
{
    public class Steering : MonoBehaviour
    {
        [SerializeField] private WheelCollider leftWheel;
        [SerializeField] private WheelCollider rightWheel;


        [SerializeField] private float wheelBase;
        [SerializeField] private float rearTrack;
        [SerializeField] private float turnRadius;

        [SerializeField] private float turnSmoothTime;

        public float CarSpeed { get; set; }

        private float ackermanAngleLeft;
        private float ackermanAngleRight;

        private float wheelAngleLeft;
        private float wheelAngleRight;

        [SerializeField] private float targetSpeedRatio;

        float velocity = 0;



        public void SteerWheels(float inputX)
        {
            if (inputX > 0)
            {
                ackermanAngleLeft = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius + (rearTrack / 2))) * inputX;
                ackermanAngleRight = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius - (rearTrack / 2))) * inputX;
            }
            else if (inputX < 0)
            {
                ackermanAngleLeft = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius - (rearTrack / 2))) * inputX;
                ackermanAngleRight = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius + (rearTrack / 2))) * inputX;
            }
            else
            {
                ackermanAngleLeft = 0;
                ackermanAngleRight = 0;
            }

            leftWheel.steerAngle = wheelAngleLeft * (1.04f - targetSpeedRatio);

            rightWheel.steerAngle = wheelAngleRight * (1.04f - targetSpeedRatio);


        }

        public void FixedUpdate()
        {
            float carSpeed = CarSpeed > 80 ? 80 : CarSpeed;
            targetSpeedRatio = carSpeed / 80;

            wheelAngleLeft = Mathf.SmoothDamp(wheelAngleLeft, ackermanAngleLeft, ref velocity, turnSmoothTime);

            wheelAngleRight = Mathf.SmoothDamp(wheelAngleRight, ackermanAngleRight, ref velocity, turnSmoothTime);
        }

    }
}
