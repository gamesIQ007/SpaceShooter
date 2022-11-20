using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{
    /// <summary>
    /// Контроллер окна выбора эпизодов
    /// </summary>
    public class EpisodeSelectionController : MonoBehaviour
    {
        /// <summary>
        /// Эпизод
        /// </summary>
        [SerializeField] private Episode m_Episode;

        /// <summary>
        /// Имя эпизода
        /// </summary>
        [SerializeField] private Text m_EpisodeNickname;

        /// <summary>
        /// Изображение-превью эпизода
        /// </summary>
        [SerializeField] private Image m_PreviewImage;

        private void Start()
        {
            if (m_EpisodeNickname != null)
            {
                m_EpisodeNickname.text = m_Episode.EpisodeName;
            }

            if (m_PreviewImage != null)
            {
                m_PreviewImage.sprite = m_Episode.PreviewImage;
            }
        }

        /// <summary>
        /// Нажатие на кнопку "Запуск эпизода"
        /// </summary>
        public void OnStartEpisodeButtonClicked()
        {
            LevelSequenceController.Instance.StartEpisode(m_Episode);
        }
    }
}