﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;
    public int X_Start;
    public int Y_Start;
    public int Num_Of_Columns;
    public int X_Space_Between_Items;
    public int Y_Space_Between_Items;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    private void Awake()
    {
        CreateDisplay();
    }
    private void Update()
    {
        UpdateDisplay();
    }
    public void CreateDisplay()
    {
        for(int i = 0; i < inventory.Container.Count; i++)
        {
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            itemsDisplayed.Add(inventory.Container[i], obj);
        }
    }
    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_Start + (X_Space_Between_Items * (i % Num_Of_Columns)), Y_Start + (-Y_Space_Between_Items * (i / Num_Of_Columns)), 0f);
    }
    public void UpdateDisplay()
    {
        for(int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }
            else
            {
                    var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                    obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                    obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                    itemsDisplayed.Add(inventory.Container[i], obj);
            }
        }
    }
}
