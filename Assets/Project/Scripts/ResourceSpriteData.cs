using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Plants/sprite data", order = 1)]
public class ResourceSpriteData : ScriptableObject
{
    [SerializeField] private List<ResourceData> m_ResourceDatas = new List<ResourceData>();
    public List<ResourceData> Datas => m_ResourceDatas;
}
[Serializable]
public class ResourceData
{
    public string Name;
    public Sprite Sprite;
}