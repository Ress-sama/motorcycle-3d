using System;
using System.Collections.Generic;
using UnityEngine;

namespace Riyezu.CarSystem
{
    public class Transmission : MonoBehaviour
    {
        public float TORQUE;
        [SerializeField] private int gear;
        [SerializeField] private List<float> gearRatios;
        public float RPM;
        public float CurrentGearRatio => gearRatios[gear];
        public float CurrentGear => gear;

        public void UpShift()
        {
            if (gearRatios.Count <= gear+1) return;
            gear++;
        }

        public void DownShift()
        {
            if (gear-1<0) return;
            gear--;
        }

        public void Process(float torque)
        {
            TORQUE = torque * gearRatios[gear];
        }

        public void UpdateRpm(float wheelRpm)
        {
            RPM = wheelRpm * gearRatios[gear];
        }

    }
}