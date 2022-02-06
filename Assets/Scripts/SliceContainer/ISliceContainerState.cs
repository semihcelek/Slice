using UnityEngine;

namespace SemihCelek.Merge
{
    public interface ISliceContainerState
    {
        void HandleSliceTrigger(Collider other);
        
    }
}