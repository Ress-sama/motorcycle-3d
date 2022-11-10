using System;
using System.Collections.Generic;
using UnityEngine;

namespace Riyezu.CarSystem
{
    public class Transmission : MonoBehaviour
    {
        public float Torque;
        [SerializeField] private int gear;
        [SerializeField] private List<float> gearRatios;
        public float RPM;
        public float rpm;
        public float CurrentGearRatio => gearRatios[gear];
        public float Clutch = 0;
        public float ClutchRPM;

        public void UpShift()
        {
            Clutch = 1;
            gear++;
        }

        public void DownShift()
        {
            Clutch = 1;
            gear--;
        }

        public void EngineTorque(float torque)
        {
            Torque = torque * gearRatios[gear] * (1 - Clutch);
        }

        public void UpdateRpm(float wheelRpm)
        {
            RPM = wheelRpm * gearRatios[gear] * (1 - Clutch);
        }

    }
}