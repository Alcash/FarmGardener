using EventManager;
using FarmCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventManager
{
    public class PlantHarvestMessage : IEventMessage
    {
        public FarmCell cell { get; private set; }
        public PlantHarvestMessage(FarmCell farmCell)
        {
            cell = farmCell;
        }
    }
}
