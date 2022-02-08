using System;
using System.Collections;
using SemihCelek.Merge.PlayerInput;
using SemihCelek.Merge.SliceContainer;
using UnityEngine;

namespace SemihCelek.Merge.SingleSlice
{
    public class Slice : MonoBehaviour
    {
        public int Score { get; set; }

        public SliceAnimationController SliceAnimationController;

        private Transform _cachedTransform;

        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private Transform _targetPosition;

        [SerializeField]
        private BoxCollider _boxCollider;

        private void Start()
        {
            _cachedTransform = transform;

            SliceAnimationController = new SliceAnimationController(_animator);

            InputHandler.OnClickFireButton += StartGoForwardCoroutine;
        }

        private void OnDestroy()
        {
            InputHandler.OnClickFireButton -= StartGoForwardCoroutine;
        }

        // private void Update()
        // {
        //     if (!_inputHandler.Fire) return;
        //
        //     StartCoroutine(SmoothlyGoForwardCoroutine());
        // }

        private void StartGoForwardCoroutine()
        {
            StartCoroutine(SmoothlyGoForwardCoroutine());
            InputHandler.OnClickFireButton -= StartGoForwardCoroutine;
        }
    
        

        private IEnumerator SmoothlyGoForwardCoroutine()
        {
            var time = 0.6f;

            var startPosition = _cachedTransform.position;
            var destinationPosition = _targetPosition.position;

            var elapsedTime = 0f;

            while (elapsedTime < time)
            {
                _cachedTransform.position =
                    Vector3.Lerp(startPosition, destinationPosition, (elapsedTime / time));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            
        }

        private void OnTriggerEnter(Collider other)
        {
            var isSliceContainer = other.TryGetComponent(out SliceContainer.SliceContainer sliceContainer);

            if (!isSliceContainer) return;

            // if (sliceContainer.GetCurrentContainerState().GetType() == typeof(FullSliceContainerState)) return;
            //
            // _boxCollider.enabled = false;
            // Debug.Log("boxcollider false");
        }
    }
}