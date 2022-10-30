using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Motorcycle : MonoBehaviour
    {
        [SerializeField] private Engine engine;
        [SerializeField] private Transmission transmission;

        private float verticalInput;

        private void Awake()
        {
        }

        private void Update()
        {
            verticalInput = Input.GetAxis("Vertical");
            if (verticalInput != 0)
            {
            }
        }
    }
}