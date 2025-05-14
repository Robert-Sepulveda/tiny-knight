using UnityEngine;
using UnityEngine.InputSystem;

namespace Controls
{
    [CreateAssetMenu(menuName = "Controls/Commands/SwapCommand")]
    public class SwapCommand : Command
    {
        public override void Execute(InputAction action, GameObject actor)
        {
            if(action.WasPressedThisFrame())
                actor.GetComponent<Player>().Swap();
        }
    }
}