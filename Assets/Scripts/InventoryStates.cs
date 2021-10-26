using System;
using UnityEngine;

public class InventoryStates : MonoBehaviour
{
    #region Singleton
    public static InventoryStates Instance
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

    public event EventHandler<Part> OnItemAdded;
    public event EventHandler<Part> OnItemUsed;

    public void ItemAdded(Part itemInfo)
    {
        OnItemAdded?.Invoke(this, itemInfo);
    }

    public void ItemUsed(Part itemInfo)
    {
        OnItemUsed?.Invoke(this, itemInfo);
    }
}