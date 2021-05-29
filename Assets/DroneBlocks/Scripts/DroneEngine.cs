using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DroneBlocks
{
    [RequireComponent(typeof(BoxCollider))]
    public class DroneEngine : MonoBehaviour, IEngine
    {

        #region Variables
        [Header("Engine Properties")]
        [SerializeField] private float maxPower = 4f;
        #endregion

        #region Interface Methods
        public void InitEngine()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateEngine(Rigidbody rb, DroneInputs inputs)
        {

            // Divide by 4 because 1/4 engines
            Vector3 engineForce  = Vector3.zero;
            engineForce = transform.up * ((rb.mass * Physics.gravity.magnitude) + (inputs.Throttle * maxPower)) / 4f;
            //Debug.Log("Running engine: " + gameObject.name + ":" + engineForce);
            rb.AddForce(engineForce, ForceMode.Force);
        }

        #endregion
    }
}
