using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{
    /// <summary>
    /// ���������� ���� ������ ��������
    /// </summary>
    public class EpisodeSelectionController : MonoBehaviour
    {
        /// <summary>
        /// ������
        /// </summary>
        [SerializeField] private Episode m_Episode;

        /// <summary>
        /// ��� �������
        /// </summary>
        [SerializeField] private Text m_EpisodeNickname;

        /// <summary>
        /// �����������-������ �������
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
        /// ������� �� ������ "������ �������"
        /// </summary>
        public void OnStartEpisodeButtonClicked()
        {
            LevelSequenceController.Instance.StartEpisode(m_Episode);
        }
    }
}