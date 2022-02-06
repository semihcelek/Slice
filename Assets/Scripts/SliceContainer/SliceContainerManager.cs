using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SemihCelek.Merge
{
    public class SliceContainerManager : MonoBehaviour
    {
        [SerializeField]
        private SliceContainer[] _sliceContainers = new SliceContainer[8];
        
        private void Start()
        {
            Debug.Log(_sliceContainers[0].GetCurrentContainerState().GetType());
        }
        
        // In here, create a event function which loops through every slice container, and merge accordingly

        private void Update()
        {
        }
        
    }
}