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
                plantMessage.cell.PutPlant(PlantFactory.Create(plantMessage.plant));
            }
        }

        private void PlantHarvestInteract(IEventMessage message)
        {
            if (message is PlantHarvestMessage plantMessage)
            {
                plantMessage.cell.Plant.Harvest();
            }
        }

        private void OnEnable()
        {
            EventManager.EventManager.SubscribeMessage(typeof(PlantSelectMessage), PlantCellInteract);
            EventManager.EventManager.SubscribeMessage(typeof(PlantHarvestMessage), PlantHarvestInteract);
        }

        private void OnDisable()
        {
            EventManager.EventManager.UnSubscribeMessage(typeof(PlantSelectMessage), PlantCellInteract);
            EventManager.EventManager.UnSubscribeMessage(typeof(PlantHarvestMessage), PlantHarvestInteract);
        }
    }
}
