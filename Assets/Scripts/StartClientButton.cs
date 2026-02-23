using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using System.Collections;

public class StartClientButton : NetworkBehaviour
{
    public Button startButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        Button butn = startButton.GetComponent<Button>();
		butn.onClick.AddListener(TaskOnClick);
    }
    public void TaskOnClick(){
        NetworkManager.Singleton.StartClient();
	}
}