using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShopTab
{
    Skill,
    Melee,
    Mage,
    Archer
}
public class TabController : MonoBehaviour
{
    public static TabController instance;

    public event EventHandler OnAddCard;

    public ShopTab currentTab;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        // Set tab mặc định
        currentTab = ShopTab.Melee;
    }

    private void Update()
    {

    }

    public void ChangeMeleeTab()
    {
        currentTab = ShopTab.Melee;
        OnAddCard?.Invoke(this, EventArgs.Empty);
    }

    public void ChangeMageTab()
    {
        currentTab = ShopTab.Mage;
        OnAddCard?.Invoke(this, EventArgs.Empty);
    }

    public void ChangeArcherTab()
    {
        currentTab = ShopTab.Archer;
        OnAddCard?.Invoke(this, EventArgs.Empty);
    }
}
