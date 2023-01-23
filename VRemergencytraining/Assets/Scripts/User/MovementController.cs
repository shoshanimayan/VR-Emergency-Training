using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MovementController : LocomotionProvider
{

     
    //private Variables
    
    private CharacterController _characterController = null;
    private GameObject _head = null;
    [SerializeField] private float _gravityMultiplier = 10f;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private List<XRController> _controllers = null;

     
    //private methods
    
    protected override void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _head = GetComponent<XRRig>().cameraGameObject;
    }

    private void Start()
    {
        PositionController();
    }

    private void Update()
    {
        PositionController();
        CheckForInput();
        ApplyGravity();
    }

    private void PositionController()
    {
        // Get the head in local, playspace ground
        float headHight = Mathf.Clamp(_head.transform.localPosition.y,1,2);
        _characterController.height = headHight;
        // Cut in half, add skin
        Vector3 newCenter = Vector3.zero;
        newCenter.y = _characterController.height / 2;
        newCenter.y += _characterController.skinWidth;
        // move the capsule in local space as well
        newCenter.x = _head.transform.localPosition.x;
        newCenter.z = _head.transform.localPosition.z;

        // Apply
        _characterController.center = newCenter;
    }

    private void CheckForInput()
    {
        foreach (XRController controller in _controllers) {
            if (controller.enableInputActions)
            {
                CheckForMovement(controller.inputDevice);
            }
        }
    }

    private void CheckForMovement(InputDevice device)
    {
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position))
            StartMove(position);
    }

    private void StartMove(Vector2 position)
    {

        Vector3 direction = new Vector3(position.x, 0, position.y);
        Vector3 headRotation = new Vector3(0,_head.transform.eulerAngles.y,0);
        direction = Quaternion.Euler(headRotation)*direction;
        Vector3 movement = direction * _speed;
        _characterController.Move(movement*Time.deltaTime);
    }

    private void ApplyGravity()
    {
        Vector3 gravity = new Vector3(0, Physics.gravity.y * _gravityMultiplier, 0);
        gravity.y*=Time.deltaTime;
        _characterController.Move(gravity * Time.deltaTime);
    }



}