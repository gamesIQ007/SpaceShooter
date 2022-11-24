using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{
    /// <summary>
    /// ���������� ���� ����� ����������
    /// </summary>
    public class TotalStatisticsController : MonoBehaviour
    {
        /// <summary>
        /// ����� ���������� �������
        /// </summary>
        [SerializeField] private Text m_TotalNumKills;

        /// <summary>
        /// ����� ���������� �����
        /// </summary>
        [SerializeField] private Text m_TotalScore;

        /// <summary>
        /// ����� �����
        /// </summary>
        [SerializeField] private Text m_TotalTime;

        private void Start()
        {
            m_TotalNumKills.text = "Total Kills: " + LevelSequenceController.Instance.TotalStatistics.totalNumKills.ToString();
            m_TotalScore.text = "Total Score: " + LevelSequenceController.Instance.TotalStatistics.totalScore.ToString();
            m_TotalTime.text = "Total Time: " + LevelSequenceController.Instance.TotalStatistics.totalTime.ToString();
        }

        /// <summary>
        /// �������� ��� ������� �� ������ "�����"
        /// </summary>
        public void OnButtonBackAction()
        {
            gameObject.SetActive(false);
            MainMenuController.Instance.gameObject.SetActive(true);
        }
    }
}