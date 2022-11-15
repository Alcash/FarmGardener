using EventManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static readonly string ExpName = "ExpName";
    private Dictionary<string, float> _resources = new Dictionary<string, float>();

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
        }
    }
}
