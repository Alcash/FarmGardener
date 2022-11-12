using GameData;
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
            m_Plant2dViews[i].Image.sprite = m_PlantDatas[i].View2d;
            m_Plant2dViews[i].Button.onClick.AddListener(() => { PlantSelected?.Invoke(m_PlantDatas[i]); });
        }
    }   
}
