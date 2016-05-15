using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour 
{
    public int lvNum;
    private Animator anim;

    void Start()
    {
        lvNum = 1;
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 1)
            StartCoroutine(SceneChangeInit(SceneManager.GetActiveScene().buildIndex));
    }

    public void SceneToChangeTo(int SceneToChangeTo)
    {
        lvNum = SceneToChangeTo;
        StartCoroutine("SceneChange");
    }

    public void AddScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex,LoadSceneMode.Additive);
        if (sceneIndex == 2)
        {
            anim = GameObject.Find("PauseBG").GetComponent<Animator>();
            anim.SetTimeUpdateMode(UnityEngine.Experimental.Director.DirectorUpdateMode.UnscaledGameTime);
            Time.timeScale = 0;
        }
    }

    public void UnloadAddScene(int sceneIndex)
    {
        SceneManager.UnloadScene(sceneIndex);        
    }

    public void UnloadPauseAnim(int sceneIndex)
    {
        StartCoroutine(PauseExit(sceneIndex));
    }

    IEnumerator SceneChange()
    {
        float fadeTime = GameObject.Find("Manager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);        
        SceneManager.LoadScene(lvNum);        
    }

    IEnumerator SceneChangeInit(int sceneIndex)
    {       
        yield return new WaitForSeconds(2);
        float fadeTime = GameObject.Find("Manager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);        
        SceneManager.LoadScene(sceneIndex + 1);        
    }

    IEnumerator ExitGame()
    {
        yield return new WaitForSeconds(1);
        float fadeTime = GameObject.Find("Manager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        Application.Quit();
                
    }

    IEnumerator PauseExit(int indexNum)
    {        
        anim = GameObject.Find("PauseBG").GetComponent<Animator>();
        anim.SetBool("IsExit", true);
        yield return new WaitForSeconds(1);
        Time.timeScale = 1;
        SceneManager.UnloadScene(indexNum);
    }    
}
