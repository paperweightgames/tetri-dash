using UnityEngine;

public class MinimumHeight : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.position += Time.deltaTime * _speed * Vector3.up;
    }
}