using UnityEngine;
using System.Diagnostics;

public class LoadNewScene : MonoBehaviour
{
    public string levelToLoad;
    public long neededStayTimeMillis;
    private Stopwatch timeStayed = new Stopwatch();

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
        if (collision.gameObject.name == "PlayersBoxCollider")
        {
            UnityEngine.Debug.Log("player entered");
            timeStayed.Start();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayersBoxCollider")
        {
            TryEnterNewLocation();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayersBoxCollider")
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
