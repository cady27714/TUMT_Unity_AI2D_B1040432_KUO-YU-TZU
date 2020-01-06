using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour
{
    public enum state
    {
        normal,notComplete,complete
    }

    public state _state;

    [Header("對話")]
    public string sayStart = "來自遠方的旅人啊~能請你幫我撿回我掉落的金幣嗎?";
    public string sayNotComplete = "我掉的不只這些金幣呢...";
    public string sayComplete = "總共是這些金幣沒錯！太感謝你了~";
    [Header("速度")]
    public float speed = 1.5f;
    [Header("任務")]
    public bool complete;
    public int countPlayer;
    public int countFinish = 10;
    [Header("介面")]
    public GameObject objCanvas,QQ;
    public Text textSay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "QQ")
        {
            Say();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "QQ")
        {
            SayClose();
        }
    }
    private void Say()
    {
        objCanvas.SetActive(true);
        StopAllCoroutines();

        if (countPlayer >= countFinish) _state = state.complete;

        switch (_state)
        {
            case state.normal:
                textSay.text = sayStart;
                _state = state.notComplete;
                break;
            case state.notComplete:
                textSay.text = sayNotComplete;
                break;
            case state.complete:
                textSay.text = sayComplete;
                QQ.GetComponent<character>().win();
                break;
        }
    }

    private void SayClose()
    {
        objCanvas.SetActive(false);
    }

    public void PlayerGet()
    {
        countPlayer++;
    }
}
