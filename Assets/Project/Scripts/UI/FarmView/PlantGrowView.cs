using FarmCore.Plants;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.UI;

namespace UI.FarmView
{
    public class PlantGrowView : MonoBehaviour
    {
        [SerializeField] private Text _text;
        private IGrowing _growing;
        private readonly string _timeFormat = "{0,1:mm:ss}";
        private Transform _viewTransform;
        private Camera _mainCamera;
        public void SetGrowing(IGrowing growing)
        {
            gameObject.SetActive(true);
            _growing = growing;
            _growing.GrowComplete += DisableView;
        }

        public void SetViewTransform(Transform view)
        {
            _viewTransform = view;
        }

        private void FixedUpdate()
        {
            UpdateView();
        }

        private void UpdateView()
        {
            if (_mainCamera != null)
            {
                transform.position = _mainCamera.WorldToScreenPoint(_viewTransform.position);
            }
            _text.text = _growing.GrowTimeCountDown.ToString("F1");
        }

        private void DisableView()
        {
            gameObject.SetActive(false);
        }
        private void Awake()
        {

            _mainCamera = Camera.main;
        }
    }
}
