using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// ������� ���������� ������ �� ���������� ����������� �������
    /// </summary>
    public class LevelConditionPosition : MonoBehaviour, ILevelCondition
    {
        /// <summary>
        /// �������
        /// </summary>
        [SerializeField] private Trigger m_Area;

        /// <summary>
        /// ���������� �� ����
        /// </summary>
        private bool m_Reached = false;

        public bool IsCompleted => m_Reached;

        private void Start()
        {
            m_Area.Enter.AddListener(OnAreaReached);
        }

        private void OnDestroy()
        {
            m_Area.Enter.RemoveListener(OnAreaReached);
        }

        /// <summary>
        /// �������� ��� ���������� �������
        /// </summary>
        private void OnAreaReached()
        {
            m_Reached = true;
        }
    }
}