using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public List<String> items;
    public void addItem(GameObject item)
    {
        items.Add(item.name);
    }

    public void GetItem(String item)
    {
        items.Remove(item);
    }

    public bool HasItem(string nombre)
    {
        foreach (string item in items)
        {
            if (item == nombre)
            {
                return true;
            }

        }
        return false;
    }

}
