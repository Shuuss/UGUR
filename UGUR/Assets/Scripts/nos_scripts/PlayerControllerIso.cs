using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerIso : MonoBehaviour {
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _turnSpeed = 360;
    private Vector3 _input;

    private void Update() {
        GatherInput();
        Look();
    }

    private void FixedUpdate() {
        Move();
    }

    private void GatherInput() {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    private void Look() {
        if (_input == Vector3.zero) return;

        var direction = new Vector3(_input.x, 0, _input.z).ToIso();
        if (direction != Vector3.zero) {
            var rot = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
        }
    }

    private void Move() {
        if (_input.magnitude > 0) {
            var movement = new Vector3(_input.x, 0, _input.z).ToIso().normalized * _speed * Time.deltaTime;
            _rb.MovePosition(transform.position + movement);
        }
    }
}

public static class Helpers 
{
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
}