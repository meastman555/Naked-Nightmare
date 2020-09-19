using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    [SerializeField]
    private KeyType keyType;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public enum KeyType
    {
        Red,
        Green,
        Blue,
        Purple,
        Golden
    }

    public KeyType GetKeyType()
    {
        return keyType;
    }

    private void Update()
    {
        anim.Play("KeyFloat");
    }

}
