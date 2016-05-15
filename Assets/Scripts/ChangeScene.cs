using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour 
{
    public int lvNum;
    private Animator anim;

    void Start()
    {
        lvNum = 1; //Placeholder number
    }

    void Update()
    {
        // If its one of the first 2 Logos scene call SceneChangeInit to load next scene in the build settings
        if(SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 1)
            StartCoroutine(SceneChangeInit(SceneManager.GetActiveScene().buildIndex));
    }

    public void SceneToChangeTo(int SceneToChangeTo)
    {
        lvNum = SceneToChangeTo;
        StartCoroutine("SceneChange");
    }

    // Use to Add a scene to current one 
    public void AddScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex,LoadSceneMode.Additive);        
    }

    //Unload the scene you added. OBS: Don't use different scene index from what you loaded.
    public void UnloadAddScene(int sceneIndex)
    {
        SceneManager.UnloadScene(sceneIndex);        
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

    /*//This part of code will be used after Exit Confirmation Popup have been done
    IEnumerator ExitGame()
    {
        yield return new WaitForSeconds(1);
        float fadeTime = GameObject.Find("Manager").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        Application.Quit();
                
    } */
}
