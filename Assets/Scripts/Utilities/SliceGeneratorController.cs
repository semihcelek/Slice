using System;
using SemihCelek.Merge.SliceContainer;
using UnityEngine;

namespace SemihCelek.Merge.Utilities
{
    public class SliceGeneratorController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _slicePrefab;
        
        public static event SliceContainerActions OnCheckMerge;


        private void GenerateRandomSlice()
        {
            var slice = Instantiate(_slicePrefab, transform.position, transform.rotation);
            OnCheckMerge?.Invoke();
        }

        private void Awake()
        {
            EmptySliceContainerState.OnGenerateSlice += GenerateRandomSlice;
        }

        private void OnDestroy()
        {
            EmptySliceContainerState.OnGenerateSlice -= GenerateRandomSlice;
        }
    }


    public delegate void SliceGenerationAction();
}