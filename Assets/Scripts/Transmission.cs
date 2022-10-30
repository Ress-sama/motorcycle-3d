using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Transmission : MonoBehaviour
    {
        public float Torque { get; private set; }
        [SerializeField] private int gear;
        [SerializeField] private List<float> gearRatios;
        [SerializeField] private Engine engine;
        public float RPM;


        public void UpShift()
        {
            gear++;
            //3.64 - 1.95 = ~1.7
            float currentTransmissionRPM = RPM * (gearRatios[gear] - gearRatios[gear - 1]);
            float difRpm = engine.RPM - currentTransmissionRPM;
        }

        public void DownShift()
        {
            gear--;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                UpShift();
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                DownShift();
            }
        }
        private void FixedUpdate()
        {


            Process();
        }

        private void Process()
        {
            Torque = engine.TORQUE * gearRatios[gear];
            RPM = engine.RPM / gearRatios[gear];
        }
    }
}