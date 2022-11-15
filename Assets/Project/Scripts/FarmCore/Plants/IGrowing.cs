using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FarmCore.Plants
{
    public interface IGrowing
    {
        bool IsGrowEnd { get; }
        float GrowValue { get; }
        void GrowTick(float deltaTime);
        event Action GrowComplete;
        void SetGameObject(GameObject gameObject);
        float GrowTimeCountDown { get; }
    }
}
