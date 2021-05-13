using System;
using TMPro;
using UnityEngine;

namespace HakoLibrary.LocalizationSpace
{
    public class EditableLocalizationTmp : MonoBehaviour, ILocalizationItem
    {
        [SerializeField] private string _keyLocalization;

        public event Action OnChangeLocaliazation;

        private TextMeshProUGUI _tmp;
        private TextMeshProUGUI Tmp
        {
            get
            {
                if (_tmp == null)
                    _tmp = GetComponent<TextMeshProUGUI>();

                return _tmp;
            }
        }

        private string _valueLocalization;

        public void ChangeLocalization()
        {
            if (Tmp == null)
                return;

            _valueLocalization = Singleton<Localization>.Instance.GetValue(_keyLocalization);
            Tmp.text = _valueLocalization;

            OnChangeLocaliazation?.Invoke();
        }

        public void AddValue(string value, PlacementType placementType)
        {
            if (placementType == PlacementType.Start)
                Tmp.text = $"{value} {_valueLocalization}";
            else
                Tmp.text = $"{_valueLocalization} {value}";
        }

        private void OnEnable()
        {
            ChangeLocalization();
        }

        public enum PlacementType
        {
            Start,
            End,
        }
    }
}
