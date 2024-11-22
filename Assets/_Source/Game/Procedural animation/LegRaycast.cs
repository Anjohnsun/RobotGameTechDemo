using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegRaycast : MonoBehaviour
{
    private RaycastHit _hit;
    private Transform _transform;

    public Vector3 Position => _hit.point;
    public Vector3 Normal => _hit.normal;
    [SerializeField] private LayerMask _layerMask;

    Ray ray1;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        var ray = new Ray(_transform.position, _transform.up * -1);
        Physics.Raycast(ray, out _hit, _layerMask);

        ray1 = ray;
    }
}