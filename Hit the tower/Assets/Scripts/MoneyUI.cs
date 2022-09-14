using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    // Start is called before the first frame update

    void Update()
    {
        moneyText.text = "$" + PlayerStats.Money.ToString();
    }
}
