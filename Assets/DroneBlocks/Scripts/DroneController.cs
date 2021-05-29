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
        [SerializeField] private float lerpSpeed = 2f;

        private DroneInputs inputs;
        private List<IEngine> engines = new List<IEngine>();

        private float finalPitch;
        private float finalRoll;
        private float yaw;
        private float finalYaw;
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
            // Input is between -1 to 1 to we multiply
            float pitch = inputs.Cyclic.y * minMaxPitch;
            float roll = -inputs.Cyclic.x * minMaxRoll;
            yaw += inputs.Pedals * yawPower;

            finalPitch = Mathf.Lerp(finalPitch, pitch, Time.deltaTime * lerpSpeed);
            finalRoll = Mathf.Lerp(finalRoll, roll, Time.deltaTime * lerpSpeed);
            finalYaw = Mathf.Lerp(finalYaw, yaw, Time.deltaTime * lerpSpeed);

            // https://docs.unity3d.com/ScriptReference/Quaternion.Euler.html
            // public static Quaternion Euler(float x, float y, float z);
            // Pitch rotates around the X axis
            // Yaw rotates around the Y axis
            // Roll rotates around the Z axis
            Quaternion rot = Quaternion.Euler(finalPitch, finalYaw, finalRoll);

            // public void AddTorque(float x, float y, float z, ForceMode mode = ForceMode.Force);
            // public void MoveRotation(Quaternion rot);

            rb.MoveRotation(rot);

            // This will be more realistic but harder to control since there will be no limit
            // TODO: work with this later
            //rb.AddTorque(pitch, yaw, roll, ForceMode.Force);
        }


        #endregion

    }

}
