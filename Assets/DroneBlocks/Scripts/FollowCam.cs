using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DroneBlocks {
    public class FollowCam : MonoBehaviour

    {
        public Transform target = null;
        public Transform rig = null;

        public float distance = 10f;
        public float rotationSpeed = 10f;

        private Vector3 cameraPosition;
        private Vector3 smoothPosition;
        private float smoothTime = 0.125f;
        private float angle;
        private int camType = 0;
        
        private void Update()
        {
            // if (Input.GetKeyDown("c"))
            // {
            //     camType += 1;
            //     if (camType >= 3)
            //     {
            //         camType = 0;
            //     }
            // }
        }

        private void FixedUpdate()
        {    
            if (camType == 0) RigCam();
            else if (camType == 1) TopCam();
            else if (camType == 2) BackCam();
            else RigCam();
        }

        private void RigCam()
        {
            transform.position = rig.position;
            transform.rotation = rig.rotation;
        }

        private void TopCam()
        {
            transform.position = target.position + target.up * distance;
            transform.rotation = target.rotation * Quaternion.Euler(90f, 0, 0);
        }

        private void BackCam()
        {
            cameraPosition = target.position - (target.forward * distance) + target.up * distance * 0.25f;
            smoothPosition = Vector3.Lerp(transform.position, cameraPosition, smoothTime);
            transform.position = smoothPosition;

            angle = Mathf.Abs(Quaternion.Angle(transform.rotation, target.rotation));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, (rotationSpeed + angle) * Time.deltaTime);
        }

    }
}