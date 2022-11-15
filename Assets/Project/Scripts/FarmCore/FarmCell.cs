using EventManager;
using FarmCore.Plants;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FarmCore
{
    public class FarmCell : MonoBehaviour
    {
       
        private IPlant _plant;
        public IPlant Plant => _plant;
        private GameObject _plantView;
        public bool HasPlant => _plantView != null;

        private void OnMouseDown()
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {
                EventManager.EventManager.SendMessage(new CellClickMessage(this));
            }
        }        

        private void FixedUpdate()
        {
            if(_plant != null && _plant.Growing.IsGrowEnd == false)
            {
                _plant.Growing.GrowTick(Time.fixedDeltaTime);
            }
        }

        private void PutPlantHandler(IEventMessage eventMessage)
        {
            if (eventMessage is FarmCellPlantedMessage plantedMessage && plantedMessage.Cell == this)
            {
                PutPlant(plantedMessage.Plant);
            }
        }

        private void PutPlant(IPlant plant)
        {
            _plant = plant;
            _plantView = _plant.CreateView();
            _plantView.transform.SetParent(transform);
            _plantView.transform.localPosition = Vector3.zero;
        }

        private void OnEnable()
        {
            EventManager.EventManager.SubscribeMessage(typeof(FarmCellPlantedMessage), PutPlantHandler);
        }

        private void OnDisable()
        {
            EventManager.EventManager.UnSubscribeMessage(typeof(FarmCellPlantedMessage), PutPlantHandler);
        }
    }
}
