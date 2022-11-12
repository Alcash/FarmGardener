using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FarmCore
{
    public class CellFactory : MonoBehaviour
    {
        [SerializeField] private FarmCell m_CellPrefab;

        private FarmCell[] _spawnedCell;
        private float _horizontalSpacing = 0.2f;
        private float _verticalSpacing = 0.2f;

        [SerializeField] private CellSelectorManager m_CellSelectorManager;

        private void Start()
        {
            CreateFarm(5, 5);
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