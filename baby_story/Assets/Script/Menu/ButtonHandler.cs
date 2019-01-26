using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    private static bool highscoreActive = false;
    private static bool creditsActive = false;

    public void playButton()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void highscoreButton()
    {
        if (setHighscoreVisibility(!highscoreActive))
        {
            highscoreActive = !highscoreActive;
            if (setCreditsVisibility(false))
                creditsActive = false;
        }

    }

    public void creditsButton()
    {
        if (setCreditsVisibility(!creditsActive))
        {
            creditsActive = !creditsActive;
            if (setHighscoreVisibility(false))
                highscoreActive = false;
        }
    }

    public void quitButton()
    {
        Application.Quit();
    }

    private bool setCreditsVisibility(bool visibility)
    {
        GameObject[] creditPictureList = GameObject.FindGameObjectsWithTag("CreditPicture");

        if (creditPictureList != null)
        {
            foreach (GameObject creditPicture in creditPictureList)
                creditPicture.GetComponent<Image>().enabled = visibility;
        }
        else
            return false;
        return true;
    }

    public void menuButton()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    /**
     * Internal mechanics menu 
     */
    private bool setHighscoreVisibility(bool visibility)
    {
        GameObject highscoreList = GameObject.FindGameObjectWithTag("Highscore");

        if (highscoreList)
            highscoreList.GetComponent<UnityEngine.UI.Text>().enabled = visibility;
        else
            return false;
        return true;
    }
}
