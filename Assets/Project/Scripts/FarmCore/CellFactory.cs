using EventManager;
using System.Collections;
using System.Collections.Generic;
using UI.FarmView;
using UnityEngine;

namespace FarmCore
{
    public class CellFactory : MonoBehaviour
    {
        [SerializeField] private FarmCell m_CellPrefab;

        private FarmCell[] _spawnedCell;
        [SerializeField] private float _horizontalSpacing = 0.2f;
        [SerializeField] private float _verticalSpacing = 0.2f;       

        

        private void OnEnable()
        {
            EventManager.EventManager.SubscribeMessage(typeof(StartGameMessage), StartGame);
        }

        private void OnDisable()
        {
            EventManager.EventManager.UnSubscribeMessage(typeof(StartGameMessage), StartGame);
        }
        
        private void StartGame(IEventMessage eventMessage)
        {
            if(eventMessage is StartGameMessage gameMessage)
            {
                CreateFarm(gameMessage.Height, gameMessage.Width);
            }
        }

        public void CreateFarm(int height, int width)
        {
            _spawnedCell = new FarmCell[height * width];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var pos = new Vector3(x + _horizontalSpacing * x - width / 2, 0, y + _verticalSpacing * y - height / 2);

                    _spawnedCell[y * width + x] = Instantiate(m_CellPrefab, pos, Quaternion.identity);
                    _spawnedCell[y * width + x].gameObject.name = $"{nameof(FarmCell)} {x}_{y}";
                }
            }
        }
    }
}