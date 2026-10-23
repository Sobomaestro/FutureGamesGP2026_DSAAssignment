using TMPro;
using UnityEngine;

public class WalletUI : MonoBehaviour
{
    [SerializeField] ScriptableObject beastCoin;
    [SerializeField] CanvasGroup walletUI;
    [SerializeField] TextMeshProUGUI coinText;
    
    public void AddCoins(int amount)
    {
        walletUI.alpha = 1;
        coinText.text += "$" + amount.ToString();
    }




}
