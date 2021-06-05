using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DroneBlocks {

    [RequireComponent(typeof(CameraInputs))]
    public class FollowCam : MonoBehaviour

    {
        public Transform target = null;
        public Transform rig = null;

        public float distance = 5f;
        public float rotationSpeed = 100f;

        private Vector3 cameraPosition;
        private Vector3 smoothPosition;
        private float smoothTime = 0.125f;
        private float angle;
        
        private CameraInputs inputs;

        private void Start() 
        {
            inputs = GetComponent<CameraInputs>();
        }

        private void FixedUpdate()
        {    
            if (inputs.CameraType == 0) RigCam();
            else if (inputs.CameraType == 1) TopCam();
            else if (inputs.CameraType == 2) BackCam();
            else if (inputs.CameraType == 3) FPVCam();
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
            cameraPosition = target.position - (target.forward * distance) + target.up * distance * 0.1f;
            smoothPosition = Vector3.Lerp(transform.position, cameraPosition, smoothTime);
            transform.position = smoothPosition;

            angle = Mathf.Abs(Quaternion.Angle(transform.rotation, target.rotation));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, (rotationSpeed + angle) * Time.deltaTime);
        }

        private void FPVCam()
        {
            transform.position = target.position + target.up;
            transform.rotation = target.rotation * Quaternion.Euler(0, 0, 0);
        }

    }
}