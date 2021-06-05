using UnityEngine;
using UnityEngine.InputSystem;

namespace DroneBlocks {

    [RequireComponent(typeof(PlayerInput))]
    public class CameraInputs : MonoBehaviour
    {
        private int cameraType = 0;

        public float CameraType { get=> cameraType; }

        private void OnToggle(InputValue value)
        {

            cameraType += 1;

            if (cameraType >= 4) 
            {
                cameraType = 0;
            }

        }
    }

}