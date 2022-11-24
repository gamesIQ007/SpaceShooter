using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{
    /// <summary>
    /// Контроллер окна общей статистики
    /// </summary>
    public class TotalStatisticsController : MonoBehaviour
    {
        /// <summary>
        /// Общее количество убийств
        /// </summary>
        [SerializeField] private Text m_TotalNumKills;

        /// <summary>
        /// Общее количество очков
        /// </summary>
        [SerializeField] private Text m_TotalScore;

        /// <summary>
        /// Общее время
        /// </summary>
        [SerializeField] private Text m_TotalTime;

        private void Start()
        {
            m_TotalNumKills.text = "Total Kills: " + LevelSequenceController.Instance.TotalStatistics.totalNumKills.ToString();
            m_TotalScore.text = "Total Score: " + LevelSequenceController.Instance.TotalStatistics.totalScore.ToString();
            m_TotalTime.text = "Total Time: " + LevelSequenceController.Instance.TotalStatistics.totalTime.ToString();
        }

        /// <summary>
        /// действие при нажатии на кнопку "Назад"
        /// </summary>
        public void OnButtonBackAction()
        {
            gameObject.SetActive(false);
            MainMenuController.Instance.gameObject.SetActive(true);
        }
    }
}