using UnityEngine;

public class GameStateChanger : MonoBehaviour
{
    private bool changeState = false;
    public int maxStateChanges;
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
        if (changeState && UnityEngine.InputSystem.Keyboard.current.qKey.wasPressedThisFrame && GameController.getGameState() <= maxStateChanges)
        {
            timer += Time.deltaTime;
            if (timer > delay)
            {
                GameController.incrementGameState();
            }
        }
    }
}
