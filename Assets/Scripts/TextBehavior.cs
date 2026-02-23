using UnityEngine;
using Unity.Netcode;
using TMPro;

/*
public class TextBevaior: NetworkBehaviour
{
    public TextMeshProUGUI leftScoreText;
    public TextMeshProUGUI rightScoreText;

    void Start()
    {
        pongManager = FindObjectOfType<PongManager>();
    }

    void Update()
    {
        // Read NetworkVariable values and update UI
        leftScoreText.text = "" + pongManager.getLeftScore();
        rightScoreText.text = "" + pongManager.getRightScore();
    }
}
public class PongManager : NetworkBehaviour
{
    public NetworkVariable<int> LeftPoints = new NetworkVariable<int>(0);
    public NetworkVariable<int> RightPoints = new NetworkVariable<int>(0);
        
    public int GetLeftScore()
    {
        return LeftPoints.Value;
    }
        
    public int GetRightPoints()
    {
        return RightPoints.Value;
    }
}
*/