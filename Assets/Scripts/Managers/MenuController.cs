using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Function to handle click on "Play Game" text
    public void PlayGame()
    {
        Debug.Log("Play Game clicked");
        SceneManager.LoadScene("SampleScene");
    }

    // Function to handle click on "Instructions" text
    public void OpenInstructions()
    {
        Debug.Log("Instructions clicked");
        SceneManager.LoadScene("InstructionsScene");
    }

    // Function to handle click on "Options" text
    public void OpenOptions()
    {
        Debug.Log("Options clicked");
        SceneManager.LoadScene("OptionsScene");
    }

    // Function to handle click on "Back" text
    public void GoBack()
    {
        Debug.Log("Back clicked");
        SceneManager.LoadScene("MainMenu");
    }

    // Function to handle click on "Quit" text
    public void QuitGame()
    {
        Debug.Log("Quit clicked");
        Application.Quit();
    }

    // Function to handle click on "Play Again" text
    public void PlayAgain()
    {
        Debug.Log("Play Again clicked");
<<<<<<< Updated upstream
        SceneManager.LoadScene("MainMenu"); // Load the Main Menu again
=======
        SceneManager.LoadScene("MainMenu"); 
>>>>>>> Stashed changes
    }

   
}
