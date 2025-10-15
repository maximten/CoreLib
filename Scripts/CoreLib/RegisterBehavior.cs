using System;
using UnityEngine;

namespace CoreLib
{
    public class RegisterBehavior<Type> : MonoBehaviour  where Type : Enum
    {
        [SerializeField] private Type Key;
        
        void OnEnable()
        {
            RegistryT<Type>.Add(Key, gameObject);
        }

        void OnDisable()
        {
            RegistryT<Type>.Remove(Key, gameObject);
        }
    }
}