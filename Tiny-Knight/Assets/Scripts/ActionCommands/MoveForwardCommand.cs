using UnityEngine;
using UnityEngine.InputSystem;

namespace Controls
{
    [CreateAssetMenu(menuName = "Controls/Commands/MoveForwardCommand")]
    public class MoveForwardCommand : Command
    {
        public override void Execute(InputAction action, GameObject actor)
        {
            if(action.WasPressedThisFrame())
                actor.GetComponent<Player>().Move("forward");
        }
    }
}