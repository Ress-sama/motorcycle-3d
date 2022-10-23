using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class Transmission : MonoBehaviour
    {
        public float Torque { get; private set; }
        [SerializeField] private int gear;
        [SerializeField] private Engine engine;

        public void ChangeGear(int value)
        {
            gear += value;
        }

        public void UpShift()
        {
            gear++;
        }

        public void DownShift()
        {
            gear--;
        }

        private void FixedUpdate()
        {
        }
    }
}