using FarmCore;
using FarmCore.Plants.GameData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventManager
{
    public class PlantSelectMessage : IEventMessage
    {
        public PlantData Plant { get; private set; }
        public FarmCell Cell { get; private set; }
        public PlantSelectMessage(FarmCell farmCell,PlantData plantData)
        {
            Plant = plantData;
            Cell = farmCell;
        }
    }
}
