using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class NavMeshMovement : MonoBehaviour
{
    PlayerInput _input;
    InputAction _moveAction;
    NavMeshAgent _agent;
    Transform _transform;
    [SerializeField] Transform _raycasts;

    void Start()
    {
        _input = GetComponent<PlayerInput>();
        // _input.enabled = true;

        _moveAction = _input.actions.FindAction("Move");
        _agent = GetComponent<NavMeshAgent>();
        _transform = _agent.transform;

        _agent.updateRotation = false;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        var direction = _moveAction.ReadValue<Vector2>();

        _agent.SetDestination(transform.position + new Vector3(direction.x, 0, direction.y) * 0.2f);

        _raycasts.position = _transform.position + new Vector3(direction.x, 0.5f, direction.y) * 0.15f;
    }
}
