
using System;
using UnityEngine;

namespace FarmCore.Plants
{
    public interface IPlant
    {
        bool IsGrowEnd { get; }
        IGrowing Growing { get; }
        GameObject CreateView();
        void Harvest();
        void GrowTick(float deltaTime);
       


    }
}


