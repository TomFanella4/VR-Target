using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class XRNetworkUI : MonoBehaviour
{
    [SerializeField]
    private Button startHostButton;

    [SerializeField]
    private GameObject loadingText;

    void Start()
    {
        startHostButton.onClick.AddListener(() => {
            startHostButton.gameObject.SetActive(false);
            loadingText.SetActive(true);
            RelayManager.Instance.CreateRelayGame(5);
        });
    }
}
