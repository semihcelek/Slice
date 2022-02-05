using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SemihCelek.Merge
{
    public class SliceContainer : MonoBehaviour
    {
        private ISliceContainerState _sliceContainerState;

        private void Start()
        {
            _sliceContainerState = new EmptySliceContainerState(this);
            
        }

        private void OnTriggerEnter(Collider other)
        {
            _sliceContainerState.HandleSliceTrigger(other);
        }

        public void ChangeSliceContainerState(ISliceContainerState state)
        {
            _sliceContainerState = state;
            Debug.Log(state.GetType());
        }
    }
}