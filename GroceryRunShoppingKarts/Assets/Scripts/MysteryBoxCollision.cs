using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryBoxCollision : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void OnTriggerStay(Collider collider)
    {
        Debug.Log(collider.gameObject);
        if(collider.gameObject.tag == "MysteryBox")
        {
            StartCoroutine(MyCoroutine(collider));
        }
    }
    IEnumerator MyCoroutine(Collider collider)
    {
        collider.gameObject.SetActive(false);
        yield return new WaitForSeconds(5);
        collider.gameObject.SetActive(true);
    }
}
