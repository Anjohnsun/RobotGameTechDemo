using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegTarget : MonoBehaviour
{
    [SerializeField] private float _stepSpeed = 0.6f;
    [SerializeField] private AnimationCurve _stepCurve;

    private new Transform transform;
    private Vector3 position;
    //private Transform transform;
    private Movement? _movement;

    public Vector3 Position => position;
    public bool IsMoving => _movement != null;

    private void Awake()
    {
        transform = base.transform;
        position = transform.position;
    }

    private void FixedUpdate()
    {
        if (_movement != null)
        {
            var m = _movement.Value;
            m.Progress = Mathf.Clamp01(m.Progress + Time.deltaTime * _stepSpeed);
            position = m.Evaluate(Vector3.up, _stepCurve);
            _movement = m.Progress < 1 ? m : null;
        }
        transform.position = position;
    }

    public void MoveTo(Vector3 targetPosition)
    {
        if (_movement == null)
            _movement = new Movement
            {
                Progress = 0,
                FromPosition = position,
                ToPosition = targetPosition
            };
        else
            _movement = new Movement
            {
                Progress = _movement.Value.Progress,
                FromPosition = _movement.Value.FromPosition,
                ToPosition = targetPosition
            };
    }

    private struct Movement
    {
        public float Progress;
        public Vector3 FromPosition;
        public Vector3 ToPosition;

        public Vector3 Evaluate(in Vector3 up, AnimationCurve stepCurve)
        {
            return Vector3.Lerp(FromPosition, ToPosition, Progress) + up * stepCurve.Evaluate(Progress);
        }
    }
}