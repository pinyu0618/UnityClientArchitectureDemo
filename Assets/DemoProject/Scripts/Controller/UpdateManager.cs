using UnityEngine;
using System.Collections.Generic;

public delegate void DUpdate();

public class UpdateManager : MonoBehaviour, IUpdate
{
    private List<DUpdate> m_dListUpdate = new List<DUpdate>();
    private List<DUpdate> m_dListFixedUpdate = new List<DUpdate>();
    private List<UpdateTimer> m_ListTimer = new List<UpdateTimer>();

    private Queue<DUpdate> m_dQueAddUpdate = new Queue<DUpdate>();
    private Queue<DUpdate> m_dQueRemoveUpdate = new Queue<DUpdate>();
    private Queue<DUpdate> m_dQueAddFixedUpdate = new Queue<DUpdate>();
    private Queue<DUpdate> m_dQueRemoveFixedUpdate = new Queue<DUpdate>();
    private Queue<UpdateTimer> m_QueAddTimer = new Queue<UpdateTimer>();
    private Queue<UpdateTimer> m_QueRemoveTimer = new Queue<UpdateTimer>();

    public void RegisterTimer(UpdateTimer _dTimer)
    {
        m_QueAddTimer.Enqueue(_dTimer);
    }

    public void UnRegisterTimer(UpdateTimer _dTimer)
    {
        m_QueRemoveTimer.Enqueue(_dTimer);
    }

    public void RegisterUpdate(DUpdate _dUpdate)
    {
        m_dQueAddUpdate.Enqueue(_dUpdate);
    }

    public void RegisterFixedUpdate(DUpdate _dUpdate)
    {
        m_dQueAddFixedUpdate.Enqueue(_dUpdate);
    }

    public void UnRegisterUpdate(DUpdate _dUpdate)
    {
        m_dQueRemoveUpdate.Enqueue(_dUpdate);
    }

    public void UnRegisterFixedUpdate(DUpdate _dUpdate)
    {
        m_dQueRemoveFixedUpdate.Enqueue(_dUpdate);
    }

    private void UpdateProcessModifications()
    {
        while (m_dQueAddUpdate.Count > 0)
        {
            m_dListUpdate.Add(m_dQueAddUpdate.Dequeue());
        }
        while (m_dQueRemoveUpdate.Count > 0)
        {
            m_dListUpdate.Remove(m_dQueRemoveUpdate.Dequeue());
        }

        while (m_QueAddTimer.Count > 0)
        {
            m_ListTimer.Add(m_QueAddTimer.Dequeue());
        }
        while (m_QueRemoveTimer.Count > 0)
        {
            m_ListTimer.Remove(m_QueRemoveTimer.Dequeue());
        }
    }

    private void FixedUpdateProcessModifications()
    {
        while (m_dQueAddFixedUpdate.Count > 0)
        {
            m_dListFixedUpdate.Add(m_dQueAddFixedUpdate.Dequeue());
        }
        while (m_dQueRemoveFixedUpdate.Count > 0)
        {
            m_dListFixedUpdate.Remove(m_dQueRemoveFixedUpdate.Dequeue());
        }
    }

    private void Update()
    {
        UpdateProcessModifications();

        for (int i = 0; i < m_dListUpdate.Count; i++)
        {
            m_dListUpdate[i].Invoke();
        }

        for (int j = 0; j < m_ListTimer.Count; j++)
        {
            m_ListTimer[j].Check(Time.time);
        }
    }

    private void FixedUpdate()
    {
        FixedUpdateProcessModifications();

        for (int k = 0; k < m_dListFixedUpdate.Count; k++)
        {
            m_dListFixedUpdate[k].Invoke();
        }
    }
}

public class UpdateTimer
{
    private DUpdate m_dUpdate;
    private float m_fTriggerRate;
    private float m_fLastTriggerTime;
    private bool m_bTrigger;
    private bool m_bImmediately;

    public UpdateTimer(DUpdate _dUpdate, float _fRate, bool _bImmediately)
    {
        m_dUpdate = _dUpdate;
        m_fTriggerRate = _fRate;
        m_bImmediately = _bImmediately;

        m_bTrigger = m_bImmediately;
    }

    public void Check(float _fTime)
    {
        if (!m_bTrigger)
        {
            m_bTrigger = true;
            m_fLastTriggerTime = _fTime;
        }
        else
        {
            float fGap = (_fTime - m_fLastTriggerTime);
            if (fGap >= m_fTriggerRate)
            {
                m_fLastTriggerTime = _fTime;
                if (m_dUpdate != null)
                {
                    m_dUpdate.Invoke();
                }
            }
        }
    }

}