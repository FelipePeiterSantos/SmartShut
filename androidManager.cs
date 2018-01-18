using UnityEngine;
using System.Collections;

public class androidManager : MonoBehaviour {

    public UnityEngine.UI.InputField inputIP;
    public UnityEngine.UI.Text textTop;
    public GameObject connect;

    void Start() {
        textTop.text = "Connect your device";
        if(PlayerPrefs.GetString("IPServer") != "") {
            inputIP.text = PlayerPrefs.GetString("IPServer");
        }
    }

    void Update() {
        if(inputIP.text != "" && !connect.activeSelf) {
            connect.SetActive(true);
        }
        else if(inputIP.text == "" && connect.activeSelf) {
            connect.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Escape)) {
            ExitButton();
        }
    }

    public void ConnectButton() {
        textTop.text = "Connecting...";
        Network.Connect(inputIP.text,25001);
    }

    public void ExitButton() {
        Network.Disconnect();
        Application.Quit();
    }

    public void ShutdownButton() {

    }

    void OnConnectedToServer() {
        textTop.text = "Connected!";
        PlayerPrefs.SetString("IPServer", inputIP.text);
    }

    void OnDisconnectedFromServer() {
        textTop.text = "Disconnected.";
        inputIP.text = "";
    }

    void OnFailedToConnect() {
        textTop.text = "Fail to connect.";
        inputIP.text = "";
    }
}
