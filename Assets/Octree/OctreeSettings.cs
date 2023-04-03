using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct OctreeSettings
{
    public Vector3 Center => _center;
    public Vector3 Size => _size;
    public int MinDepth => _minDepth;

    [SerializeField] private Vector3 _center;
    [SerializeField] private Vector3 _size;
    [SerializeField] private int _minDepth;
}