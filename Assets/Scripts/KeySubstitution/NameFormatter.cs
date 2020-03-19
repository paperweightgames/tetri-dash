using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KeySubstitution
{
    public class NameFormatter : MonoBehaviour
    {
        [SerializeField] private KeyNameObject _keyNameObject;

        public string FormatName(IEnumerable<Key> keys)
        {
            var output = "";
            foreach (var key in keys)
            {
                output += _keyNameObject.CheckKey(key);
            }

            return output;
        }
    }
}