using System;
using SemihCelek.Merge.SliceContainer;
using UnityEngine;

namespace SemihCelek.Merge.Utilities
{
    public class SliceGeneratorController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _slicePrefab;
        
        private void GenerateRandomSlice()
        {
            var slice = Instantiate(_slicePrefab);
        }

        private void Awake()
        {
            FullSliceContainerState.OnGenerateSlice += GenerateRandomSlice;
        }

        private void OnDestroy()
        {
            FullSliceContainerState.OnGenerateSlice -= GenerateRandomSlice;
        }
    }


    public delegate void SliceGenerationAction();
}