using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class keyHolder : MonoBehaviour
{

    private List<Key.KeyType> keyList;

    [SerializeField]
    private GameObject keyRed, keyGreen, keyBlue, keyPurple, keyGolden;

    private void Awake()
    {
        keyList = new List<Key.KeyType>();
    }

    public void AddKey(Key.KeyType keyType)
    {
        keyList.Add(keyType);
    }

    public void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType);
    }

    public bool ContainsKey(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Key key = collision.GetComponent<Key>();
        if(key != null)
        {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
            Key.KeyType keyType = key.GetKeyType();
            ShowUI(keyType);
        }

        keyDoor keyDoor = collision.GetComponent<keyDoor>();
        if(keyDoor != null)
        {
            if(ContainsKey(keyDoor.GetKeyType()))
            {
                keyDoor.OpenDoor();
                HideUI(keyDoor.GetKeyType());
                RemoveKey(keyDoor.GetKeyType());
            }
        }
    }

    void ShowUI(Key.KeyType keyType)
    {
        if(keyType == Key.KeyType.Red)
        {
            keyRed.SetActive(true);
            print("show " + keyType);
        }
        else if(keyType == Key.KeyType.Green)
        {
            keyGreen.SetActive(true);
            print("show " + keyType);
        }
        else if(keyType == Key.KeyType.Blue)
        {
            keyBlue.SetActive(true);
            print("show " + keyType);
        }
        else if(keyType == Key.KeyType.Purple)
        {
            keyPurple.SetActive(true);
            print("show " + keyType);
        }
        else if(keyType == Key.KeyType.Golden)
        {
            keyGolden.SetActive(true);
            print("show " + keyType);
        }
    }

    void HideUI(Key.KeyType keyType)
    {
        if (keyType == Key.KeyType.Red)
        {
            keyRed.SetActive(false);
            print("show " + keyType);
        }
        else if (keyType == Key.KeyType.Green)
        {
            keyGreen.SetActive(false);
            print("show " + keyType);
        }
        else if (keyType == Key.KeyType.Blue)
        {
            keyBlue.SetActive(false);
            print("show " + keyType);
        }
        else if (keyType == Key.KeyType.Purple)
        {
            keyPurple.SetActive(false);
            print("show " + keyType);
        }
        else if (keyType == Key.KeyType.Golden)
        {
            keyGolden.SetActive(false);
            print("show " + keyType);
        }
    }

}
