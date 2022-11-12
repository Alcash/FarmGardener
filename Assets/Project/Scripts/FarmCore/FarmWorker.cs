using EventManager;
using FarmCore.Plants;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FarmCore
{
    public class FarmWorker : MonoBehaviour
    {

        private void PlantCellInteract(IEventMessage message)
        {            
            if (message is PlantSelectMessage plantMessage)
            {
                Debug.Log($"PlantCellInteract cell{plantMessage.cell != null} plant {plantMessage.plant != null} ");
                plantMessage.cell.PutPlant(PlantFactory.Create(plantMessage.plant));
            }
        }

        private void OnEnable()
        {
            EventManager.EventManager.SubscribeMessage(typeof(PlantSelectMessage), PlantCellInteract);
        }

        private void OnDisable()
        {
            EventManager.EventManager.UnSubscribeMessage(typeof(PlantSelectMessage), PlantCellInteract);
        }
    }
}
