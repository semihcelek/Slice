using SemihCelek.Merge.SingleSlice;
using UnityEngine;

namespace SemihCelek.Merge.SliceContainer
{
    public class FullSliceContainerState : ISliceContainerState
    {
        private SliceContainer _sliceContainer;
        private Slice _slice;
        

        public FullSliceContainerState(SliceContainer sliceContainer, Slice slice)
        {
            _sliceContainer = sliceContainer;
            _slice = slice;
        }

        public void HandleSliceTrigger(Collider other)
        {
            var hasSlice = other.TryGetComponent(out Slice slice);
            if (hasSlice)
            {
                // in here check the score on the slice component, if its same on current slice merge them.
                // _sliceContainer.ChangeSliceContainerState(new FullSliceContainerState(_sliceContainer));
            }
        }

        public void MergeLeft(SliceContainer nextContainer)
        {
            _slice.SliceAnimationController.MergeLeft();
        }
    }
}