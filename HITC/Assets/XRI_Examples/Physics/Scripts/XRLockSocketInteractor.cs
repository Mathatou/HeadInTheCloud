using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

namespace UnityEngine.XR.Content.Interaction
{
    /// <summary>
    /// Socket interactor that only selects and hovers interactables with a keychain component containing specific keys.
    /// When a valid key is inserted, automatically unlocks the linked Door.
    /// </summary>
    public class XRLockSocketInteractor : XRSocketInteractor
    {
        [Space]
        [SerializeField]
        [Tooltip("The required keys to interact with this socket.")]
        Lock m_Lock;

        [SerializeField]
        [Tooltip("La porte à déverrouiller quand la clé correcte est insérée.")]
        Door m_LinkedDoor;

        /// <summary>
        /// The required keys to interact with this socket.
        /// </summary>
        public Lock keychainLock
        {
            get => m_Lock;
            set => m_Lock = value;
        }

        /// <summary>
        /// La porte liée à ce socket de serrure.
        /// </summary>
        public Door linkedDoor
        {
            get => m_LinkedDoor;
            set => m_LinkedDoor = value;
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            selectEntered.AddListener(OnKeyInserted);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            selectEntered.RemoveListener(OnKeyInserted);
        }

        void OnKeyInserted(SelectEnterEventArgs args)
        {
            if (m_LinkedDoor != null)
                m_LinkedDoor.UnlockDoor();
        }

        /// <inheritdoc />
        public override bool CanHover(IXRHoverInteractable interactable)
        {
            if (!base.CanHover(interactable))
                return false;

            var keyChain = interactable.transform.GetComponent<IKeychain>();
            return m_Lock.CanUnlock(keyChain);
        }

        /// <inheritdoc />
        public override bool CanSelect(IXRSelectInteractable interactable)
        {
            if (!base.CanSelect(interactable))
                return false;

            var keyChain = interactable.transform.GetComponent<IKeychain>();
            return m_Lock.CanUnlock(keyChain);
        }
    }
}
