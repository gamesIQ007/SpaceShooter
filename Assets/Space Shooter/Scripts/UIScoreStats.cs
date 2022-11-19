using UnityEngine;
using UnityEngine.UI;

// ������-�� � ����� ������� ����� Update, � �� �������, ��� ����� �����. ����� ���, ������ �������.

namespace SpaceShooter
{
    /// <summary>
    /// UI �����
    /// </summary>
    public class UIScoreStats : MonoBehaviour
    {
        /// <summary>
        /// ������� UI � ������
        /// </summary>
        [SerializeField] private Text m_ScoreText;

        #region Unity Events

        private void Start()
        {
            Player.Instance.m_EventScoreChanged.AddListener(OnScoreChanged);
        }

        private void OnDestroy()
        {
            Player.Instance.m_EventScoreChanged.RemoveListener(OnScoreChanged);
        }

        #endregion

        private void OnScoreChanged()
        {
            m_ScoreText.text = "Score: " + Player.Instance.Score.ToString();
        }
    }
}