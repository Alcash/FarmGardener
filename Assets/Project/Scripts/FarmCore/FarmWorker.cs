using EventManager;
using FarmCore.Plants;
using System;
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
                StartCoroutine(MoveToFarmInteract(plantMessage.Cell,
                    () =>
                    {
                        PutPlant(plantMessage);
                    })
                    );

            }

        }

        private void PlantHarvestInteract(IEventMessage message)
        {
            if (message is PlantHarvestMessage plantMessage)
            {
                StartCoroutine(MoveToFarmInteract(plantMessage.Cell,
                    () =>
                    {
                        HarvestPlant(plantMessage);
                    })
                    );

            }
        }

        private IEnumerator MoveToFarmInteract(FarmCell point, Action callback)
        {
            //moving
            yield return null;
            callback?.Invoke();
        }

        private void PutPlant(PlantSelectMessage plantMessage)
        {
            EventManager.EventManager.SendMessage(new FarmCellPlantedMessage(plantMessage.Cell,
                PlantFactory.Create(plantMessage.Plant)));
            
        }

        private void HarvestPlant(PlantHarvestMessage plantMessage)
        {
            plantMessage.Cell.Plant.Harvesting.Harvest();
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
