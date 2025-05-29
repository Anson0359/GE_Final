using UnityEngine;
using System.Collections;


public class VegetablePickup : MonoBehaviour
{
    public AudioClip vegetableSound;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(vegetableSound, transform.position);
            GameManager.instance.hasVegetable = true;
            UIManager.instance.ShowMessage("Vegetable!");
            Destroy(this.gameObject.transform.root.gameObject);


        }
    }
}
