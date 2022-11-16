using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventManager
{
    public class StartGameMessage : IEventMessage
    {
        public int Height { get; private set; }
        public int Width { get; private set; }

        public StartGameMessage(int height, int width)
        {
            Height = height;
            Width = width;
        }   
    }
}
