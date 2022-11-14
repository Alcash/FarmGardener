using FarmCore.Plants;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlantGrowView : MonoBehaviour
    {
        [SerializeField] private Text _text;
        private IGrowing _growing;
        private readonly string _timeFormat = "{0,1:mm:ss}";

        public void SetGrowing(IGrowing growing)
        {
            gameObject.SetActive(true);
            _growing = growing;
            _growing.GrowComplete += DisableView;
        }

        private void FixedUpdate()
        {
            UpdateView();
        }

        private void UpdateView()
        {
            _text.text = _growing.GrowTimeCountDown.ToString("F1");
        }

        private void DisableView()
        {
            gameObject.SetActive(false);
        }
    }
}
