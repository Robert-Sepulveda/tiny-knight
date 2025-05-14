using UnityEngine;
using UnityEngine.InputSystem;

namespace Controls
{
    public class Command : ScriptableObject // scriptableObject allows us to assign a given inputaction
    {
        public virtual void Execute(InputAction action, GameObject gameObject = null) { } // action is the input, gameObject is the object to be affected

        // public virtual void FixedExecute(InputAction action, GameObject actor = null) { }
    }
}
