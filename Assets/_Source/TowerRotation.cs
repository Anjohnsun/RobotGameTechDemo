using UnityEngine;

public class TowerRotation : MonoBehaviour
{
    [SerializeField] private Transform _tower;
    [SerializeField] private float rotationSpeed = 5f; 

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = hit.point;
            targetPosition.y = _tower.position.y;

            Quaternion targetRotation = Quaternion.LookRotation(targetPosition - _tower.position);

            _tower.rotation = Quaternion.RotateTowards(_tower.rotation, targetRotation, rotationSpeed * 10 * Time.deltaTime);
        }
    }
}
