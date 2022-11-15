using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FarmCore.Plants
{
    public interface IHarvest
    {           
        bool IsCanHarvest { get; }
        void Harvest();
        void SetGameObject(GameObject gameObject);
    }
}
