using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

        private DroneInputs inputs;

        private List<IEngine> engines = new List<IEngine>();
        #endregion

        #region Main Methods
        void Start()
        {
            inputs = GetComponent<DroneInputs>();
            engines = GetComponentsInChildren<IEngine>().ToList<IEngine>();
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
            //rb.AddForce(Vector3.up * (rb.mass * Physics.gravity.magnitude));

            foreach (IEngine engine in engines)
            {
                engine.UpdateEngine(rb, inputs);
            }
        }

        private void HandleControls()
        {

        }


        #endregion

    }

}
