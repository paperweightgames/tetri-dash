using UnityEngine;
using UnityEngine.InputSystem;

namespace KeySubstitution
{
    [CreateAssetMenu(fileName = "Key Name", menuName = "ScriptableObjects/KeyName", order = 0)]
    public class KeyNameObject : ScriptableObject
    {
        [SerializeField] private KeyName[] _keyNames;

        public string CheckKey(Key key)
        {
            foreach (var keyName in _keyNames)
            {
                if (keyName.GetKey() == key)
                {
                    return keyName.GetName();
                }
            }

            return key.ToString();
        }
    }
}