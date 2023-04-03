using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour, IOctreeObject
{
    public Bounds Bounds { get { return _renderer.bounds; } }

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponentInChildren<Renderer>(true);
    }
}
