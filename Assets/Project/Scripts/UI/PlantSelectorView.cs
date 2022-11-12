using FarmCore.Plants.GameData;
using System;
using UnityEngine;

public class PlantSelectorView : MonoBehaviour
{
    public event Action<PlantData> PlantSelected;
    [SerializeField] private PlantData[] m_PlantDatas;

    [SerializeField] private Plant2dView[] m_Plant2dViews;    

    public void Init()
    {
        for (int i = 0; i < m_PlantDatas.Length; i++)
        {
            var data = m_PlantDatas[i];
            m_Plant2dViews[i].Image.sprite = data.View2d;
            m_Plant2dViews[i].Button.onClick.AddListener(() => { PlantSelected?.Invoke(data); });
        }
    }   
}
