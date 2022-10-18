using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBoxBehavior : MonoBehaviour
{
    [SerializeField]
    [Tooltip("How far this object will move from its starting position.")]
    private Vector3 _range;

    [SerializeField]
    [Tooltip("How fast this box will move.")]
    private float _speed;

    [Tooltip("The position at which this object moves around.")]
    private Vector3 _startingPosition;

    private void Awake()
    {
        _startingPosition = transform.position;
    }
    public virtual void FixedUpdate()
    {
        transform.position += Vector3.Lerp(_startingPosition - _range, _startingPosition + _range, _speed * Time.fixedDeltaTime);
    }
}
