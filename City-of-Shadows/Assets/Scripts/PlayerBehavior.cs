using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public Rigidbody _rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 1000f;
    public float moveSpeed = 1000f;

    void move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        _rb.linearVelocity = new Vector3(x, _rb.linearVelocity.y, z);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {/*
        if (Input.GetKey("w"))
            _rb.AddForce(forwardForce * Time.deltaTime * -1, 0, 0, ForceMode.VelocityChange);
        if (Input.GetKey("a"))
            _rb.AddForce(0, 0, sidewaysForce * Time.deltaTime * -1, ForceMode.VelocityChange);
        if (Input.GetKey("d"))
            _rb.AddForce(0, 0, sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);
        if (Input.GetKey("s"))
            _rb.AddForce(forwardForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange); */


    }

    private void Update()
    {
        move();
    }
}
