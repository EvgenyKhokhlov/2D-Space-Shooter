using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Base class of all interactive game objects on the scene
    /// </summary>
    public abstract class Entity : MonoBehaviour
    {
        /// <summary>
        /// object name of user
        /// </summary>

        [SerializeField] private string m_Nickname;
        public string Nickname => m_Nickname;
    }
}
