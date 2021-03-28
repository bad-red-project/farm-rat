using UnityEngine;
using System.Diagnostics;

public class LoadNewScene : MonoBehaviour
{
    public string levelToLoad;
    public long neededStayTimeMillis;
    private Stopwatch timeStayed = new Stopwatch();

    private string PLAYER = "Player";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

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
            TryEnterNewLocation();
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
