using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FarmCore.Plants
{
    public class SimpleGrow : IGrowing
    {
        public void GrowTick(float deltaTime)
        {
            Debug.Log("Simple grow");
        }
    }
}
