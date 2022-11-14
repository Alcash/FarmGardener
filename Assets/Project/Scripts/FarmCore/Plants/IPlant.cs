
using System;
using UnityEngine;

namespace FarmCore.Plants
{
    public interface IPlant
    {
        bool IsGrowEnd { get; }
        GameObject CreateView();
        void Harvest();
        void GrowTick(float deltaTime);



    }
}


