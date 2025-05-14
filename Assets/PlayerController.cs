using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator _playerAnimator;
    [SerializeField] Transform _playerTransform;
    [SerializeField] float _playerSpeed;

    Vector3 _horisontalInput;
    bool _attack;
    Vector3 _newPlayerPosition;
    Quaternion _newPlayerRotation;
    float _newPlayerWalkSpeed;

    NavMeshHit hit;
    float _checkRadius = 1;
    Quaternion rotation = Quaternion.Euler(0, 45, 0);

    private void Start()
    {
        _newPlayerPosition = _playerTransform.position;
    }

    private void Update()
    {
        // GET INPUTS ---------------------------

        // y axis
        if (Input.GetKey(KeyCode.W))
        {
            _horisontalInput.z = 1;
            if (Input.GetKey(KeyCode.S)) _horisontalInput.z = 0;
        }
        else if (Input.GetKey(KeyCode.S)) _horisontalInput.z = -1;
        else _horisontalInput.z = 0;

        // x axis
        if (Input.GetKey(KeyCode.D))
        {
            _horisontalInput.x = 1;
            if (Input.GetKey(KeyCode.A)) _horisontalInput.x = 0;
        }
        else if (Input.GetKey(KeyCode.A)) _horisontalInput.x = -1;
        else _horisontalInput.x = 0;

        // attack
        if (Input.GetMouseButtonDown(0)) _attack = true;

        // rotate inputs
        _horisontalInput = rotation * _horisontalInput;

        // USE INPUTS ---------------------------

        // move player
        if (NavMesh.SamplePosition(_newPlayerPosition, out hit, _checkRadius, NavMesh.AllAreas))
        {
            _playerTransform.position += _horisontalInput.normalized * _playerSpeed * Time.deltaTime;
        }
        else Debug.Log("Outside of nav mesh");

        // rotate player
        if (_horisontalInput != Vector3.zero)
        {
            _newPlayerRotation = Quaternion.LookRotation(_horisontalInput.normalized, Vector3.up);
            _playerTransform.rotation = _newPlayerRotation;
        }

        // animate player
        _newPlayerWalkSpeed = _horisontalInput == Vector3.zero ? 0 : 1;
        _playerAnimator.SetFloat("WalkSpeed", _newPlayerWalkSpeed);

        if (_attack) _playerAnimator.SetTrigger("Attack");
        _attack = false;
    }
}
