using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DroneBlocks
{
    [RequireComponent(typeof(DroneInputs))]
    public class DroneController : BaseRigidbody
    {

        #region Variables
        [Header("Control Properties")]
        [SerializeField] private float minMaxPitch = 30f;
        [SerializeField] private float minMaxRoll = 30f;
        [SerializeField] private float yawPower = 4f;

        private DroneInputs input;
        #endregion

        #region Main Methods
        // Start is called before the first frame update
        void Start()
        {
            input = GetComponent<DroneInputs>();
        }
        #endregion

        #region Custom Methods

        protected override void HandlePhysics()
        {
            HandleEngines();
            HandleControls();
        }

        private void HandleEngines()
        {
            rb.AddForce(Vector3.up * (rb.mass * Physics.gravity.magnitude));
        }

        private void HandleControls()
        {

        }


        #endregion

    }

}
