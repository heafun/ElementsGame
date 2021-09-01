using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float accelarationForce, maxspeed, dashStrength;

    private Vector3 currentMovement = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        //Debug.Log("Speed:" + rigidbody.velocity.magnitude);
        if (rigidbody.velocity.magnitude < maxspeed * 0.8f) //<80% Speed
        {
            rigidbody.AddForce(currentMovement);
        }
        else if (rigidbody.velocity.magnitude <= maxspeed) //80% - 100% speed
        {
            float ratio = (maxspeed - rigidbody.velocity.magnitude) / (maxspeed - maxspeed * 0.7f);
            rigidbody.AddForce(Vector3.Lerp(Vector3.zero, currentMovement, ratio));
        }

            Vector3 lookDirection = rigidbody.velocity.normalized;

            lookDirection.y = 0f;

        if (Vector3.zero != lookDirection)
        {

            Debug.Log(lookDirection);

            transform.forward = lookDirection;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>();

        Vector3 movement = new Vector3(inputVector.x, 0, inputVector.y);

        movement = Quaternion.Euler(0, 45, 0) * movement;
        movement.Normalize();

        movement.Scale(new Vector3(accelarationForce, accelarationForce, accelarationForce));

        currentMovement = movement;
    }

    public void Dash(InputAction.CallbackContext context)
    {
        Vector3 movement = currentMovement.normalized;

        Rigidbody rigidbody = GetComponent<Rigidbody>();

        if (movement.Equals(Vector3.zero))
        {
            movement = transform.forward;
        }

        movement.Scale(new Vector3(dashStrength, dashStrength, dashStrength));

        if (rigidbody.velocity.magnitude <= maxspeed)
        {
            rigidbody.AddForce(movement, ForceMode.Impulse);
        }
    }
}
