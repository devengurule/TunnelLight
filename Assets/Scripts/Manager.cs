using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using NUnit.Framework.Constraints;
using UnityEngine.Rendering;
using System.Collections;

public class Manager : MonoBehaviour
{
    public List<string> SceneNames;
    public GameObject player;
    public GameObject train;
    public float trainSpeed;
    public bool playable;
    public bool introPlaying;
    public bool trainStopPlaying;
    public bool spawnTrain;
    private bool change;
    private Volume volume;
    public float fadeDuration = 1f;

    private void Start()
    {
        volume = GetComponent<Volume>();
        volume.weight = 1f;

        if (SceneManager.GetActiveScene().name == "Intro")
        {
            trainStopPlaying = false;
            introPlaying = true;
            playable = false;
            spawnTrain = false;
        }
        else if (SceneManager.GetActiveScene().name == "TrainStop")
        {
            trainStopPlaying = true;
            introPlaying = false;
            playable = false;
            spawnTrain = false;
        }

        StartCoroutine(FadeOut());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            spawnTrain = true;
        }
        if (spawnTrain)
        {
            spawnTrain = false;

            SpawnTrain(new Vector3(0, 0, trainSpeed), false, new Vector3(22.88f, 25.44f, -178.79f));
        }   
    }
    public void play()
    {
        StartCoroutine(FadeIn());
    }
    public void quit()
    {
        Application.Quit();
        Debug.Log("Quitting...");
    }

    private IEnumerator FadeIn()
    {
        float elapsed = 0f;
        float startWeight = volume.weight;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            volume.weight = Mathf.Lerp(startWeight, 1f, elapsed / fadeDuration);
            yield return null;
        }

        volume.weight = 0f;
        SceneManager.LoadScene(1);
    }
    private IEnumerator FadeOut()
    {
        float elapsed = 0f;
        float startWeight = volume.weight;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            volume.weight = Mathf.Lerp(startWeight, 0f, elapsed / fadeDuration);
            yield return null;
        }

        volume.weight = 0f;
    }

    void SpawnTrain(Vector3 move, bool direction, Vector3 spawnPos)
    {
        GameObject trainObject = Instantiate(train, spawnPos, Quaternion.Euler(0,0,0));
        TrainMoving trainScript = trainObject.GetComponent<TrainMoving>();
        trainScript.Initialize(player, direction, move);
    }
}
