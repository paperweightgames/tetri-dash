using UnityEngine;
using UnityEngine.UI;

public class Marker : MonoBehaviour
{
    [SerializeField] private Transform _followTransform;
    [SerializeField] private Color _markerColour;
    [SerializeField] private Text _text;
    [SerializeField] private Image _line;

    private void Start()
    {
        UpdateColour();
    }

    public void UpdateColour()
    {
        _text.color = _markerColour;
        _line.color = _markerColour;
    }

    private void Update()
    {
        transform.position = _followTransform.position;
    }
}