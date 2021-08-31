using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;

    [SerializeField]
    private bool ShowCenter;

    public GameObject Player;
    [SerializeField]
    private Vector3 RelativePosition;
    [SerializeField]
    private float FollowTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = Player.transform.position + RelativePosition;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, FollowTime);
    }

    private void OnDrawGizmosSelected()
    {
        if (ShowCenter) {
            Vector3 direction = transform.position + transform.forward * GetComponent<Camera>().farClipPlane;
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, direction);
        }
    }
}
