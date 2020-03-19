using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KeySubstitution
{
    [CreateAssetMenu(fileName = "Key Name", menuName = "ScriptableObjects/KeyName", order = 0)]
    public class KeyNameObject : ScriptableObject
    {
        [SerializeField] private KeyName[] _keyNames;

        public string FormatKey(Key key)
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

        public string FormatKeys(IEnumerable<Key> keys)
        {
            var output = "";
            foreach (var key in keys)
            {
                output += FormatKey(key);
            }
            return output;
        }
    }
}