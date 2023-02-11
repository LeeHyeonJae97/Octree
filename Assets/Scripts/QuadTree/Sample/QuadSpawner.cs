using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadSpawner : MonoBehaviour
{
    [SerializeField] private int _count;
    [SerializeField] private Quad _prefab;
    [SerializeField] private Vector2 _center;
    [SerializeField] private Vector2 _size;
    [SerializeField] private int _minDepth;
    [SerializeField] private float _radius;
    private QuadTree<Quad> _quadTree;

    private void Start()
    {
        _quadTree = new QuadTree<Quad>(_center, _size, _minDepth);

        for (int i = 0; i < _count; i++)
        {
            var hs = _size / 2;
            var position = _center + new Vector2(Random.Range(-hs.x, hs.x), Random.Range(-hs.y, hs.y));
            var rotation = Quaternion.identity;

            var quad = Instantiate(_prefab, position, rotation);

            if (!_quadTree.Add(quad))
            {
                Destroy(quad.gameObject);
            }
        }
    }

    private void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        _quadTree.GetColliding(new List<Quad>(), mousePos, _radius);
    }

    private void OnDrawGizmos()
    {
        if (_quadTree != null)
        {
            _quadTree.DrawBounds();
        }
    }
}
