using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spin : MonoBehaviour
{
   
    [SerializeField] private float rotationSpeed = 45f;
    [SerializeField] private Transform rotateAround;

    private InputAction clickAction;

    void OnEnable()
    {
        clickAction = new InputAction(type: InputActionType.Button, binding: "<Mouse>/leftButton");
        clickAction.Enable();
    }

    void OnDisable()
    {
        clickAction.Disable();
    }
    void Update()
    {
        this.transform.RotateAround(rotateAround.position, Vector3.forward, rotationSpeed * Time.deltaTime);

        if (clickAction.triggered)
        {
            rotationSpeed = -rotationSpeed;
        }

    }

}