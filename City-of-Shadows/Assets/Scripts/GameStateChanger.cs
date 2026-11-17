using Unity.VisualScripting;
using UnityEngine;

public class GameStateChanger : MonoBehaviour
{
    private bool changeState = false;
    private bool hasChangedState = false;
    private float delay;
    private float timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            changeState = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            changeState = false;
        }
    }

    private void Update()
    {
        if (changeState && UnityEngine.InputSystem.Keyboard.current.eKey.wasPressedThisFrame && !hasChangedState)
        {
            timer += Time.deltaTime;
            if (timer > delay)
            {
                GameController.incrementGameState();
                hasChangedState = true;
            }
        }
    }
}
