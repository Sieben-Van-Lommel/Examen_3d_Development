using UnityEngine;
using UnityEngine.InputSystem;

public class GameMenuManager : MonoBehaviour
{
    public GameObject menu;
    public InputActionProperty showButton;
    public Transform head;
    public float spawnDistance = 1;

    //menu
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject deadScreen;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        // Zorg ervoor dat het menu bij de start verborgen is
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (showButton.action.WasPressedThisFrame())
        {
            // Wissel de actieve status van het menu
            bool isMenuActive = !menu.activeSelf;
            menu.SetActive(isMenuActive);

            // Pauzeer of hervat de game
            if (isMenuActive)
            {
                // Pauzeer het spel
                Time.timeScale = 0;
            }
            else
            {
                // Hervat het spel
                Time.timeScale = 1;
            }

            // Plaats het menu voor de speler
            menu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
        }

        // Zorg ervoor dat het menu naar de speler blijft kijken
        if (menu.activeSelf)
        {
            menu.transform.LookAt(new Vector3(head.position.x, menu.transform.position.y, head.position.z));
            menu.transform.forward *= -1;
        }
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Debug.Log(" presssseefdsddd");
        
    }

    public void OptionsMenu()
    {
        optionsMenu.SetActive(true);
    }
    public void BackButton()
    {
        optionsMenu.SetActive(false);
    }
    public void DeadScreen(GameObject endscreen)
    {
        deadScreen.SetActive(true);
    }
}
