using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// ���������� �������� ����
    /// </summary>
    public class MainMenuController : MonoBehaviour
    {
        /// <summary>
        /// ����� �������
        /// </summary>
        [SerializeField] private GameObject m_EpisodeSelection;

        /// <summary>
        /// ��� ������� �� "������ ����� ����"
        /// </summary>
        public void OnButtonStartNew()
        {
            m_EpisodeSelection.SetActive(true);
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