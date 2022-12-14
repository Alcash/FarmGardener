using EventManager;
using FarmCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventManager
{
    public class PlantHarvestMessage : IEventMessage
    {
        public FarmCell Cell { get; private set; }
        public PlantHarvestMessage(FarmCell farmCell)
        {
            Cell = farmCell;
        }
    }
}
