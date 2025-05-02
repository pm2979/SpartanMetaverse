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

    protected abstract UIState GetUIState();

    public void SetActive(UIState state)
    {
        if (this == null) return; // �ı��� ������Ʈ�� �Ÿ��� ����
       
        this.gameObject.SetActive(GetUIState() == state);
    }
}
