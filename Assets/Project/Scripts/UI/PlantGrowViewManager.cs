using EventManager;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.VersionControl;
using UnityEngine;

namespace UI
{
    public class PlantGrowViewManager : MonoBehaviour
    {
        [SerializeField] private PlantGrowView _plantGrowViewPrefab;
        private List<PlantGrowView> _simplePool = new List<PlantGrowView>();
        private Camera _mainCamera;
        private PlantGrowView GetItem()
        {
            var item = _simplePool.FirstOrDefault(x => x.gameObject.activeSelf == false);

            if (item == null)
            {
                item = Instantiate(_plantGrowViewPrefab, transform);
                _simplePool.Add(item);
            }
            return item;
        }

        private void PutPlantHandler(IEventMessage eventMessage)
        {
            if (eventMessage is FarmCellPlantedMessage plantedMessage)
            {
                var view = GetItem();
                view.transform.position = _mainCamera.WorldToScreenPoint(plantedMessage.Cell.transform.position);
                view.SetGrowing(plantedMessage.Plant.Growing);
            }
        }

        private void Awake()
        {
            
            _mainCamera = Camera.main;
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
