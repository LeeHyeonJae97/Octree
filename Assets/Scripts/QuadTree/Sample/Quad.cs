using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quad : MonoBehaviour, IQuadTreeObject
{
    public Bounds Bounds { get { return _renderer.bounds; } }

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponentInChildren<Renderer>(true);
    }
}
