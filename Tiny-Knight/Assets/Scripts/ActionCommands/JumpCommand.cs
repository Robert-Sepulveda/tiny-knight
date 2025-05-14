using UnityEngine;
using UnityEngine.InputSystem;

namespace Controls
{
    [CreateAssetMenu(menuName = "Controls/Commands/JumpingCommand")]
    public class JumpCommand : Command
    {
        public override void Execute(InputAction action, GameObject actor)
        {
            if(action.WasPressedThisFrame())
                actor.GetComponent<Player>().Jump();
        }
    }
}