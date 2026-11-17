using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogData", menuName = "Scriptable Objects/DialogData")]
public class DialogData : ScriptableObject
{
    // Create internal state dialog class.
    [Serializable]
    public class StateDialog
    {
        public int gameState;

        [TextArea(2, 5)]
        public string[] lines;
    }

    // Serialized field of state dialog classes.
    [SerializeField] private StateDialog[] stateDialogs;

    // Function to get lines from the serialized field based on game state.
    public bool GetLines(int state, out string[] lines)
    {
        foreach (StateDialog dialog in stateDialogs)
        {
            if (dialog.gameState == state)
            {
                lines = dialog.lines;
                return lines != null && lines.Length > 0;
            }
        }

        lines = null;
        return false;
    }
}
