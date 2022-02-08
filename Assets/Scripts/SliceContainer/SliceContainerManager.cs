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
            FullSliceContainerState.OnCheckMerge += CheckEachContainerState;
        }

        private void OnDisable()
        {
            FullSliceContainerState.OnCheckMerge -= CheckEachContainerState;
        }

        private void CheckEachContainerState()
        {
            for (int i = _sliceContainers.GetLowerBound(0); i <= _sliceContainers.GetUpperBound(0); ++i)
            {
                var currentContainer = _sliceContainers[i];
                
                if (currentContainer.GetCurrentContainerState().GetType() == typeof(EmptySliceContainerState))
                {
                    continue;
                }

                var nextContainer = i switch
                {
                    6 => _sliceContainers[7],
                    7 => _sliceContainers[0],
                    _ => _sliceContainers[(i + 1) % _sliceContainers.GetUpperBound(0)]
                };

                if (nextContainer.GetCurrentContainerState().GetType() == typeof(EmptySliceContainerState))
                {
                    continue;
                }

                currentContainer.MergeLeft(nextContainer);
            }
        }
    }

    public delegate void SliceContainerActions();
}