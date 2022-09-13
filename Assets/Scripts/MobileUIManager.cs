using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MobileUIManager : MonoBehaviour
{
    [SerializeField]
    private Button startHostButton;

    [SerializeField]
    private Button startClientButton;

    [SerializeField]
    private TMP_InputField joinCodeInput;

    private void Start()
    {
        startHostButton.onClick.AddListener(() =>
        {
            SceneTransitionHandler.Instance.isXR = false;
            SceneTransitionHandler.Instance.InitializeAsHost = true;
            SceneTransitionHandler.Instance.Initialize();
        });

        startClientButton.onClick.AddListener(() =>
        {
            SceneTransitionHandler.Instance.isXR = false;
            SceneTransitionHandler.Instance.InitializeAsHost = false;
            SceneTransitionHandler.Instance.joinCode = joinCodeInput.text;
            SceneTransitionHandler.Instance.Initialize();
        });
    }
}
