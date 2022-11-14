using EventManager;
using FarmCore.Plants;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
           EventManager.EventManager.SendMessage(new CellClickMessage(this));   
        }

        public void PutPlant(IPlant plant)
        {
            _plant = plant;
            _plantView = _plant.CreateView();
            _plantView.transform.SetParent(transform);
            _plantView.transform.localPosition = Vector3.zero;
        }

        private void FixedUpdate()
        {
            if(_plant != null && _plant.IsGrowEnd == false)
            {
                _plant.GrowTick(Time.fixedDeltaTime);
            }
        }
    }
}
