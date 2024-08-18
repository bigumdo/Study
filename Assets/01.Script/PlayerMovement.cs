using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private CharacterController _cc;
    private Vector3 _movement;
    private Quaternion _rot45;

    private void Awake()
    {
        _cc = GetComponent<CharacterController>();
        _rot45 = Quaternion.Euler(0, -45f, 0);
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        _movement = new Vector3(h, 0, v);
    }

    private void FixedUpdate()
    {
        Vector3 movement = _rot45 * _movement.normalized * (Time.deltaTime * _moveSpeed);

        _cc.Move(movement);
    }

}
