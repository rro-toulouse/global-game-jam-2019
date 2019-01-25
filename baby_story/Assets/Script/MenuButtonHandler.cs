using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonHandler : MonoBehaviour
{
    private static bool highscoreActive = true;
    private static bool creditsActive = true;

    public void playButton()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void highscoreButton()
    {
        GameObject highscoreList = GameObject.FindGameObjectWithTag("Highscore");

        if (highscoreList)
        {
            highscoreList.GetComponent<UnityEngine.UI.Text>().enabled = highscoreActive;
            highscoreActive = !highscoreActive;
        }
    }

    public void creditsButton()
    {
        GameObject[] creditPictureList = GameObject.FindGameObjectsWithTag("CreditPicture");


        if (creditPictureList != null)
        {
            foreach (GameObject creditPicture in creditPictureList)
            {
                creditPicture.GetComponent<Image>().enabled = creditsActive;
            }
            creditsActive = !creditsActive;
        }
    }

    public void quitButton()
    {
        Application.Quit();
    }
}
