using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

namespace EventManager
{
    public class EventManager : MonoBehaviour
    {
        private static EventManager _instance;

        private void Awake()
        {
            Init();
        }

        private void Init()
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

        private static Dictionary<Type, Action<IEventMessage>> subscribedEvents = new Dictionary<Type, Action<IEventMessage>>();
        private static Queue<IEventMessage> eventsRevieved = new Queue<IEventMessage>();
        public static void SubscribeMessage(Type messageType, Action<IEventMessage> action)
        {           

            if (subscribedEvents.ContainsKey(messageType))
            {
                subscribedEvents[messageType] += action;
            }
            subscribedEvents.Add(messageType, action);
        }

        public static void UnSubscribeMessage(Type messageType, Action<IEventMessage> action)
        {
            if (_instance == null)
                return;

            if (subscribedEvents.ContainsKey(messageType))
            {
                subscribedEvents[messageType] -= action;
            }            
        }

        public static void SendMessage(IEventMessage message)
        {
            eventsRevieved.Enqueue(message);
        }

        private void Update()
        {
            if (eventsRevieved.Count == 0)  return;

            while(eventsRevieved.Count > 0)
            {
                var message = eventsRevieved.Dequeue();               
                if (subscribedEvents.ContainsKey(message.GetType()))
                {                    
                    subscribedEvents[message.GetType()]?.Invoke(message);
                }
            }      
        }
    }
}
