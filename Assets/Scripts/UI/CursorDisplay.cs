using UnityEngine;
using UnityEngine.InputSystem;

namespace UI
{
    public class CursorDisplay : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        private void Update()
        {
            // Hide the system cursor.
            Cursor.visible = false;
            // Move the cursor to the positon of the mouse.
            var cursorScreenPosition = Mouse.current.position;
            var cursorPosition = _camera.ScreenToWorldPoint(cursorScreenPosition.ReadValue());
            var t = transform;
            cursorPosition.z = t.position.z;
            t.position = cursorPosition;
        }
    }
}