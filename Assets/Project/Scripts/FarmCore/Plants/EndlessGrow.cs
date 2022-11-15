using FarmCore.Plants.GameData;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FarmCore.Plants
{
    public class EndlessGrow : IGrowing
    {
        private bool _growEnd;
        private float _growTimer = 0;
        private float _growTimeEnd;

        public event Action GrowComplete;

        public float GrowValue => _growTimer / _growTimeEnd;

        public float GrowTimeCountDown => _growTimeEnd - _growTimer;

        public bool IsGrowEnd => false;

        private GameObject _view;

        public EndlessGrow(PlantData plantData)
        {
            _growTimeEnd = plantData.GrowTime;
            _growEnd = false;
        }

        public void GrowTick(float deltaTime)
        {
            if (GrowValue < 1)
            {
                _growTimer += deltaTime;
                _view.transform.localScale = Vector3.one * GrowValue;
            }
            else if (_growEnd == false)
            {
                _growEnd = true;
                _growTimer = _growTimeEnd;
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
