using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using NUnit.Framework.Constraints;

public class Manager : MonoBehaviour
{
    public List<string> SceneNames;

    public GameObject player;

    public bool playable;

    public bool introPlaying = true;

    private Vector3 startPos;
    private string startScene;

    private void Start()
    {
        //startScene = "TrainStop";

        //foreach(string i in SceneNames)
        //{
        //    if(i != "ManagerScene")
        //    {
        //        if (!SceneManager.GetSceneByName(i).isLoaded)
        //        {
        //            SceneManager.LoadSceneAsync(i, LoadSceneMode.Additive);
        //        }
        //    }
        //}

        //SwitchScene("TrainStop", 3.21f, 26.19f, -2.384f, 90);

        startPos = player.transform.position;

    }

    private void Update()
    {
        //if (player.GetComponent<TriggerCollider>().isTriggered())
        //{
        //    if (startScene == "TrainStop")
        //    {
        //        //Were at the trainstop
        //        //Going to tunnel

        //        SwitchScene("TheTunnel", 0.98f, 10.6f, -18.44f, 180);
        //        startPos = player.transform.position;
        //        startScene = "TheTunnel";

        //    }
        //    else if (startScene == "TheTunnel")
        //    {
        //        //Were at the tunnel
        //        //Going to trainstop

        //        SwitchScene("TrainStop", 3.21f, 26.19f, -2.384f, 90);
        //        startPos = player.transform.position;
        //        startScene = "TrainStop";
        //    }
        //}


        //// Resets to the train stop scene
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    SwitchScene(startScene, startPos.x, startPos.y, startPos.z, 90);
        //}
        //// Goes to the tunnel and if at the tunnel then back to the trainstop
        //else if (Input.GetKeyDown(KeyCode.T))
        //{
        //    if (startScene == "TrainStop")
        //    {
        //        //Were at the trainstop
        //        //Going to tunnel

        //        SwitchScene("TheTunnel", 0.98f, 10.6f, -18.44f, 180);
        //        startPos = player.transform.position;
        //        startScene = "TheTunnel";

        //    }
        //    else if (startScene == "TheTunnel")
        //    {
        //        //Were at the tunnel
        //        //Going to trainstop

        //        SwitchScene("TrainStop", 3.21f, 26.19f, -2.384f, 90);
        //        startPos = player.transform.position;
        //        startScene = "TrainStop";
        //    }
        //}
    }

    public void play()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Enables or Disables a target scene
    /// </summary>
    /// <param name="targetScene"></param>
    /// <param name="mode"></param>
    void SceneMode(string targetScene, bool mode)
    {
        Scene scene = SceneManager.GetSceneByName(targetScene);


        if (scene.IsValid() && scene.isLoaded)
        {
            foreach (GameObject i in scene.GetRootGameObjects())
            {
                i.SetActive(mode);
            }
        }
    }
    /// <summary>
    /// Switches scene while keeping the player in the same position
    /// </summary>
    /// <param name="targetScene"></param>
    public void SwitchScene(string targetScene)
    {
        Scene managerScene = SceneManager.GetSceneByBuildIndex(0);

        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);

            if (scene.name == targetScene)
            {
                SceneMode(scene.name, true);
            }
            else
            {
                if (scene.name != managerScene.name) { SceneMode(scene.name, false); }
            }
        }
    }
    /// <summary>
    /// Switches the scene while changing the position and rotation of the player
    /// </summary>
    /// <param name="targetScene"></param>
    /// <param name="spawnx"></param>
    /// <param name="spawny"></param>
    /// <param name="spawnz"></param>
    /// <param name="rot"></param>
    public void SwitchScene(string targetScene, float spawnx, float spawny, float spawnz, float rot)
    {
        Scene managerScene = SceneManager.GetSceneByBuildIndex(0);

        player.transform.rotation = Quaternion.Euler(0, rot, 0);

        player.transform.position = new Vector3(spawnx, spawny, spawnz);

        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);

            if(scene.name == targetScene)
            {
                SceneMode(scene.name, true);
            }
            else {
                if (scene.name != managerScene.name) { SceneMode(scene.name, false); }
            }
        }
    }

    public string GetStartScene()
    {
        return startScene;
    }
    public Vector3 GetStartPos()
    {
        return startPos;
    }
    public void SetStartPos(Vector3 startPos)
    {
        this.startPos = startPos;
    }
    public void UnLoadAll()
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene= SceneManager.GetSceneAt(i);

            if(SceneManager.GetSceneAt(i).name != "ManagerScene")
            {
                if (scene.IsValid() && scene.isLoaded)
                {
                    foreach (GameObject j in scene.GetRootGameObjects())
                    {
                        j.SetActive(false);
                    }
                }
            }
        }
    }

    public void quit()
    {
        Application.Quit();
        Debug.Log("Quitting...");
    }
}
