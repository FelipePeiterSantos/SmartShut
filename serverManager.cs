using UnityEngine;
using System.Diagnostics;
using System.Collections;

public class serverManager : MonoBehaviour {

    public UnityEngine.UI.Text status;

    void Start() {
        status.text = "Disconnected";
        InvokeRepeating("UpdateScript",1f,1f);
        if(Network.peerType == NetworkPeerType.Disconnected) {
            Network.InitializeServer(1, 25001,false);
            status.text = "Activating...";
        }
    }

    void UpdateScript() {
        if(Network.peerType == NetworkPeerType.Server) {
            if(Network.connections.Length <= 0) {
                status.text = "Connect your device to '" + Network.player.ipAddress+"' to Shutdown this PC.";
            }
            else {
                status.text = "Shutting down...";
                Process.Start(Application.streamingAssetsPath + "/shutdown.bat");
                Application.Quit();
            }
        }
    }
}
