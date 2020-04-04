using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIHandle : MonoBehaviour
{
    private bool shuffleSprite;
    public float TimeBtwShuffle;
    public Sprite[] AllItemGraphics;
    public Sprite EmptyItem;

    public Image Img;
    public KartItem Kart;

    // Start is called before the first frame update
    void Start()
    {
        shuffleSprite = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Kart.HeldItem == -1)
        {
            if (Kart.CanPickup)
            {
                Img.sprite = EmptyItem;
            }
            else
            {
                if (shuffleSprite)
                {
                    Invoke("Shuffle", TimeBtwShuffle);
                    shuffleSprite = false;

                }
            }
        }
        else
        {
            Img.sprite = Kart.ItmUse.Visual;
        }
    }

    void Shuffle()
    {
        Img.sprite = AllItemGraphics[Random.Range(0, AllItemGraphics.Length)];
        shuffleSprite = true;
    }
}
