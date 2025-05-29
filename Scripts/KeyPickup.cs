using UnityEngine;
using System.Collections;


public class KeyPickup : MonoBehaviour
{
    public AudioClip keySound; // Æ_°Í­µ®Ä
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(keySound, transform.position);
            GameManager.instance.hasKey = true;
            UIManager.instance.ShowMessage("KEY!");
            Destroy(this.gameObject.transform.root.gameObject);
        }
    }
}
