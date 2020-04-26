using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;

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
    public Text checkoutText;

    public Item ItmUse;

    private bool UseItem2;


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
        if(gameObject.tag == "Player")
        {
            currentCostText.text = "Current Cost: " + currentCost.ToString();
            coinsText.text = "Money: " + coins.ToString();
        }

        // Update speed penalty
        gameObject.GetComponent<CarController>().maxSpeedPercent = 100 - (currentCost * 5);

        // Update item sprite
        if (HeldItem != -1)
        {
            ItmUse = Handle.AllItems[HeldItem];
        }

        UseItem = Input.GetButtonDown("Fire1");
        UseItem2 = Input.GetKeyDown("f");
        if ((UseItem || UseItem2) && HeldItem != -1)
        {
            ActivateItem();
        }

        if (coins == currentCost && currentCost != 0)
        {
            coins = 0;
            gameObject.GetComponent<CarController>().TopSpeedReset(currentCost * 5);
            currentCost = 0;
            StartCoroutine(checkout());
        }
        else if (coins > currentCost && currentCost != 0)
        {
            coins = coins - currentCost;
            currentCost = 0;
            StartCoroutine(checkout());
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
        checkoutText.text = "Items bought & cart unloaded!\nBack to normal speed!";

        yield return new WaitForSeconds(4);

        checkoutText.text = "";
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
    }




    public void ResetItem()
    {
        ItmUse = null;
        HeldItem = -1;
        CanPickup = true;
    }
}
