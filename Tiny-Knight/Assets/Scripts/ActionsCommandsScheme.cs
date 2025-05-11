using System.Collections.Generic;
using UnityEngine;

namespace Controls
{
    [CreateAssetMenu(menuName = "Controls/ActionsCommandScheme")]
    public class ActionsCommandsScheme : ScriptableObject
    {
        public List<ActionCommandPair> actionCommandList;
    }
}