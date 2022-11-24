using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// ���������� �������� ����
    /// </summary>
    public class MainMenuController : SingletonBase<MainMenuController>
    {
        /// <summary>
        /// ������� �� ���������
        /// </summary>
        [SerializeField] private SpaceShip m_DefaultSpaceShip;

        /// <summary>
        /// ����� �������
        /// </summary>
        [SerializeField] private GameObject m_EpisodeSelection;

        /// <summary>
        /// ����� �������
        /// </summary>
        [SerializeField] private GameObject m_ShipSelection;

        /// <summary>
        /// ����� ����������
        /// </summary>
        [SerializeField] private GameObject m_TotalStatistics;

        private void Start()
        {
            LevelSequenceController.PlayerShip = m_DefaultSpaceShip;
        }

        /// <summary>
        /// ��� ������� �� "������ ����� ����"
        /// </summary>
        public void OnButtonStartNew()
        {
            m_EpisodeSelection.SetActive(true);
            gameObject.SetActive(false);
        }

        /// <summary>
        /// ��� ������� �� "����� �������"
        /// </summary>
        public void OnButtonSelectSpaceShip()
        {
            m_ShipSelection.SetActive(true);
            gameObject.SetActive(false);
        }

        /// <summary>
        /// ��� ������� �� "����� ����������"
        /// </summary>
        public void OnButtonTotalStatistics()
        {
            m_TotalStatistics.SetActive(true);
            gameObject.SetActive(false);
        }

        /// <summary>
        /// ��� ������� �� ������ "�����"
        /// </summary>
        public void OnButtonExit()
        {
            Application.Quit();
        }
    }
}