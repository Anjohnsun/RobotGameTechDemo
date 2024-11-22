using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mech : MonoBehaviour
{

    [SerializeField]
    private LegData[] _legs;

    [SerializeField]
    private float stepLength = 0.45f;

    private void Update()
    {
        for (int index = 0; index < _legs.Length; index++)
        {
            ref var legData = ref _legs[index];
            if (!CanMove(index)) continue;
            if (!legData.Leg.IsMoving &&
                (Vector3.Distance(legData.Leg.Position, legData.Raycast.Position) < stepLength))
                continue;
            legData.Leg.MoveTo(legData.Raycast.Position);
        }
    }

    private bool CanMove(int legIndex)
    {
        int legsCount = _legs.Length;
        var n1 = _legs[(legIndex - 1 + legsCount) % legsCount];
        var n2 = _legs[(legIndex + 1) % legsCount];
        return !n1.Leg.IsMoving && !n2.Leg.IsMoving;
    }


    [Serializable]
    private struct LegData
    {
        public LegTarget Leg;
        public LegRaycast Raycast;
    }
}