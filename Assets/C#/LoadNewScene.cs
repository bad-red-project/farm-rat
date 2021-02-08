using UnityEngine;
using System.Diagnostics;

public class LoadNewScene : MonoBehaviour
{
    public string levelToLoad;
    public long millisBeforeEnter;
    //private Stopwatch

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

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            //if (stayingTime > millisBeforeEnter) {
            //    enterNewLocation(collision);
            //}
        }
    }
    
    private void EnterNewLocation(Collider2D collision) {
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelToLoad);
    }
}
