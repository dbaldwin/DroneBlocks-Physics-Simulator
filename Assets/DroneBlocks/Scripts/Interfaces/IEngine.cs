using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DroneBlocks
{

    public interface IEngine
    {
        void InitEngine();
        void UpdateEngine(Rigidbody rb, DroneInputs inputs);
    }

}