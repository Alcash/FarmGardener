using EventManager;
using FarmCore.Plants;
using FarmCore.Plants.GameData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FarmCore.Plants
{
    public class HarvestExp : IHarvest
    {
        private readonly PlantData _plantData;
        private GameObject _view;
        public HarvestExp(PlantData plantData)
        {
            _plantData = plantData;
        }

        public bool IsCanHarvest => _plantData.IsCanHarvest;

        public void Harvest()
        {
            var exp = _plantData.ExpForGrow * _plantData.GrowTime;
            EventManager.EventManager.SendMessage(new ResourceChangeMessage(ResourceManager.ExpName, exp));
            GameObject.Destroy(_view);
        }

        public void SetGameObject(GameObject gameObject)
        {
            _view = gameObject;
        }
    }
}
