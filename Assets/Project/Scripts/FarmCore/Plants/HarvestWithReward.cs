using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FarmCore.Plants
{
    public class HarvestWithReward : IHarvest
    {
        public void Harvest()
        {
            Debug.Log("Harvest with reward");
        }
    }
}
