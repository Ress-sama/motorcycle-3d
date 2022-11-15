using System;
using System.Collections.Generic;
using UnityEngine;
namespace Riyezu.CarSystem
{

    public class SyncWheels : MonoBehaviour
    {
        [SerializeField] List<WheelSyncData> wheelSyncs;


        private void Awake()
        {
            wheelSyncs[0].targetWheelCollider.GetWorldPose(out Vector3 wcPosition, out Quaternion wcRotation);
        }

        private void Update()
        {
            Sync();
        }

        public void Sync()
        {
            foreach (var item in wheelSyncs)
            {
                item.targetWheelCollider.GetWorldPose(out Vector3 wcPosition, out Quaternion wcRotation);
                item.syncObject.position = wcPosition;
                item.syncObject.localPosition = new Vector3(item.syncObject.localPosition.x, item.syncObject.localPosition.y, item.syncObject.localPosition.z);
                item.syncObject.rotation = wcRotation ;
            }
        }

    }

    [Serializable]
    public class WheelSyncData
    {
        public Transform syncObject;
        public WheelCollider targetWheelCollider;
    }
}
