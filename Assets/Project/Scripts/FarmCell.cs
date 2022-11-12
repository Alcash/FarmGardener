using EventManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmCell : MonoBehaviour
{
    private void OnMouseDown()
    {
        EventManager.EventManager.SendMessage(new CellClickMessage(this));
    }
}
