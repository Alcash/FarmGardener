using FarmCore;
using FarmCore.Plants.GameData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventManager
{
    public class PlantSelectMessage : IEventMessage
    {
        public PlantData plant { get; private set; }
        public FarmCell cell { get; private set; }
        public PlantSelectMessage(FarmCell farmCell,PlantData plantData)
        {
            plant = plantData;
            cell = farmCell;
        }
    }
}
