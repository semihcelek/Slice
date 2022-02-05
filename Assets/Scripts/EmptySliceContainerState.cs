using UnityEngine;

namespace SemihCelek.Merge
{
    public class EmptySliceContainerState : ISliceContainerState
    {
        private SliceContainer _sliceContainer;

        public event Slice.SliceActions MoveToContainer;

        public EmptySliceContainerState(SliceContainer sliceContainer)
        {
            _sliceContainer = sliceContainer;
        }

        public void HandleSliceTrigger(Collider other)
        {
            var hasSlice = other.TryGetComponent(out Slice slice);
            if (hasSlice)
            {
                slice.SliceAnimationController.OnMoveContainer();
                slice.transform.SetParent(_sliceContainer.transform);
                MoveToContainer?.Invoke();
                
                Debug.Log("A Slice is collided, empty state");
                _sliceContainer.ChangeSliceContainerState(new FullSliceContainerState(_sliceContainer));
            }
        }
    }
}