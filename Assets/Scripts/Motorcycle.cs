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
            engine.StartEngine();
        }

        private void Update()
        {
            verticalInput = Input.GetAxis("Vertical");
            if (verticalInput != 0)
            {
                engine.Gas(verticalInput);
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                transmission.ChangeGear(1);
            }

            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                transmission.ChangeGear(-1);
            }
        }
    }
}