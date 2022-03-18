using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader instance;

    public Animator transition;
    public float transitionTime = 1f;

    public Characters playerData;
    public GameObject player;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadLevel(string levelName)
    {
        StartCoroutine(LoadNamedLevel(levelName));
    }

    IEnumerator LoadNamedLevel(string levelName)
    {
        //Start transition animation
        //transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelName);
        
        //if (levelName == "SampleScene")
        //{
        //    player.transform.position = new Vector3(playerData.position[1], playerData.position[2], playerData.position[3]);
        //}

        //End transition animation
        //transition.SetTrigger("End");
    }
}
