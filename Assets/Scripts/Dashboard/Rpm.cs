using Riyezu.CarSystem;
using UnityEngine;

public class Rpm : MonoBehaviour
{
    [SerializeField] float defaultAngle;
    [SerializeField] Transform rpmStick;
    [SerializeField] private Engine engine;


    private void Update()
    {
        rpmStick.rotation = Quaternion.AngleAxis(defaultAngle + ((-200 - defaultAngle) * (engine.RPM / 1000) / 9), Vector3.forward);
    }
}
