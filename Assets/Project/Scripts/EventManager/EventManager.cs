using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace EventManager
{
    public class EventManager : MonoBehaviour
    {
        private static EventManager _instance;

        private void Awake()
        {
            if(_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            if (_instance == this)
            {
                _instance = null;
            }
        }

        private Dictionary<Type, Action<IEventMessage>> subscribedEvents = new Dictionary<Type, Action<IEventMessage>>();
        private List<IEventMessage> eventsRevieved = new List<IEventMessage>();
        public static void SubscribeMessage(Type messageType, Action<IEventMessage> action)
        {
            if (_instance.subscribedEvents.ContainsKey(messageType))
            {
                _instance.subscribedEvents[messageType] += action;
            }
            _instance.subscribedEvents.Add(messageType, action);
        }

        public static void UnSubscribeMessage(Type messageType, Action<IEventMessage> action)
        {
            if (_instance.subscribedEvents.ContainsKey(messageType))
            {
                _instance.subscribedEvents[messageType] -= action;
            }            
        }

        public static void SendMessage(IEventMessage message)
        {
            _instance.eventsRevieved.Add(message);
        }

        private void Update()
        {
            if (eventsRevieved.Count == 0)  return;

            foreach (IEventMessage message in eventsRevieved)
            {
                if(subscribedEvents.ContainsKey(message.GetType()))
                    subscribedEvents[message.GetType()]?.Invoke(message);
            }     
            
            eventsRevieved.Clear();           
        }
    }
}
