using UnityEngine;
using UnityStandardAssets.Vehicles.Car;
public class AIShootDetection : MonoBehaviour
{
    private KartItem inventory;
    private AIShooting ai;
    private void Start()
    {
        inventory = this.gameObject.GetComponentInParent<KartItem>();
        ai = this.gameObject.GetComponentInParent<AIShooting>();
    }
    void OnTriggerEnter(Collider collider)
    {
        //Debug.Log(collider);
        if (collider.gameObject.GetComponent<CarController>())
        {
            if (inventory.HoldingItem())
            {
                Debug.Log(inventory.HeldItem);
                switch (inventory.HeldItem)
                {
                    case 0:
                        ai.SpawnApple();
                        break;
                    case 1:
                        ai.SpawnChicken();
                        break;
                    case 2:
                        ai.SpawnMilk();
                        break;
                    case 3:
                        ai.SpawnWatermelon();
                        break;     
                }
                inventory.ResetItem();
            }
        }
        
    }
}
