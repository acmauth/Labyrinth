using UnityEngine;

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
