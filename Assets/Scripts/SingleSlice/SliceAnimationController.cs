using System;
using UnityEngine;

namespace SemihCelek.Merge
{
    public class SliceAnimationController
    {
        private Animator _sliceAnimator;

        private int MoveToContainerAnimationHash;
        private int MoveToCircleAnimationHash;

        public SliceAnimationController(Animator sliceAnimator)
        {
            _sliceAnimator = sliceAnimator;
            MoveToContainerAnimationHash = Animator.StringToHash("MoveToContainer");
            MoveToCircleAnimationHash = Animator.StringToHash("MoveToCircle");
        }
        
        public void OnMoveContainer()
        {
            _sliceAnimator.SetBool(MoveToContainerAnimationHash,true);
        }

        public void MoveToCircle()
        {
            _sliceAnimator.SetBool(MoveToCircleAnimationHash, true);
        }
    }
}