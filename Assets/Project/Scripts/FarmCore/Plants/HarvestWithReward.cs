using EventManager;
using FarmCore.Plants.GameData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FarmCore.Plants
{
    public class HarvestWithReward : IHarvest
    {
        private readonly PlantData _plantData;
        private GameObject _view;       
        public HarvestWithReward(PlantData plantData)
        {
            _plantData = plantData;
        }

        public bool IsCanHarvest => _plantData.IsCanHarvest;

        public void Harvest()
        {
            var exp = _plantData.ExpForGrow * _plantData.GrowTime;
            EventManager.EventManager.SendMessage(new ResourceChangeMessage(ResourceManager.ExpName, exp));
            EventManager.EventManager.SendMessage(new ResourceChangeMessage(_plantData.PlantType.ToString(), 1));
            GameObject.Destroy(_view);
        }

        public void SetGameObject(GameObject gameObject)
        {
            _view = gameObject;
        }
    }
}
