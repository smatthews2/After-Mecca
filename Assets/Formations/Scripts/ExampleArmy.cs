using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class ExampleArmy : MonoBehaviour
{
    private FormationBase _formation;

    public FormationBase Formation
    {
        get
        {
            if (_formation == null) _formation = GetComponent<FormationBase>();
            return _formation;
        }
        set => _formation = value;
    }

    [SerializeField] private GameObject _unitPrefab;
    [SerializeField] private GameObject _armyCommander;
    [SerializeField] private float _unitSpeed = 5;
    [SerializeField] private float _followRange = 10;
    [SerializeField] private Camera _armyCamera;
    [SerializeField] private bool _isSelected = true;
    
    private string groundTag = "Ground";
    private string playerTag = "Player";
    private RaycastHit hit;

    private readonly List<GameObject> _spawnedUnits = new List<GameObject>();
    private List<Vector3> _points = new List<Vector3>();
    private Transform _parent;

    private void Awake()
    {
        _parent = new GameObject(_unitPrefab.name + " Parent").transform;
        _armyCamera = Camera.main;
    }

    private void Update()
    {
        MoveArmy();
        SetFormation();
    }

    private void SetFormation()
    {
        _points = Formation.EvaluatePoints().ToList();

        if (_points.Count > _spawnedUnits.Count)
        {
            var remainingPoints = _points.Skip(_spawnedUnits.Count);
            Spawn(remainingPoints);
        }
        else if (_points.Count < _spawnedUnits.Count)
        {
            Kill(_spawnedUnits.Count - _points.Count);
        }

        for (var i = 0; i < _spawnedUnits.Count; i++)
        {
            _spawnedUnits[i].transform.position = Vector3.MoveTowards(_spawnedUnits[i].transform.position, transform.position + _points[i], _unitSpeed * Time.deltaTime);
        }
    }

    private void Spawn(IEnumerable<Vector3> points)
    {
        int unitNum = 0;
        foreach (var pos in points)
        {
            var unit = Instantiate(_unitPrefab, transform.position + pos, Quaternion.identity, _parent);
            unit.name = _unitPrefab.name + "Clone" + unitNum;
            _spawnedUnits.Add(unit);
            unitNum++;
        }
    }

    private void Kill(int num)
    {
        for (var i = 0; i < num; i++)
        {
            var unit = _spawnedUnits.Last();
            _spawnedUnits.Remove(unit);
            Destroy(unit.gameObject);
        }
    }
    /*
    private void MoveArmy()
    {
        if (Input.GetMouseButtonDown(0) && _isSelected)
        {
            Ray ray = _armyCamera.ScreenPointToRay(Input.mousePosition); // Draw a ray from the camera to where the mouse clicked.

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag(groundTag))
                {
                    Formation._centerPosition = hit.point; // Walk to where the mouse clicked if it hit the ground.
                    for(int i = 0; i < _spawnedUnits.Count; i++)
                    {
                        _spawnedUnits[i].transform.LookAt(hit.point); // Face direction of point.
                    }
                }
            }
        }else if (Input.GetMouseButtonDown(1))
        {
            Ray ray = _armyCamera.ScreenPointToRay(Input.mousePosition); // Draw a ray from the camera to where the mouse clicked.

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag(playerTag))
                {
                    _isSelected = !_isSelected; // Select unit on right click.
                }
            }
        }
    }
    */

    private void MoveArmy()
    {
        Formation._centerPosition = new Vector3(_armyCommander.transform.position.x, 0, _armyCommander.transform.position.z - (_followRange * Formation.GetSpread()));
        for (var i = 0; i < _spawnedUnits.Count; i++)
        {
            _spawnedUnits[i].transform.rotation = _armyCommander.transform.rotation;
        }
    }
}