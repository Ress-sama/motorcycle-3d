using Riyezu.CarSystem;
using UnityEngine;

namespace Riyezu.Dashboard
{
    public class RpmMeter : MonoBehaviour
    {
        [SerializeField] float defaultAngle;
        [SerializeField] int limitRpm = 8;
        [SerializeField] float maxAngle = -200;
        [SerializeField] Transform rpmStick;
        [SerializeField] private Vehicle vehicle;


        private void Update()
        {
            rpmStick.rotation = Quaternion.AngleAxis(defaultAngle + ((maxAngle - defaultAngle) * (vehicle.ENGINE.RPM / 1000) / limitRpm), Vector3.forward);
        }
    }

}
