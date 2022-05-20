using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCharacter : MonoBehaviour
{
    public static MovementCharacter Instance;

    //Declare variables,
    [SerializeField] private Camera Orthographic;
    [SerializeField] private float sensivity;
    [SerializeField] private int speed;

    private Rigidbody rigidbody;
    private Vector3 firstPosition;
    private Vector3 lastPosition;
    private Vector3 difference;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        rigidbody = gameObject.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, new Vector3(difference.x, rigidbody.velocity.y, speed), 11.2f);
    }
    private void Update()
    {
        firstPosition = Vector3.Lerp(firstPosition, lastPosition, .1f);
        if (Input.GetMouseButtonUp(0))
        {
            functionMouseUp();
        }
        else if(Input.GetMouseButtonDown(0))
        {
            functionMouseDown(Input.mousePosition);
        }
        else if(Input.GetMouseButton(0))
        {
            functionMouseHold(Input.mousePosition);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4.5f, 4.5f), transform.position.y, transform.position.z);
    }

    //Functions,
    private void functionMouseUp()
    {
        difference = Vector3.zero;
    }
    private void functionMouseDown(Vector3 parameterInputPosition)
    {
        firstPosition = Orthographic.ScreenToWorldPoint(parameterInputPosition);
    }
    private void functionMouseHold(Vector3 parameterInputPosition)
    {
        lastPosition = Orthographic.ScreenToWorldPoint(parameterInputPosition);
        difference = lastPosition - firstPosition;
        difference *= sensivity;
    }
}