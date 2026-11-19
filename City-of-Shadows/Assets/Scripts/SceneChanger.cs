using Microsoft.Win32.SafeHandles;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] public int sceneNumber;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Change scene!");
            GameObject.Find("Game_Controller").GetComponent<GameController>().changeScene(sceneNumber); // TODO: Fix this function implementation.
        }
    }
}
