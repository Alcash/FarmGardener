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

        private void OnMouseDown()
        {
            EventManager.EventManager.SendMessage(new CellClickMessage(this));
        }

        public void PutPlant(IPlant plant)
        {
            _plant = plant;
            _plant.CreateView(transform.position);
        }

        private void FixedUpdate()
        {
            if(_plant != null)
            {
                _plant.GrowTick(Time.fixedDeltaTime);
            }
        }
    }
}
