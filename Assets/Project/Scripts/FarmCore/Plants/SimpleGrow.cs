using FarmCore.Plants.GameData;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace FarmCore.Plants
{
    public class SimpleGrow : IGrowing
    {
        private float _growTimer = 0;
        private float _growTimeEnd;

        public event Action GrowComplete;

        public float GrowValue => _growTimer / _growTimeEnd;

        private GameObject _view;

        public SimpleGrow(PlantData plantData)
        {
            _growTimeEnd = plantData.GrowTime;

        }

        public void GrowTick(float deltaTime)
        {
            if (GrowValue < 1)
            {
                _growTimer += deltaTime;
                _view.transform.localScale = Vector3.one * GrowValue;
            }
            else
            {
                GrowComplete?.Invoke();                
            }
        }

        public void SetGameObject(GameObject gameObject)
        {
            _view = gameObject;
            _view.transform.localScale = Vector3.one * GrowValue;
        }
    }
}
