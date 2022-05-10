using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartManager : MonoBehaviour
{
    public static RestartManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Restart()
    {
        StartCoroutine(RestartCo());
    }

    private IEnumerator RestartCo()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
