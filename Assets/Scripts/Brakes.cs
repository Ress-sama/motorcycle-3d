using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Riyezu.CarSystem
{
    public class Brakes : MonoBehaviour
    {
        [SerializeField] List<WheelCollider> wheels;
        [SerializeField] private float BreakeTorque;


        public void ApplyBrake(float inputY)
        {
            float breakTorque = 0;
            if (inputY < 0)
                breakTorque = Mathf.Abs(inputY) * BreakeTorque;

            foreach (var wheel in wheels)
            {
                wheel.brakeTorque = breakTorque;
            }
        }

    }

}