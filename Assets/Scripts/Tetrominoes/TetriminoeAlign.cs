using UnityEngine;

namespace Tetrominoes.SmoothFall
{
    public class TetriminoeAlign : MonoBehaviour
    {
        private void Start()
        {
            var localPosition = transform.localPosition;
            localPosition.y = Mathf.Round(localPosition.y / 0.8f) * 0.8f;
            transform.localPosition = localPosition;
        }
    }
}