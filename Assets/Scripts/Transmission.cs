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

        public void UpShift()
        {
            gear++;
        }

        public void DownShift()
        {
            gear--;
        }

        public void EngineTorque(float torque)
        {
            Torque = torque * gearRatios[gear];
        }

        public void UpdateRpm(float wheelRpm)
        {
            RPM = wheelRpm * gearRatios[gear];
        }
    }
}