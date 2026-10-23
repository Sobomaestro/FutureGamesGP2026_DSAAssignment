using UnityEngine;
using TMPro;
[CreateAssetMenu(fileName = "BeastCoin", menuName = "Scriptable Objects/BeastCoin")]
public class BeastCoin : ScriptableObject
{
    [SerializeField] TextMeshProUGUI beastWallet;
    [SerializeField] CanvasGroup beastPanel;
    public int beastCoin;
    public int beastValue;
    public void AddCoins(int money)
    {
        beastCoin += money;
        beastWallet.text = beastCoin.ToString();
        if (beastCoin > 0)
        {
            beastPanel.alpha = 1;
        }
    }
}
