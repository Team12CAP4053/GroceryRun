﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KartItem : MonoBehaviour
{
    private GameItemsHandle Handle;

    public float DelayBeforeItemPickup = 1;

    public int HeldItem;
    public int coins;
    public int currentCost;

    public bool CanPickup = true;
    private bool UseItem;

    public Text currentCostText;
    public Text coinsText;

    public Item ItmUse;


    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
        currentCost = 0;
        
        Handle = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameItemsHandle>();

        ResetItem();
    }

    // Update is called once per frame
    void Update()
    {
        // update counter text
        currentCostText.text = "Current Cost: " + currentCost.ToString();
        coinsText.text = "Coins: " + coins.ToString();

        // Update item sprite
        if (HeldItem != -1) 
        {
            ItmUse = Handle.AllItems[HeldItem];
        }

        UseItem = Input.GetButtonDown("Item");
        if (UseItem && HeldItem != -1)
        {
            ActivateItem();
        }
    }

    public void ActivateItem()
    {
        // Throw item

        // Reset item
        ResetItem();
    }

    public IEnumerator checkout()
    {
        if (coins >= currentCost)
        {
            coins -= currentCost;
            currentCost = 0;
        }
        else
        {
            currentCost -= coins;
            coins = 0;
        }

        yield return new WaitForSeconds(0);
    }


    public IEnumerator Pickup(Collider collider)
    {
        if (HeldItem == -1 && CanPickup)
        {
            CanPickup = false;

            // Remove box
            collider.gameObject.SetActive(false);

            // Wait for random result
            yield return new WaitForSeconds(DelayBeforeItemPickup);

            // Get random item
            int ItemRand = Random.Range(0, Handle.AllItems.Length);

            // Set item
            ItmUse = Handle.AllItems[ItemRand];
            HeldItem = ItemRand;

            // Wait and respawn box
            yield return new WaitForSeconds(5);
            collider.gameObject.SetActive(true);
        }
    }

    public IEnumerator CollectCoin(Collider collider)
    {
            // Remove coin
            collider.gameObject.SetActive(false);

            // Increment coins
            this.coins++;

            // Wait and respawn box
            yield return new WaitForSeconds(5);
            collider.gameObject.SetActive(true);
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "MysteryBox")
        {
            StartCoroutine(Pickup(collider));
        }

        if (collider.gameObject.tag == "Coin")
        {
            // Limit coins to 10
            if (coins < 10)
                StartCoroutine(CollectCoin(collider));
        }

        if (collider.gameObject.tag == "checkout")
        {
            StartCoroutine(checkout());
        }
    }

    


    public void ResetItem()
    {
        ItmUse = null;
        HeldItem = -1;
        CanPickup = true;
    }
}
