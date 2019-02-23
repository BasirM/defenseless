using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Control : MonoBehaviour
{
    public AudioSource music;
    public AudioSource startGameSound;

    public void StartGame()
    {
        music.Stop();
        startGameSound.Play();
        StartCoroutine(ActuallyStartGame());
    }

    IEnumerator ActuallyStartGame()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}