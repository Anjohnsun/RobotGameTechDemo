using UnityEngine;

public class UIRootView : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private Transform _uiSceneContainer;


    private void Awake()
    {
        _loadingScreen.SetActive(false);
    }

    public void ShowLoadingScreen()
    {
        _loadingScreen.SetActive(true);
    }

    public void HideLoadingScreen()
    {
        _loadingScreen.SetActive(false);
    }

    public void AttachSceneUI(GameObject sceneUI)
    {
        ClearSceneUI();

        sceneUI.transform.SetParent(_uiSceneContainer, false);
    }

    private void ClearSceneUI()
    {
        var childCount = _uiSceneContainer.childCount;
        for (int i = childCount-1; i >= 0; i--)
        {
            Destroy(_uiSceneContainer.GetChild(i).gameObject);
        }
    }
}
