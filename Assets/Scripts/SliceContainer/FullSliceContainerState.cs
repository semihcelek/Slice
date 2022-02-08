using System.Collections;
using SemihCelek.Merge.SingleSlice;
using SemihCelek.Merge.Utilities;
using UnityEngine;

namespace SemihCelek.Merge.SliceContainer
{
    public class FullSliceContainerState : ISliceContainerState
    {
        private SliceContainer _sliceContainer;
        private Slice _slice;

        private bool _isContainerEntered;

        private Vector3 _rotationInContainer;
        private Vector3 _rotationInNextContainer;

        public static event SliceGenerationAction OnGenerateSlice;
        public static event SliceContainerActions OnCheckMerge;


        public FullSliceContainerState(SliceContainer sliceContainer, Slice slice)
        {
            _sliceContainer = sliceContainer;
            _slice = slice;
            _rotationInContainer = new Vector3(90, -90, -90);
            _rotationInNextContainer = new Vector3(45, -90, -90);
            slice.StartCoroutine(MoveToSliceContainerCoroutine());
        }

        public void HandleSliceTrigger(Collider other)
        {
        }

        public void MergeLeft(SliceContainer nextContainer)
        {
            _slice.StartCoroutine(MergeWithNextContainerCoroutine(nextContainer));
        }

        public void HandleUpdate()
        {
        }

        private IEnumerator MergeWithNextContainerCoroutine(SliceContainer nextContainer)
        {
            var time = 1f;

            var elapsedTime = 0f;

            while (elapsedTime < time)
            {
                var sliceTransform = _slice.transform;
                var nextSliceTransform = nextContainer.transform;

                sliceTransform.position =
                    Vector3.Lerp(sliceTransform.position, nextSliceTransform.GetChild(0).position, elapsedTime / time);

                sliceTransform.localRotation = Quaternion.Lerp(sliceTransform.localRotation,
                    Quaternion.Euler(_rotationInNextContainer), elapsedTime / time);

                elapsedTime += Time.deltaTime;

                yield return null;
            }

            _sliceContainer.ChangeSliceContainerState(new EmptySliceContainerState(_sliceContainer));

            _sliceContainer.DestroySlice(nextContainer.transform.GetChild(0).gameObject);
        }

        private IEnumerator MoveToSliceContainerCoroutine()
        {
            var time = 1f;

            var elapsedTime = 0f;

            while (elapsedTime < time)
            {
                var sliceTransform = _slice.transform;

                sliceTransform.position = Vector3.MoveTowards(sliceTransform.position,
                    _sliceContainer._sliceMoveTarget.position, Time.deltaTime);


                sliceTransform.localEulerAngles = _rotationInContainer;

                elapsedTime += Time.deltaTime;

                yield return null;
            }

            OnCheckMerge?.Invoke();
            OnGenerateSlice?.Invoke();
        }
    }
}