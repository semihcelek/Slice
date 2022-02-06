using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SemihCelek.Merge.PlayerInput
{
    public class InputHandler : MonoBehaviour
    {
        public bool Fire { get; set; }

        private void Update()
        {
            Fire = Input.GetKey(KeyCode.Mouse0);
        }
    }
}