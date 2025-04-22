using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKey(KeyCode.R)) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (Input.GetKey(KeyCode.Alpha1))
        {
            if(SceneManager.GetActiveScene().name == "TrainStop")
            {
                SceneManager.LoadScene("TheTunnel");
            }
            else if(SceneManager.GetActiveScene().name == "TheTunnel")
            {
                SceneManager.LoadScene("TrainStop");
            }
        }
    }
}
