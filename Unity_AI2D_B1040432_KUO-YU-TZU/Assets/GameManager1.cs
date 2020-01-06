using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{


    public void Replay()
    {
        //Application.LoadLevel("遊戲");
        SceneManager.LoadScene("Demo");
    }

    public void Quit()
    {
        Application.Quit();
    }


}
