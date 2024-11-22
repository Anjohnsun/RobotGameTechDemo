using System;
using UnityEngine;

public class GameplayEntryPoint : MonoBehaviour
{
    private event Action GoToMainMenuSceneRequested;


    [SerializeField] private UIGameplayRootBinder _sceneUIRootPrefab;

    public void Run(UIRootView uiRoot)
    {
        var uiScene = Instantiate(_sceneUIRootPrefab);

        uiRoot.AttachSceneUI(uiScene.gameObject);

        uiScene.GoToMainMenuButtonClicked += () =>
        {
            GoToMainMenuSceneRequested?.Invoke();
        };
    }
}
