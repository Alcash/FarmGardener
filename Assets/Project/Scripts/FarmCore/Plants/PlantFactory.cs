using FarmCore.Plants.GameData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FarmCore.Plants
{
    public class PlantFactory
    {
        public static IPlant Create(PlantData plantData)
        {
            IPlant plant = null;
            switch (plantData.PlantType)
            {                
                case PlantsEnum.Carrot:
                    plant = new Plant(plantData,
                           new SimpleGrow(plantData),
                           new HarvestWithReward(plantData));
                    break;
                case PlantsEnum.Grass:
                    plant = new Plant(plantData,
                           new SimpleGrow(plantData),
                           new HarvestExp(plantData));
                    break;
                case PlantsEnum.Tree:     
                     plant = new Plant(plantData,
                          new EndlessGrow(plantData),
                          new HarvestExp(plantData));
                    break;
                default:
                    return null;
            }
            return plant;

        }
    }
}
