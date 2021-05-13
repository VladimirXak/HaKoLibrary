using System;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;
using HakoLibrary.LocalizationSpace;

namespace HakoLibrary.Notification
{
    public class Notification : Singleton<Notification>
    {
        [SerializeField] private List<NotificationData> _notificationCollection;

        private const string _channelId = "generalNotifications";
        private const string _keyNotification = "hakoNotification";

        private Localization _localization;

        protected override void OnAwake()
        {
            Init();
        }

        public void Init()
        {
            _localization = Singleton<Localization>.Instance;

            var channel = new AndroidNotificationChannel()
            {
                Id = _channelId,
                Name = "General Channel",
                Importance = Importance.High,
                Description = "Generic notifications",
            };

            AndroidNotificationCenter.RegisterNotificationChannel(channel);

            RemoveSavedNotification();

            CreateNotification();
        }

        private void RemoveSavedNotification()
        {
            if (PlayerPrefs.HasKey(_keyNotification) == false)
                return;

            ListHolder<int> notificationIdCollection = JsonUtility.FromJson<ListHolder<int>>(PlayerPrefs.GetString(_keyNotification));

            foreach (var id in notificationIdCollection.Values)
                AndroidNotificationCenter.CancelNotification(id);
        }

        private void CreateNotification()
        {
            ListHolder<int> notificationIdCollection = new ListHolder<int>();

            foreach (var dateNotification in _notificationCollection)
                notificationIdCollection.Values.Add(CreateNotification(dateNotification));

            PlayerPrefs.SetString(_keyNotification, JsonUtility.ToJson(notificationIdCollection));
            PlayerPrefs.Save();
        }

        private int CreateNotification(NotificationData data)
        {
            var notification = new AndroidNotification();

            notification.Title = _localization.GetValue(data.KeyLocTitle);
            notification.Text = _localization.GetValue(data.KeyLocText);
            notification.FireTime = DateTime.Now.Add(data.TimeNotification.GetTimeSpan());

            var idNotification = AndroidNotificationCenter.SendNotification(notification, _channelId);

            return idNotification;
        }

        private void OnEnable()
        {
            AndroidNotificationCenter.OnNotificationReceived += AndroidNotificationCenter_OnNotificationReceived;
        }

        private void AndroidNotificationCenter_OnNotificationReceived(AndroidNotificationIntentData data)
        {
            AndroidNotificationCenter.CancelNotification(data.Id);
        }

        private void OnDisable()
        {
            AndroidNotificationCenter.OnNotificationReceived -= AndroidNotificationCenter_OnNotificationReceived;
        }
    }

    [Serializable]
    public struct NotificationData
    {
        public string KeyLocTitle;
        public string KeyLocText;
        public DateTimeNotificationData TimeNotification;
    }

    [Serializable]
    public struct DateTimeNotificationData
    {
        public int Days;
        public int Hours;
        public int Minutes;

        public TimeSpan GetTimeSpan()
        {
            return new TimeSpan(Days, Hours, Minutes, 0);
        }
    }
}
