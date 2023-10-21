using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShopTab
{
    Melee,
    Mage,
    Archer
}
public class TabController : MonoBehaviour
{
    public static TabController instance;

    public event EventHandler OnAddCardMelee, OnAddCardMage, OnAddCardArcher;

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
        // Xử lý giao diện cửa hàng dựa trên tab hiện tại
        switch (currentTab)
        {
            case ShopTab.Melee:
                // Hiển thị nội dung cho tab Mage
                OnAddCardMelee?.Invoke(this, EventArgs.Empty);
                break;
            case ShopTab.Mage:
                // Hiển thị nội dung cho tab Melee
                OnAddCardMage?.Invoke(this, EventArgs.Empty);
                break;
            case ShopTab.Archer:
                // Hiển thị nội dung cho tab Archer
                OnAddCardArcher?.Invoke(this, EventArgs.Empty);
                break;
        }
    }

    public void ChangeMeleeTab()
    {
        currentTab = ShopTab.Melee;
    }

    public void ChangeMageTab()
    {
        currentTab = ShopTab.Mage;
    }

    public void ChangeArcherTab()
    {
        currentTab = ShopTab.Archer;
    }
}
