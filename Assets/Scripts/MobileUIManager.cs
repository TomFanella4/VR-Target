using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MobileUIManager : MonoBehaviour
{
    [SerializeField]
    private Button startClientButton;

    [SerializeField]
    private TMP_InputField joinCodeInput;

    [SerializeField]
    private GameObject loadingText;

    [SerializeField]
    private GameObject mobilePlayer;

    private void Start()
    {
        startClientButton.onClick.AddListener(() =>
        {
            joinCodeInput.gameObject.SetActive(false);
            startClientButton.gameObject.SetActive(false);
            loadingText.SetActive(true);
            RelayManager.Instance.JoinRelayGame(joinCodeInput.text);
        });
    }
}
