
using System;
using UnityEngine;

namespace FarmCore.Plants
{
    public interface IPlant
    {       
        IGrowing Growing { get; }
        IHarvest Harvesting { get; }
        GameObject CreateView();   
    }
}


