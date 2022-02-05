using UnityEngine;

namespace SemihCelek.Merge
{
    public class FullSliceContainerState : ISliceContainerState
    {
        private SliceContainer _sliceContainer;

        public FullSliceContainerState(SliceContainer sliceContainer)
        {
            _sliceContainer = sliceContainer;
        }

        public void HandleSliceTrigger(Collider other)
        {
            var hasSlice = other.TryGetComponent(out Slice slice);
            if (hasSlice)
            {
                // in here check the score on the slice component, if its same on current slice merge them.
                Debug.Log("A Slice is collided, full state");
                // _sliceContainer.ChangeSliceContainerState(new FullSliceContainerState(_sliceContainer));
            }
        }
    }
}