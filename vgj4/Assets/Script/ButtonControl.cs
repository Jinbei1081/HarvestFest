using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NCMB;
using UnityEngine.UI;
using TMPro;

public class ButtonControl : MonoBehaviour
{
    [SerializeField]
    TMP_InputField inputField;
    [SerializeField]
    TextMeshProUGUI text;

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    public void Tite()
    {
        SceneManager.LoadScene("Title");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void OpenHTP()
    {
        SceneManager.LoadScene("HTP",LoadSceneMode.Additive);
    }
    public void CloseHTP()
    {
        SceneManager.UnloadSceneAsync("HTP");
    }
    public void Ranking()
    {
        SceneManager.LoadScene("Ranking");
    }
    public void RegistRanking()
    {
        if (inputField.text=="")
        {
            text.text = "※名前を入力してください";
            return;
        }

        NCMBObject obj = new NCMBObject("Later_v12_Ranking");

        Debug.Log(inputField.text);
        Debug.Log(ScoreManager.Score);


        obj["Name"] = inputField.text;
        obj["Score"] = ScoreManager.Score;

        obj.SaveAsync((NCMBException e) =>
        {
            if (e != null)
            {
                text.text = "登録に失敗しました";
            }
            else
            {
                text.text = "登録完了しました";
            }
        });
    }
    public void Tweet()
    {
        Application.OpenURL("http://twitter.com/intent/tweet?text=" + WWW.EscapeURL("#ことのは姉妹の不思議な木の実収穫祭 でエビフライとチョコミントアイスを回収して" + ScoreManager.Score+ "ポイント獲得しました\nゲームはこちらから↓\nhttps://jinbei1081.itch.io/kotonohaharvestfestival"));
    }

}
