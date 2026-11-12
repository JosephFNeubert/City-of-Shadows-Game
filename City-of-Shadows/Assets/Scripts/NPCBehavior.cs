using UnityEngine;
using TMPro;
using System.Collections;

public class NPCBehavior : MonoBehaviour
{
    // Serialized fields for UI interaction.
    [SerializeField] private GameObject InteractPrompt;
    [SerializeField] private GameObject DialogBox;
    [SerializeField] private GameObject BlackBarTop;
    [SerializeField] private GameObject BlackBarBottom;
    [SerializeField] private TMP_Text DialogText;
    [SerializeField] private string[] DialogLines;
    [SerializeField] private float TypeSpeed = 0.0f;

    // Private helper variables.
    private int lineIndex = 0;
    private bool isInteracting = false;
    private bool canInteract = false;
    private bool playerInRange = false;

    // Checks each frame to see if the interaction is allowed (interaction prompt can be activated) and if 'E' is pressed to begin dialog or move to next line. 
    private void Update()
    {
        if (canInteract && !isInteracting && UnityEngine.InputSystem.Keyboard.current.eKey.wasPressedThisFrame)
        {
            StartDialog();
        }

        else if (isInteracting && UnityEngine.InputSystem.Keyboard.current.eKey.wasPressedThisFrame)
        {
            NextLine();
        }
    }

    // Starts dialog by activating the dialog box and starting the coroutine. 
    private void StartDialog()
    {
        canInteract = false;
        isInteracting = true;

        InteractPrompt.SetActive(false);

        DialogText.text = "";
        DialogBox.SetActive(true);

        BlackBarTop.SetActive(true);
        BlackBarBottom.SetActive(true);

        lineIndex = 0;
        StartCoroutine(WriteLine());
    }

    // Checks if a player object has entered the trigger to allow interaction.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isInteracting)
        {
            canInteract = true;
            InteractPrompt.SetActive(true);
        }

        playerInRange = true;
    }

    // Checks if a player object has exited the trigger to disallow interaction.
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            InteractPrompt.SetActive(false);
        }

        playerInRange = false;
    }

    // Coroutine to write each character of each line by a certain type speed.
    private IEnumerator WriteLine()
    {
        foreach (char c in DialogLines[lineIndex]) 
        {
            DialogText.text += c;
            yield return new WaitForSeconds(TypeSpeed);
        }
    }

    // Moves to next line after coroutine finishes, and terminates interaction if end of lines is reached.
    private void NextLine()
    {
        StopAllCoroutines();

        if (lineIndex < DialogLines.Length - 1)
        {
            DialogText.text = "";
            lineIndex++;
            StartCoroutine(WriteLine());
        }
        else
        {
            DialogBox.SetActive(false);
            BlackBarTop.SetActive(false);
            BlackBarBottom.SetActive(false);
            isInteracting = false;
            canInteract = playerInRange;
            InteractPrompt.SetActive(canInteract);
        }
    }
}
