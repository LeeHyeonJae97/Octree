using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private int _count;
    [SerializeField] private Cube _prefab;
    [SerializeField] private float _radius;
    [SerializeField] private OctreeSettings _settings;
    private Octree<Cube> _octree;

    private void Start()
    {
        _octree = new Octree<Cube>(_settings.Center, _settings.Size, _settings.MinDepth);

        for (int i = 0; i < _count; i++)
        {
            var hs = _settings.Size / 2;
            var position = _settings.Center + new Vector3(Random.Range(-hs.x, hs.x), Random.Range(-hs.y, hs.y), Random.Range(-hs.z, hs.z));
            var rotation = Quaternion.identity;

            var cube = Instantiate(_prefab, position, rotation);

            if (!_octree.Add(cube))
            {
                Destroy(cube.gameObject);
            }
        }
    }

    private void Update()
    {
        var mousePos = Input.mousePosition;
        mousePos.z -= Camera.main.transform.position.z;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        _octree.GetColliding(new List<Cube>(), mousePos, _radius);
    }

    private void OnDrawGizmos()
    {
        if (_octree != null)
        {
            _octree.DrawBounds();
        }
    }
}
