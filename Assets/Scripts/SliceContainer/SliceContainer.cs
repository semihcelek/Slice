using System;
using UnityEngine;

namespace SemihCelek.Merge.SliceContainer
{
    public class SliceContainer : MonoBehaviour
    {
        private ISliceContainerState _sliceContainerState;

        [SerializeField]
        public Transform _sliceMoveTarget;

        [SerializeField]
        public BoxCollider _BoxCollider;

        private void Awake()
        {
            _sliceContainerState = new EmptySliceContainerState(this);
            
        }

        private void Update()
        {
            _sliceContainerState.HandleUpdate();
        }

        private void OnTriggerEnter(Collider other)
        {
            _sliceContainerState.HandleSliceTrigger(other);
        }

        public void ChangeSliceContainerState(ISliceContainerState state)
        {
            _sliceContainerState = state;
        }

        public ISliceContainerState GetCurrentContainerState()
        {
            return _sliceContainerState;
        }

        public void MergeLeft(SliceContainer nextContainer)
        {
            _sliceContainerState.MergeLeft(nextContainer);
        }

        public void DestroySlice(GameObject slice)
        {
            Destroy(slice);
        }
    }
}