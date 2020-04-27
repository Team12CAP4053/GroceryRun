using UnityEngine;

public class AIShooting : MonoBehaviour
{
    public GameObject watermelon;
    public GameObject chicken;
    public GameObject apple;
    public GameObject milkjug;

    public GameObject forwardBox;
    public SphereCollider sphereBulletCollider;
    public BoxCollider boxBulletCollider;

    public GameObject playerObject;

    private Transform location;

    public void SpawnApple()
    {
        
        GameObject bulletObject = Instantiate(apple) as GameObject;
        bulletObject.transform.position = transform.position + transform.forward * 5 + transform.up * 2;
        bulletObject.transform.forward = forwardBox.transform.forward;
        bulletObject.transform.localScale = new Vector3(10.0f, 10.0f, 10.0f);
        bulletObject.AddComponent<FoodBullet>();
        bulletObject.AddComponent<SphereCollider>();
        bulletObject.AddComponent<Rigidbody>();
        bulletObject.GetComponent<Rigidbody>().useGravity = false;


        sphereBulletCollider = bulletObject.GetComponent<SphereCollider>();
        sphereBulletCollider.radius = 0.07f;
        sphereBulletCollider.center = new Vector3(0.0f, 0.05f, 0.0f);
    }
    public void SpawnChicken()
    {
        GameObject bulletObject = Instantiate(chicken) as GameObject;
        bulletObject.transform.position = transform.position + transform.forward * 5 + transform.up * 2;
        bulletObject.transform.forward = forwardBox.transform.forward;
        bulletObject.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
        bulletObject.AddComponent<FoodBullet>();
        bulletObject.AddComponent<BoxCollider>();
        bulletObject.AddComponent<Rigidbody>();
        bulletObject.GetComponent<Rigidbody>().useGravity = false;

        boxBulletCollider = bulletObject.GetComponent<BoxCollider>();
    }
    public void SpawnMilk()
    {
        GameObject bulletObject = Instantiate(milkjug) as GameObject;
        bulletObject.transform.position = transform.position + transform.forward * 5 + transform.up * 2;
        bulletObject.transform.forward = forwardBox.transform.forward;
        bulletObject.transform.localScale = new Vector3(6.0f, 6.0f, 6.0f);
        bulletObject.AddComponent<FoodBullet>();
        bulletObject.AddComponent<BoxCollider>();
        bulletObject.AddComponent<Rigidbody>();
        bulletObject.GetComponent<Rigidbody>().useGravity = false;

        boxBulletCollider = bulletObject.GetComponent<BoxCollider>();
    }
    public void SpawnWatermelon()
    {
        GameObject bulletObject = Instantiate(watermelon) as GameObject;
        bulletObject.transform.position = transform.position + transform.forward * 5 + transform.up * 2;
        bulletObject.transform.forward = forwardBox.transform.forward;
        bulletObject.transform.localScale = new Vector3(7.0f, 7.0f, 7.0f);
        bulletObject.AddComponent<FoodBullet>();
        bulletObject.AddComponent<SphereCollider>();
        bulletObject.AddComponent<Rigidbody>();
        bulletObject.GetComponent<Rigidbody>().useGravity = false;

        sphereBulletCollider = bulletObject.GetComponent<SphereCollider>();
        sphereBulletCollider.radius = 0.2f;
        sphereBulletCollider.center = new Vector3(0.0f, 0.15f, 0.0f);
    }
}

