using FarmCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventManager
{
    public class CellClickMessage : IEventMessage
    {
        public FarmCell Cell { get; private set; }
        public CellClickMessage(FarmCell farmCell)
        {
            Cell = farmCell;
        }
    }
}
