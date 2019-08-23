using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public SceneFader sceneFader;

    void Start()
    {
        
    }
    //The way this work is when you want to call a certain scene,
    //you will need to give it a number in the inspector to change scenes.
    //So make sure that the build setting is se]t up properly.
    public void ChangeScene(int sceneIndex)
    {
        StartCoroutine(GameObject.FindObjectOfType<SceneFader>().FadeAndLoadScene(SceneFader.FadeDirection.Out));
        Debug.Log("Changing Scene");
        StartCoroutine(LoadAsync(sceneIndex));  
    }


    //With loadScene, is makes unity stop everything and focus on chnaging scene.
    //By doing this while playing VR, it changes the scene to an empty void before going, 
    //to the new scene. While using a loadScene.Asynce, unity will do this in the background,
    //so that you skip being in this empty void for a bit.
    IEnumerator LoadAsync (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while(!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(progress);


            yield return null;
        }
    }


}
