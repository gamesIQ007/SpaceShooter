using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// ������������� ���������
    /// </summary>
    public class AIController : MonoBehaviour
    {
        /// <summary>
        /// ������������ ��������� AI
        /// </summary>
        public enum AIBehaviour
        {
            Null,
            Patrol
        }

        /// <summary>
        /// ���������
        /// </summary>
        [SerializeField] private AIBehaviour m_AIBehaviour;

        /// <summary>
        /// �������� �����������
        /// </summary>
        [Range(0.0f, 1.0f)]
        [SerializeField] private float m_NavigationLinear;

        /// <summary>
        /// �������� ��������
        /// </summary>
        [Range(0.0f, 1.0f)]
        [SerializeField] private float m_NavigationAngular;

        /// <summary>
        /// ������ ��������� �������
        /// </summary>
        [SerializeField] private float m_RandomSelectMovePointTime;

        /// <summary>
        /// ������ ��������� ����
        /// </summary>
        [SerializeField] private float m_FindNewTargetTime;

        /// <summary>
        /// ������ ��������
        /// </summary>
        [SerializeField] private float m_ShootDelay;

        /// <summary>
        /// ����� ��������
        /// </summary>
        [SerializeField] private float m_EvadeRayLength;

        /// <summary>
        /// ������ �� ���� �������
        /// </summary>
        private SpaceShip m_SpaceShip;

        /// <summary>
        /// ����� ����������
        /// </summary>
        private Vector3 m_MovePosition;

        /// <summary>
        /// ����
        /// </summary>
        private Destructible m_SelectedTarget;

        private Timer testTimer;

        #region Unity Events

        private void Start()
        {
            testTimer = new Timer(3);
        }

        private void Update()
        {
            testTimer.RemoveTime(Time.deltaTime);

            if (testTimer.IsFinished)
            {
                Debug.Log("������!");

                testTimer.Start(3);
            }
        }

        #endregion
    }
}