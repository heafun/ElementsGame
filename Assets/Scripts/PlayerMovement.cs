using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float movespeed;
    [SerializeField]
    private float maxspeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void movePlayer(Vector3 movement)
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        movement.Scale(new Vector3(movespeed, movespeed, movespeed));
        Debug.Log("Speed:" + rigidbody.velocity.magnitude);
        if (rigidbody.velocity.magnitude <= maxspeed)
        {
            rigidbody.AddForce(movement);
        } else
        {
            rigidbody.velocity = rigidbody.velocity.normalized * maxspeed;
        }
    }
}
