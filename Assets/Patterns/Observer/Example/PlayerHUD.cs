using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script uses the Observer pattern to find out when our
/// target has been damaged, and when it has died. We notify the HUD
/// when target is damaged, and we lose the target when it has died.
/// Note that the HUD doesn't know anything about the target, which is
/// also listening to the Health events! As long as we give this observer
/// a subject, it won't be coupled to other observers
/// </summary>
namespace Examples.Observer
{
    public class PlayerHUD : MonoBehaviour
    {
        [SerializeField] Health _startingObjectWithHealth = null;
        [SerializeField] Text _textPopupUI = null;
        [SerializeField] string _hitText = "Hit!";
        [SerializeField] float _textPopupDuration = 1;

        Health _healthOnTarget = null;
        Coroutine _popupRoutine = null;

        private void Start()
        {
            AcquireTarget(_startingObjectWithHealth);
        }

        public void AcquireTarget(Health healthOnTarget)
        {
            _healthOnTarget = healthOnTarget;
            // notify when target is damaged
            _healthOnTarget.Damaged += OnTargetDamaged;
            _healthOnTarget.Killed += OnTargetKilled;
        }

        public void LoseTarget()
        {
            // no longer watch target
            _healthOnTarget.Damaged -= OnTargetDamaged;
            _healthOnTarget.Killed -= OnTargetKilled;

            _healthOnTarget = null;
        }

        void OnTargetDamaged(int damaged)
        {
            string hitText = _hitText + " " + damaged.ToString();

            if (_popupRoutine != null)
                StopCoroutine(_popupRoutine);
            _popupRoutine = StartCoroutine(TextPopup(hitText));
        }

        IEnumerator TextPopup(string textToShow)
        {
            _textPopupUI.text = textToShow;
            yield return new WaitForSeconds(_textPopupDuration);
            _textPopupUI.text = string.Empty;
        }

        void OnTargetKilled()
        {
            LoseTarget();
        }
    }
}

