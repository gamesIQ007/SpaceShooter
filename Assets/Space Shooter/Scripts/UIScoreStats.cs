using UnityEngine;
using UnityEngine.UI;

// Почему-то в уроке сделано через Update, а не события, как учили ранее. Нафиг это, сделаю события.

namespace SpaceShooter
{
    /// <summary>
    /// UI очков
    /// </summary>
    public class UIScoreStats : MonoBehaviour
    {
        /// <summary>
        /// Элемент UI с очками
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