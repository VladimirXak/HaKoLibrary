namespace HakoLibrary.LocalizationSpace
{
    public class LocalizetionValue : ILocalizationItem
    {
        public string Value;

        private string _key;

        public LocalizetionValue(string key)
        {
            _key = key;

            ChangeLocalization();

            Singleton<Localization>.Instance.OnChangeLanguage += ChangeLocalization;
        }

        ~LocalizetionValue()
        {
            Singleton<Localization>.Instance.OnChangeLanguage -= ChangeLocalization;
        }

        public void ChangeLocalization()
        {
            Value = Singleton<Localization>.Instance.GetValue(_key);
        }
    }
}
