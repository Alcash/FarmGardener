using EventManager;
using FarmCore.Plants.GameData;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static readonly string ExpName = "ExpName";
    [SerializeField] private ResourceCounterView m_ResourceViewPrefab;
    [SerializeField] private ResourceSpriteData m_ResourceSpriteData;
    private Dictionary<string, float> _resources = new Dictionary<string, float>();
    private Dictionary<string, ResourceCounterView> _resourceViews = new Dictionary<string, ResourceCounterView>();  

    private void OnEnable()
    {
        EventManager.EventManager.SubscribeMessage(typeof(ResourceChangeMessage), ResourceChangeHandler);
    }

    private void OnDisable()
    {
        EventManager.EventManager.UnSubscribeMessage(typeof(ResourceChangeMessage), ResourceChangeHandler);
    }

    private void ResourceChangeHandler(IEventMessage message)
    {
        if(message is ResourceChangeMessage changeMessage)
        {
            if(_resources.ContainsKey(changeMessage.Name) == false)
            {
                _resources.Add(changeMessage.Name, 0);
            }
            _resources[changeMessage.Name] += changeMessage.Count;

            ResourceUpdateView(changeMessage.Name, _resources[changeMessage.Name]);
        }
    }

    private void ResourceUpdateView(string resoureceName, float count)
    {
        if (_resourceViews.ContainsKey(resoureceName) == false)
        {
            AddNewView(resoureceName);
        }
        _resourceViews[resoureceName].Text.text = count.ToString();
    }

    private void AddNewView(string resoureceName)
    {
        var inst = Instantiate(m_ResourceViewPrefab, transform);
        var data = m_ResourceSpriteData.Datas.FirstOrDefault(x => x.Name == resoureceName);
        if (data != null)
        {
            inst.Image.sprite = data.Sprite;
        }
        else
        {
            //default sprite
            inst.Image.sprite = null;
        }
        Canvas.ForceUpdateCanvases();
        _resourceViews.Add(resoureceName, inst);
    }
}


