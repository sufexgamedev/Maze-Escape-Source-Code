using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class KeyAndDoorSystemScript : MonoBehaviour
{
    public GameObject Door;
    public ParticleSystem doorOpenParticle;
    public GameObject dpGroup;

    private void Awake()
    {
        // used for disabling Game GameObject when the scene loads
        doorOpenParticle.gameObject.SetActive(false);
    }

    // used for detecting trigger (collision) between two GameObjects using Tags
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // key and door logic
        if (collision.gameObject.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            Destroy(Door);
            AudioManagerScript.instance.KeyPickupSound();
            StartCoroutine(DoorOpenParticle());
        }

        // Level Complete logic
        if (collision.gameObject.CompareTag("Finish Marker") && dpGroup == null)
        {
            Destroy(collision.gameObject);
            UIManagerScript.instence.ShowLevelCompleteScreen();
        }
    }

    // when the key is picked and the door is opened (destroyed), appllying this particle on door position
    private IEnumerator DoorOpenParticle()
    {
        GameObject Particle = doorOpenParticle.gameObject;
        Particle.SetActive(true);

        if (Particle.activeInHierarchy)
        {
            doorOpenParticle.Play();
        }
        yield return new WaitForSeconds(1);
        Destroy(dpGroup);
    }
}