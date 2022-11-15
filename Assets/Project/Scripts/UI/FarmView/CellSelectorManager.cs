using EventManager;
using FarmCore;
using FarmCore.Plants.GameData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.FarmView
{
    public class CellSelectorManager : MonoBehaviour
    {

        [SerializeField] private PlantSelectorView m_PlantSelector;

        private FarmCell _selectedCell;

        private Camera _mainCamera;

        private void CellClickHandler(IEventMessage clickMessage)
        {
            if (clickMessage is CellClickMessage message)
            {
                _selectedCell = message.Cell;
                if (message.Cell.HasPlant == false)
                {                    
                    m_PlantSelector.gameObject.SetActive(true);
                    m_PlantSelector.transform.position = _mainCamera.WorldToScreenPoint(message.Cell.transform.position);
                }
                if (message.Cell.HasPlant && message.Cell.Plant.Growing.IsGrowEnd)
                {
                    EventManager.EventManager.SendMessage(new PlantHarvestMessage(_selectedCell));
                }
            }
        }

        private void PlantSelect(PlantData plantData)
        {            
            m_PlantSelector.gameObject.SetActive(false);
            EventManager.EventManager.SendMessage(new PlantSelectMessage(_selectedCell, plantData));
        }

        private void Awake()
        {
            m_PlantSelector.Init();
            m_PlantSelector.PlantSelected += PlantSelect;
            _mainCamera = Camera.main;
        }

        private void OnEnable()
        {
            EventManager.EventManager.SubscribeMessage(typeof(CellClickMessage), CellClickHandler);

        }

        private void OnDisable()
        {
            EventManager.EventManager.UnSubscribeMessage(typeof(CellClickMessage), CellClickHandler);
        }


    }
}
