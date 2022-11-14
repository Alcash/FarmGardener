using EventManager;
using FarmCore;
using FarmCore.Plants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventManager
{
    public class FarmCellPlantedMessage : IEventMessage
    {
        public FarmCell Cell { get; private set; }
        public IPlant Plant { get; private set; }
        public FarmCellPlantedMessage(FarmCell farmCell, IPlant plant)
        {
            Cell = farmCell;
            Plant = plant;
        }
    }
}
