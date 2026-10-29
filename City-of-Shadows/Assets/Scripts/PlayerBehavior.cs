using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    // Attributes
    public Rigidbody _rb;
    public float moveSpeed = 3.5f; // SET TO 3.5

    // Function to apply a linear velocity to the player's rigid body depending on keys pressed to allow movement
    void move()
    {
        float x = 0f;
        float z = 0f;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) 
                x = -1f * moveSpeed;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) 
                x = 1f * moveSpeed;
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) 
                z = 1f * moveSpeed;
            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) 
                z = -1f * moveSpeed;
        }

        _rb.linearVelocity = new Vector3(x, _rb.linearVelocity.y, z);
    }

    // Updates every frame to permit movement
    private void Update()
    {
        move();
    }
}
