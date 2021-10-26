using System;
using UnityEngine;

public class InventoryEvents : MonoBehaviour
{
    #region Singleton
    public static InventoryEvents Instance
    {
        get;
        private set;
    }

    private void CreateSingleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    #endregion Singleton

    private void Awake()
    {
        CreateSingleton();
    }

    public event EventHandler<Part> OnRequestAddToInventory;
    public event EventHandler<Part> OnRequestUseItem;

    public void RequestAddToInventory(Part itemInfo)
    {
        OnRequestAddToInventory?.Invoke(this, itemInfo);
    }

    public void RequestUseItem(Part itemInfo)
    {
        OnRequestUseItem?.Invoke(this, itemInfo);
    }
}