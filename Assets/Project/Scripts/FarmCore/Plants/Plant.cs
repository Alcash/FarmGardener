using FarmCore.Plants;
using FarmCore.Plants.GameData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FarmCore.Plants
{
    public class Plant : IPlant
    {
        private PlantData _plantData;

        private GameObject _instView;

        private IGrowing _growing;
        private IHarvest _harvest;

        public Plant(PlantData plantData)
        {
            _plantData = plantData;
            _growing = new SimpleGrow();
            _harvest = new HarvestWithReward();
        }

        public void SetHarvest(IHarvest harvest)
        {
            _harvest = harvest;
        }

        public void SetGrowing(IGrowing growing)
        {
            _growing = growing;
        }

        public GameObject CreateView(Vector3 position)
        {
            return _instView = GameObject.Instantiate(_plantData.View3d, position, Quaternion.identity);
        }        

        public void GrowTick(float deltaTime)
        {
            _growing.GrowTick(deltaTime);
        }

        public void Harvest()
        {
            _harvest.Harvest();
        }
    }
}
