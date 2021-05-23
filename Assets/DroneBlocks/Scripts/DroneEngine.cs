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

        public void UpdateEngine()
        {
            Debug.Log("Running engine: " + gameObject.name);
        }

        #endregion
    }
}
