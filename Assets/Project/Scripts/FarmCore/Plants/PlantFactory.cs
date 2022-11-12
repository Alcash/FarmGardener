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
            var plant = new Plant(plantData);
            switch (plantData.PlantType)
            {
                case PlantsEnum.Carrot:                    
                    plant.SetGrowing(new SimpleGrow());
                    plant.SetHarvest(new HarvestWithReward());
                    break;
                case PlantsEnum.Grass:                   
                    plant.SetGrowing(new SimpleGrow());
                    plant.SetHarvest(new HarvestWithReward());
                    break;
                case PlantsEnum.Tree:                   
                    plant.SetGrowing(new SimpleGrow());
                    plant.SetHarvest(new HarvestWithReward());
                    break;
                default:
                    return null;
            }
            return plant;

        }
    }
}
