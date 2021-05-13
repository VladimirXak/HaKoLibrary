using UnityEngine;
using TMPro;

namespace HakoLibrary.LocalizationSpace
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class LocalizationTmp : MonoBehaviour, ILocalizationItem
    {
        [SerializeField] private string _keyLocalization;

        private TextMeshProUGUI _tmp;

        private void Awake()
        {
            _tmp = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            ChangeLocalization();
        }

        public void ChangeLocalization()
        {
            if (_tmp != null)
                _tmp.text = Singleton<Localization>.Instance.GetValue(_keyLocalization);
        }

        public void SetKeyLocalization(string key)
        {
            _keyLocalization = key;
            ChangeLocalization();
        }
    }
}
