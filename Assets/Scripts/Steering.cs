using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Riyezu.CarSystem
{
    public class Steering : MonoBehaviour
    {
        [SerializeField] private List<WheelCollider> wheels;
        [SerializeField] private float maxSteerAngle;

        public void SteerWheels(float inputX)
        {
            foreach (var item in wheels)
            {
                item.steerAngle = maxSteerAngle * inputX;
            }
        }

    }
}
