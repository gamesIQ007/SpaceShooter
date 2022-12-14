using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// ????? ??? ???????? ?????? ?? ?????
    /// </summary>
    public class CameraController : MonoBehaviour
    {
        /// <summary>
        /// ??????
        /// </summary>
        [SerializeField] private Camera m_Camera;

        /// <summary>
        /// ???? ????????
        /// </summary>
        [SerializeField] private Transform m_Target;

        /// <summary>
        /// ???????? ????????
        /// </summary>
        [SerializeField] private float m_InterpolationLinear;

        /// <summary>
        /// ???????? ????????
        /// </summary>
        [SerializeField] private float m_InterpolationAngular;

        /// <summary>
        /// ?????? ?????? ?? ??? Z
        /// </summary>
        [SerializeField] private float m_CameraZOffset;

        /// <summary>
        /// ???????? ?????? ?????? ?? ????
        /// </summary>
        [SerializeField] private float m_ForwardOffset;

        #region Unity Events

        private void FixedUpdate()
        {
            if (m_Camera == null || m_Target == null) return;

            Vector2 camPos = m_Camera.transform.position;
            Vector2 targetPos = m_Target.position + m_Target.transform.up * m_ForwardOffset;

            Vector2 newCamPos = Vector2.Lerp(camPos, targetPos, m_InterpolationLinear * Time.deltaTime);

            m_Camera.transform.position = new Vector3(newCamPos.x, newCamPos.y, m_CameraZOffset);

            if (m_InterpolationAngular > 0)
            {
                m_Camera.transform.rotation = Quaternion.Slerp(m_Camera.transform.rotation, m_Target.rotation, m_InterpolationAngular * Time.deltaTime);
            }
        }

        #endregion

        #region Public API

        /// <summary>
        /// ?????????? ????? ???? ???????????? ???????
        /// </summary>
        /// <param name="newTarget"></param>
        public void SetTarget(Transform newTarget)
        {
            m_Target = newTarget;
        }

        #endregion
    }
}