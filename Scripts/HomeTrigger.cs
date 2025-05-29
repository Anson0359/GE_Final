using UnityEngine;
using System.Collections;


public class HomeTrigger : MonoBehaviour
{
    public AudioClip homeSound;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(homeSound, transform.position);
            UIManager.instance.ShowMessage("KEEP GOING");
            Destroy(this.gameObject.transform.root.gameObject);
            GameManager.instance.hasReturnedHome = true;
        }
    }
}
