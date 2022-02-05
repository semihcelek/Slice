using System;
using UnityEngine;

namespace SemihCelek.Merge
{
    public class Slice : MonoBehaviour
    {
        public int Score { get; set; }
        
        public delegate void SliceActions();

        public SliceAnimationController SliceAnimationController;
        
        private Transform _cachedTransform;

        private bool _isArrived = false;

        [SerializeField]
        private Animator _animator;

        [SerializeField]
        private InputHandler _inputHandler;

        [SerializeField]
        private float _moveSpeed = 1f;

        private void Start()
        {
            _cachedTransform = transform;

            SliceAnimationController = new SliceAnimationController(_animator);
        }

        private void Update()
        {
            if (_inputHandler.Fire && !_isArrived)
            {
                SliceAnimationController.MoveToCircle();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            _isArrived = true;
        }
    }
}