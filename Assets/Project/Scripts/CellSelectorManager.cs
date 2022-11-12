using EventManager;
using GameData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellSelectorManager : MonoBehaviour
{

    [SerializeField] private PlantSelectorView m_PlantSelector;

    private FarmCell _selectedCell;
    private PlantData _selectedPlant;

    private Camera _mainCamera;

    private void CellClickHandler(IEventMessage clickMessage)
    {
        if (clickMessage is CellClickMessage message)
        {
            m_PlantSelector.gameObject.SetActive(true);
            m_PlantSelector.transform.position = Camera.main.WorldToScreenPoint(message.cell.transform.position);
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
