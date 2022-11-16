using EventManager;
using FarmCore.Plants;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace FarmCore
{
    public class FarmWorker : MonoBehaviour
    {

        [SerializeField] private float m_CellNearDistance = 0.3f;
        [SerializeField] private NavMeshAgent m_NavAgent;
        private Coroutine _jobCoroutine;
        private void PlantCellInteract(IEventMessage message)
        {
            if (message is PlantSelectMessage plantMessage)
            {
                if(_jobCoroutine != null)
                {
                    StopCoroutine(_jobCoroutine);
                }
                _jobCoroutine = StartCoroutine(MoveToFarmInteract(plantMessage.Cell,
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
                if (_jobCoroutine != null)
                {
                    StopCoroutine(_jobCoroutine);
                }
                _jobCoroutine = StartCoroutine(MoveToFarmInteract(plantMessage.Cell,
                    () =>
                    {
                        HarvestPlant(plantMessage);
                    })
                    );

            }
        }

        private IEnumerator MoveToFarmInteract(FarmCell point, Action callback)
        {                    
            m_NavAgent.destination = point.transform.position;
            m_NavAgent.isStopped = false;
           
            while(m_NavAgent.pathPending)
            {
                yield return null;
            }

            while (m_NavAgent.remainingDistance > m_CellNearDistance)
            {
                yield return null;
            }
            m_NavAgent.isStopped = true;
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
