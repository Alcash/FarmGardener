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
        private bool _isGrowed;

        public bool IsGrowEnd => _isGrowed;

        public IGrowing Growing => _growing;

        public Plant(PlantData plantData, IGrowing growing, IHarvest harvest)
        {
            _plantData = plantData;
            _growing = growing;
           
            _harvest = harvest;
            _isGrowed = false;
            _growing.GrowComplete += OnGrowComplete;
        }   

        public GameObject CreateView()
        {
            _instView = GameObject.Instantiate(_plantData.View3d);
            _growing.SetGameObject(_instView);
            _harvest.SetGameObject(_instView);
            return _instView;
        }        

        public void GrowTick(float deltaTime)
        {
            if(_isGrowed == false)
            {
                _growing.GrowTick(deltaTime);               
            }                    
        }

        public void Harvest()
        {
            _harvest.Harvest();
        }

        private void OnGrowComplete()
        {
            _isGrowed = true;
        }
    }
}
