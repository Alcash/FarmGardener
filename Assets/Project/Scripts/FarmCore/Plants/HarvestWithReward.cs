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

        public void Harvest()
        {
            Debug.Log($"Harvest with reward {_plantData.ExpForGrow * _plantData.GrowTime}");
            GameObject.Destroy(_view);
        }

        public void SetGameObject(GameObject gameObject)
        {
            _view = gameObject;
        }
    }
}
