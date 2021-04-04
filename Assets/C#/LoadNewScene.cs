using UnityEngine;
using System.Diagnostics;

public class LoadNewScene : MonoBehaviour
{
    public string levelToLoad;
    public string newLevelStartPointName;
    public long neededStayTimeMillis;
    private Stopwatch timeStayed = new Stopwatch();

    private string PLAYER = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == PLAYER)
        {
            timeStayed.Start();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == PLAYER)
        {
            TryEnterNewLocation();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == PLAYER)
        {
            timeStayed.Stop();
            timeStayed.Reset();
        }
    }

    private void TryEnterNewLocation() {
        long stayTime = timeStayed.ElapsedMilliseconds;
        if (stayTime > neededStayTimeMillis)
        {
             UnityEngine.SceneManagement.SceneManager.LoadScene(levelToLoad);
        }
    }
}
