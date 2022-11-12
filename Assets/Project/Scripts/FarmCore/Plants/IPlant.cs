
using UnityEngine;

namespace FarmCore.Plants
{
    public interface IPlant
    {
        GameObject CreateView(Vector3 position);
        void Harvest();
        void GrowTick(float deltaTime);

    }
}


