using UnityEngine;

namespace Tetrominoes.SmoothFall
{
    public class TetriminoeAlign : MonoBehaviour
    {
        private void Start()
        {
            var localPositon = transform.localPosition;
            localPositon.y = Mathf.Round(localPositon.y / 0.8f) * 0.8f;
            transform.localPosition = localPositon;
        }
    }
}