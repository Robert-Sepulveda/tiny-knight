using UnityEngine;
using UnityEngine.InputSystem;

namespace Controls
{
    [CreateAssetMenu(menuName = "Controls/Commands/MoveBackwardCommand")]
    public class MoveBackwardCommand : Command
    {
        public override void Execute(InputAction action, GameObject actor)
        {
            if(action.WasPressedThisFrame())
                actor.GetComponent<Player>().Move("backward");
        }
    }
}