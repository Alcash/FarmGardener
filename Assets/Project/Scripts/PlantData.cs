using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameData
{
    [CreateAssetMenu(fileName = "Data", menuName = "Plants/plant data", order = 1)]
    public class PlantData : ScriptableObject
    {
        [SerializeField] private Sprite m_View2d;
        public Sprite View2d => m_View2d;
        [SerializeField] private GameObject m_View3d;
        public GameObject View3d => m_View3d;
        [SerializeField] private float m_GrowTime;
        public float GrowTime => m_GrowTime;
        [SerializeField] private float m_ExpForGrow;
        public float ExpForGrow => m_ExpForGrow;
    }
}
