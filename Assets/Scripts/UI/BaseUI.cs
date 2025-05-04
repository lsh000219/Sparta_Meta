using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected UIManager uiManager;

    public virtual void Init(UIManager uiManager)
    {
        this.uiManager = uiManager;
    }

    protected abstract UIManager.UIState GetUIState();
    public void SetActive(UIManager.UIState state)
    {
        this.gameObject.SetActive(GetUIState() == state);
    }
}