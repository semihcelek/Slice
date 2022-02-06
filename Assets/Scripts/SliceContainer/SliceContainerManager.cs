using System;
using SemihCelek.Merge.Utilities;
using UnityEngine;

namespace SemihCelek.Merge.SliceContainer
{
    public class SliceContainerManager : MonoBehaviour
    {
        [SerializeField]
        private SliceContainer[] _sliceContainers = new SliceContainer[8];

        private void Start()
        {
            SliceGeneratorController.OnCheckMerge += CheckEachContainerState;
        }

        private void OnDisable()
        {
            SliceGeneratorController.OnCheckMerge -= CheckEachContainerState;
        }

        // In here, create a event function which loops through every slice container, and merge accordingly

        private void CheckEachContainerState()
        {
            for (int i = _sliceContainers.GetLowerBound(0); i <= _sliceContainers.GetUpperBound(0); ++i)
            {
                var currentContainer = _sliceContainers[i];

                // Debug.Log(currentContainer.GetCurrentContainerState().GetType());

                if (currentContainer.GetCurrentContainerState().GetType() == typeof(EmptySliceContainerState))
                {
                    continue;
                }

                var nextContainer = _sliceContainers[(i + 1) % _sliceContainers.GetUpperBound(0)];

                // Debug.Log(nextContainer.GetCurrentContainerState().GetType());

                if (nextContainer.GetCurrentContainerState().GetType() == typeof(EmptySliceContainerState))
                {
                    continue;
                }

                Debug.Log("Merge left");

                currentContainer.MergeLeft(nextContainer);


                // var previousContainer = _sliceContainers[(i - 1) % _sliceContainers.GetUpperBound(0)];
                // Debug.Log(previousContainer.GetCurrentContainerState().GetType());
                //
                // if (previousContainer.GetCurrentContainerState().GetType() == typeof(EmptySliceContainerState))
                // {
                //     continue;
                // }
                //
                // Debug.Log("Merge right");
            }
        }
    }

    public delegate void SliceContainerActions();
}