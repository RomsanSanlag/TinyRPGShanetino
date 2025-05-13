using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator _playerAnimator;
    [SerializeField] Transform _playerTransform;
    [SerializeField] float _playerSpeed;

    Vector2 _horisontalInput;
    bool _attack;
    Vector2 _newPlayerPosition;

    NavMeshHit hit;
    float checkRadius; 

    private void Update()
    {
        // GET INPUTS ---------------------------

        // y axis
        if (Input.GetKey(KeyCode.W)) 
        { 
            _horisontalInput.y = 1;
            if (Input.GetKey(KeyCode.S)) _horisontalInput.y = 0;
        } 
        else if (Input.GetKey(KeyCode.S)) _horisontalInput.y = -1;
        else _horisontalInput.y = 0;

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


        // USE INPUTS ---------------------------

        _newPlayerPosition = _horisontalInput * _playerSpeed * Time.deltaTime;
        if (NavMesh.SamplePosition(_newPlayerPosition, out hit, checkRadius, NavMesh.AllAreas))
        {
            _playerTransform.position = _newPlayerPosition;
            Debug.Log("Outside of nav mesh");
        }

        //Debug.Log(_horisontalInput);
    }
}
