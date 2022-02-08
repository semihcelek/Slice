using UnityEngine;

namespace SemihCelek.Merge.SliceContainer
{
    public interface ISliceContainerState
    {
        void HandleSliceTrigger(Collider other);


        void MergeLeft(SliceContainer nextContainer);
        void HandleUpdate();
    }
}