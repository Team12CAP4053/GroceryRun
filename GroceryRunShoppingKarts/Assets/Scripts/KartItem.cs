using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartItem : MonoBehaviour
{
    private GameItemsHandle Handle;

    public float DelayBeforeItemPickup = 1;

    public int HeldItem;

    public bool CanPickup = true;
    private bool UseItem;

    public Item ItmUse;

    // Start is called before the first frame update
    void Start()
    {
        Handle = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameItemsHandle>();

        ResetItem();
    }

    // Update is called once per frame
    void Update()
    {
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

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "MysteryBox")
        {
            StartCoroutine(Pickup(collider));
        }
    }


    public void ResetItem()
    {
        ItmUse = null;
        HeldItem = -1;
        CanPickup = true;
    }
}
