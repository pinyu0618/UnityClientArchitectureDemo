using UnityEngine;
using UnityEngine.UI;

public enum EPopUpType
{
    YES_OR_NO = 0,
    ONLY_YES = 1
}

public class PopUpView : ButtonViewBasic
{
    [SerializeField] private RectTransform m_rtPopUpPanel;
    [SerializeField] private Button m_btnClose;
    [SerializeField] private Button m_btnYes;
    [SerializeField] private Button m_btnNo;
    [SerializeField] private Text m_txtContent;

    private const float POPUP_PANEL_PANEL_HEIGHT_SCALE = 0.45f;

    private string m_sYesText => "¬O";
    private string m_sConfirmText => "½T»{";
    private string m_sNoText => "§_";

    private bool m_bSetButton = false;
    private bool m_bInit = false;

    private DConfirmCallback m_dConfirmCallback = null;

    public void SetAndShow(EPopUpType _eType, string _sInfo, DConfirmCallback _dConfirmCallback = null)
    {
        Init();
        SetPopUpType(_eType);

        m_txtContent.text = _sInfo;
        m_dConfirmCallback = _dConfirmCallback;

        Show();
    }

    protected override void SetButton()
    {
        if (!m_bSetButton)
        {
            AddListener(m_btnClose, ShowOff);
            AddListener(m_btnYes, ClickYes);
            AddListener(m_btnNo, ClickNo);
            m_bSetButton = true;
        }
    }

    private void Init()
    {
        if (!m_bInit)
        {
            SetPanelHeight(m_rtPopUpPanel, POPUP_PANEL_PANEL_HEIGHT_SCALE);
            m_bInit = true;
        }
    }

    private void SetPopUpType(EPopUpType _eType)
    {
        if (_eType == EPopUpType.ONLY_YES)
        {
            ShowObj(m_btnYes);
            ShowObjOff(m_btnNo);

            m_btnYes.GetComponentInChildren<Text>().text = m_sConfirmText;
        }
        else
        {
            ShowObj(m_btnYes);
            ShowObj(m_btnNo);

            m_btnYes.GetComponentInChildren<Text>().text = m_sYesText;
            m_btnNo.GetComponentInChildren<Text>().text = m_sNoText;

        }
    }

    private void ClickYes()
    {
        m_dConfirmCallback?.Invoke(true);
        ShowOff();
    }

    private void ClickNo()
    {
        m_dConfirmCallback?.Invoke(false);
        ShowOff();
    }
}
