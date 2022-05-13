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

    private void Start()
    {
        InvokeRepeating("CheckForWin", 0, 5);
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

    void CheckForWin()
    {
        StartCoroutine(CheckForWinCo());
    }

    private IEnumerator CheckForWinCo()
    {
        if (FindObjectOfType<EnemyShip>() || FindObjectOfType<Planet>())
        {

        }
        else
        {
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(0);
        }
    }
}
