using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventManager
{
    public class ResourceChangeMessage : IEventMessage
    {        
        public string Name { get; private set; }
        public float Count { get; private set; }

        public ResourceChangeMessage(string resourceName, float resourceCount)
        {
            Name = resourceName;
            Count = resourceCount;
        }
    }
}
