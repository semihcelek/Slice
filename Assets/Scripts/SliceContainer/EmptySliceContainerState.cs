using SemihCelek.Merge.SingleSlice;
using SemihCelek.Merge.Utilities;
using UnityEngine;

namespace SemihCelek.Merge.SliceContainer
{
    public class EmptySliceContainerState : ISliceContainerState
    {
        private SliceContainer _sliceContainer;

        public EmptySliceContainerState(SliceContainer sliceContainer)
        {
            _sliceContainer = sliceContainer;
        }

        public void HandleSliceTrigger(Collider other)
        {
            var hasSlice = other.TryGetComponent(out Slice slice);
            if (!hasSlice) return;

            slice.transform.SetParent(_sliceContainer.transform);

            _sliceContainer.ChangeSliceContainerState(new FullSliceContainerState(_sliceContainer, slice));
        }

        public void MergeLeft(SliceContainer nextContainer)
        {
        }

        public void HandleUpdate()
        {
        }
    }
}