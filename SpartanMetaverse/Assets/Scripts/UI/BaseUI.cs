using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseUI : MonoBehaviour
{
    protected UIManager uiManager;
    public virtual void Init(UIManager uiManager)
    {
        this.uiManager = uiManager;
    }

    protected abstract UIState GetUIState(); // UI의 상태를 결정

    public void SetActive(UIState state) // 상태에 맞는 UI를 true
    {
        if (this == null) return; // 파괴된 오브젝트를 거르기 위해
        this.gameObject.SetActive(GetUIState() == state);
    }
}
