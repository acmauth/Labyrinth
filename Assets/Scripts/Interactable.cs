using UnityEngine;
using UnityEngine.UI;

/*
 * This script will be used with every interactable object and whenever the player stays in the trigger area
 * a specific text will appear.
 */
public class Interactable : MonoBehaviour
{
    // The text that will be shown when the player enters the trigger area
    public Text text;

    private void Awake()
    {
        if (text == null)
        {
            Debug.Log("Game Object : " + gameObject.name + " does not have a text component assigned.");
        }
        else
        {
            text.gameObject.transform.position = GetComponentInParent<Transform>().position + new Vector3(0f, 1f, 0f);
            text.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player entered");
            text.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player exited");
            text.gameObject.SetActive(false);
        }
    }
}
