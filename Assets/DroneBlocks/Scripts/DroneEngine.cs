using UnityEngine;

namespace DroneBlocks
{
    [RequireComponent(typeof(BoxCollider))]
    public class DroneEngine : MonoBehaviour, IEngine
    {

        #region Variables
        [Header("Engine Properties")]
        [SerializeField] private float maxPower = 4f;

        [Header("Propeller Properties")]
        [SerializeField] private Transform propeller;
        [SerializeField] private float propellerRotationSpeed = 200;
        [SerializeField] private int propellerDirection = 1;
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

            HandlePropellers();
        }

        void HandlePropellers()
        {
            if (!propeller) 
            {
                return;
            }

           //throttle = Mathf.Clamp(throttle, 1, 1000);

            propeller.Rotate(Vector3.up, propellerRotationSpeed*propellerDirection);
        }

        #endregion
    }
}
