using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[ExecuteInEditMode]
public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private SpriteShapeController _spriteShapeController;

    [Range(3f, 100f)] public int _levelLength = 50;
    [Range(1f, 50f)] public float _xMultiplier = 2f;
    [Range(1f, 50f)] public float _yMultiplier = 2f;
    [Range(0f, 1f)] public float _curveSmoothness = 0.5f;
    public float _noiseStep = 0.5f;
    public float _bottom = 10f;

    Vector3 _lastPos;

    //Stores the rightmost point in local coords
    public Vector3 rightMostPoint;


    private void Awake()
    {
        GenerateTerrain();
    }

    private void OnValidate()
    {
        GenerateTerrain();
    }

    public void GenerateTerrain()
    {
        _spriteShapeController.spline.Clear();

        for (int i = 0; i < _levelLength; i++)
        {
            _lastPos = transform.position + new Vector3(i * _xMultiplier, Mathf.PerlinNoise(0, i * _noiseStep) * _yMultiplier);

            _spriteShapeController.spline.InsertPointAt(i, _lastPos);

            if (i != 0 && i != _levelLength - 1)
            {
                _spriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                _spriteShapeController.spline.SetLeftTangent(i, Vector3.left * _xMultiplier * _curveSmoothness);
                _spriteShapeController.spline.SetRightTangent(i, Vector3.right * _xMultiplier * _curveSmoothness);
            }
        }

        rightMostPoint = _spriteShapeController.spline.GetPosition(_levelLength - 1);

        _spriteShapeController.spline.InsertPointAt(_levelLength, new Vector3(_lastPos.x, transform.position.y - _bottom));

        _spriteShapeController.spline.InsertPointAt(_levelLength + 1, new Vector3(transform.position.x, transform.position.y - _bottom));

    }

    /// <summary>
    /// Generate a terrain with the lastSplinePoint as the starting point for terrain generation.
    /// </summary>
    /// <param name="lastSplinePoint"></param>
    public void GenerateTerrain(Vector3 lastSplinePoint)
    {
        _spriteShapeController.spline.Clear();

        //Convert to local space
        lastSplinePoint = transform.InverseTransformPoint(lastSplinePoint);

        _lastPos = lastSplinePoint;
        _spriteShapeController.spline.InsertPointAt(0, _lastPos);

        for (int i = 1; i < _levelLength; i++)
        {
            _lastPos = transform.position + new Vector3(i * _xMultiplier, Mathf.PerlinNoise(0, i * _noiseStep) * _yMultiplier);
            //Convert to local space
            _lastPos = transform.InverseTransformPoint(_lastPos);

            _spriteShapeController.spline.InsertPointAt(i, _lastPos);

            if (i != 0 && i != _levelLength - 1)
            {
                _spriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
                _spriteShapeController.spline.SetLeftTangent(i, Vector3.left * _xMultiplier * _curveSmoothness);
                _spriteShapeController.spline.SetRightTangent(i, Vector3.right * _xMultiplier * _curveSmoothness);
            }
        }

        rightMostPoint = _spriteShapeController.spline.GetPosition(_levelLength - 1);

        Vector2 p = new Vector3(_lastPos.x, transform.InverseTransformPoint(new Vector2(0, transform.position.y - _bottom)).y);
        _spriteShapeController.spline.InsertPointAt(_levelLength, p);

        p = transform.InverseTransformPoint(new Vector3(transform.position.x, transform.position.y - _bottom));

        _spriteShapeController.spline.InsertPointAt(_levelLength + 1, p);

        //_spriteShapeController.colliderDetail = 2;
        //_spriteShapeController.RefreshSpriteShape();
        //_spriteShapeController.BakeCollider();

        //Destroy(GetComponent<PolygonCollider2D>());

        //var comp = gameObject.AddComponent<PolygonCollider2D>();

        _spriteShapeController.RefreshSpriteShape();
        _spriteShapeController.BakeCollider();

    }

}
