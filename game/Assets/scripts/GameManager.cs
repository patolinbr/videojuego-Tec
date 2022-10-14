using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{
    bool gameHasEnded = false;

    int restartdelay = 0;
    public void gameOver ()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("game over");
            Invoke("Restart", restartdelay);
        }
        
    }

    void Restart()
    {
        SceneManager.LoadScene(sceneBuildIndex: 2);
    }
}
