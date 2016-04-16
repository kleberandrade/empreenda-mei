using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject m_PausePanel;
    private AudioSource m_AudioSource;

    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }
    
	private void Update ()
    {
	    if (Input.GetKeyDown(KeyCode.Escape))
        {
            Change();
        }
	}

    public void Change()
    {
        m_AudioSource.Play();
        m_PausePanel.SetActive(!m_PausePanel.activeInHierarchy);
        Time.timeScale = 1 - Time.timeScale;
    }

    public void QuitGame()
    {
        Change();
        SceneManager.LoadScene("Menu");
    }
}
