using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Controls
{
    [System.Serializable]
    public class ActionCommandPair
    {
        public InputAction key;
        public Command val;
    }

    public class InputHandler : MonoBehaviour
    {
        // set the dictionary types as the class we just described
        List<ActionCommandPair> actionCommandList = new List<ActionCommandPair>();
        public Dictionary<InputAction, Command> bindActions = new Dictionary<InputAction, Command>();
        public Dictionary<Command, InputAction> reversedBindActions = new Dictionary<Command,InputAction>(); // allows you reverse search an inputaction
        public ActionsCommandsScheme defaultScheme;

        GameObject player;

        // only allow one instance of inputHandler
        #region Singleton
        public static InputHandler instance;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        #endregion Singleton

        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            // the default controller scheme, to swap
            InputHandler.instance.UpdateActionsCommandsList(defaultScheme.actionCommandList);
            InputHandler.instance.UpdateActionsCommandsBindings();
        }

        void Update()
        {
            foreach(var action in bindActions)
            {
                // commands will determine key presses for robust logic
                action.Value.Execute(action.Key,player);
            }
        }

        // activates once the object is enabled
        void OnEnable()
        {
            UpdateActionsCommandsBindings();
        }

        // when handler is disabled, destroy all mappings to remove player control
        void OnDisable()
        {
            foreach(var action in bindActions)
                action.Key.Disable();
        }

        // small method allows to update the dictionaries of controls
        public void UpdateActionsCommandsBindings()
        {
            // start by clearing the previous command set
            bindActions.Clear();
            reversedBindActions.Clear();
            foreach (var acp in actionCommandList)
            {
                bindActions[acp.key] = acp.val;
                reversedBindActions[acp.val] = acp.key;
                acp.key.Enable(); // listen for action
            }
        }

        // we can queue a control change, that way, we don't have to switch immediately
        public void UpdateActionsCommandsList(List<ActionCommandPair> aList)
        {
            actionCommandList = aList;
        }
    }
}
