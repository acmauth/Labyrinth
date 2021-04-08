using UnityEngine;

/*
 * This script controls how the Canvas for the in game will work. Basically it checks to see if we have paused
 * the game or if there is anything we need to update in the player's screen.
 *
 * Αυτό το script ελέγχει το πως ο canvas για το παιχνίδι θα δουλέυει. Με λίγα λόγια ελέγχει άμα το παιχνίδι έχει
 * γίνει paused ή άμα υπάρχει κάτι που πρέπει να ανανεώσουμε στην οθόνη του χρήστη.
 */
public class ControlCanvas : MonoBehaviour
{
    public GameObject inGameMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.GetComponent<Canvas>().worldCamera == null)
        {
            Canvas canvas = gameObject.GetComponent<Canvas>();
            canvas.worldCamera = Camera.main;
            canvas.planeDistance = 3f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) inGameMenu.SetActive(!inGameMenu.activeSelf);
    }
}
