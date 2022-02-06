using SemihCelek.Merge.SingleSlice;
using SemihCelek.Merge.Utilities;
using UnityEngine;

namespace SemihCelek.Merge.SliceContainer
{
    public class EmptySliceContainerState : ISliceContainerState
    {
        private SliceContainer _sliceContainer;

        public static event SliceGenerationAction OnGenerateSlice;

        public EmptySliceContainerState(SliceContainer sliceContainer)
        {
            _sliceContainer = sliceContainer;
        }

        public void HandleSliceTrigger(Collider other)
        {
            var hasSlice = other.TryGetComponent(out Slice slice);
            if (!hasSlice) return;
            
            slice.SliceAnimationController.OnMoveContainer();
            // slice.transform.SetParent(_sliceContainer.transform, false);
            slice.transform.parent.SetParent(_sliceContainer.transform, false);
            slice.transform.localScale = new Vector3(1.6f,0.5f,7.75f);
                
            _sliceContainer.ChangeSliceContainerState(new FullSliceContainerState(_sliceContainer, slice));
            
            OnGenerateSlice?.Invoke();
        }

        public void MergeLeft(SliceContainer nextContainer)
        {
            throw new System.NotImplementedException();
        }
    }
}