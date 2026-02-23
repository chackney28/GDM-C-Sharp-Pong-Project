using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using System.Collections;

public class StartGameButton : NetworkBehaviour
{
    public Button startButton;


    public NetworkVariable<bool> GameStarted = new NetworkVariable<bool>(false);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        Button btn = startButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
    }
    public void TaskOnClick(){
        NetworkManager.Singleton.StartHost();
	}
}
