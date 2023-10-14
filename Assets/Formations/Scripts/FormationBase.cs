using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FormationBase : MonoBehaviour {
    [SerializeField] [Range(0, 1)] protected float _noise = 0;
    [SerializeField] protected float Spread = 1;
    [SerializeField] protected Vector3 _middleOffset = Vector3.zero;
    [SerializeField] public Vector3 _centerPosition = Vector3.zero;
    [SerializeField] protected bool _isActive = true;
    [SerializeField] [Range(0, 50)] protected int numUnits = 10;
    
    public abstract IEnumerable<Vector3> EvaluatePoints();

    public Vector3 GetNoise(Vector3 pos) {
        var noise = Mathf.PerlinNoise(pos.x * _noise, pos.z * _noise);

        return new Vector3(noise, 0, noise);
    }
}