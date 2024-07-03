using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public class DetectInputtwoJoyStickManet : MonoBehaviour
{
    public List<DetectInputtwoJoyStickManet_float> m_floatInput = new List<DetectInputtwoJoyStickManet_float>();
    [System.Serializable]
    public class DetectInputtwoJoyStickManet_float
    {
        public string m_description;
        public InputActionReference m_whatToObserve;
        public float m_value;
        public UnityEvent<float> m_onChanged;


        public void StartListening()
        {
            m_whatToObserve.action.Enable();
            m_whatToObserve.action.performed += (e) =>
            {
                m_value = e.ReadValue<float>();
                m_onChanged.Invoke(m_value);
            };
            m_whatToObserve.action.canceled += (e) =>
            {
                m_value = e.ReadValue<float>();
                m_onChanged.Invoke(m_value);
            };
        }

        public void StopListening()
        {
            m_whatToObserve.action.Disable();
            m_whatToObserve.action.performed -= (e) =>
            {
                m_value = e.ReadValue<float>();
                m_onChanged.Invoke(m_value);
            };
            m_whatToObserve.action.canceled -= (e) =>
            {
                m_value = e.ReadValue<float>();
                m_onChanged.Invoke(m_value);
            };
        }
    }

    private void OnEnable()
    {
        foreach (var t in m_floatInput)
            t.StartListening();
    }
    private void OnDisable()
    {
        foreach (var t in m_floatInput)
            t.StopListening();
    }
}
