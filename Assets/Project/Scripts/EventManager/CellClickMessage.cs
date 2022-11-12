using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventManager
{
    public class CellClickMessage : IEventMessage
    {
        public FarmCell cell { get; private set; }
        public CellClickMessage(FarmCell farmCell)
        {
            cell = farmCell;
        }
    }
}
