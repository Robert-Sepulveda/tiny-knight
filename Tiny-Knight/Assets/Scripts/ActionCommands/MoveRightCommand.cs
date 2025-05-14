using UnityEngine;
using UnityEngine.InputSystem;

namespace Controls
{
    [CreateAssetMenu(menuName = "Controls/Commands/MoveRightCommand")]
    public class MoveRightCommand : Command
    {
        public override void Execute(InputAction action, GameObject actor)
        {
            if(action.WasPressedThisFrame())
                actor.GetComponent<Player>().Move("right");
        }
    }
}