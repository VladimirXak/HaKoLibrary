using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HakoLibrary.Common
{
    public static class Extension
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;

            while (n > 1)
            {
                n--;

                int k = Random.Range(0, n);

                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static T GetRandom<T>(this IList<T> list)
        {
            if (list == null || list.Count == 0)
                throw new System.Exception("IList is null or empty");

            return list[Random.Range(0, list.Count)];
        }

        public static void SetX(this Transform transform, float value)
        {
            Vector3 position = transform.position;
            transform.position = new Vector3(value, position.y, position.z);
        }

        public static void SetY(this Transform transform, float value)
        {
            Vector3 position = transform.position;
            transform.position = new Vector3(position.x, value, position.z);
        }

        public static void SetZ(this Transform transform, float value)
        {
            Vector3 position = transform.position;
            transform.position = new Vector3(position.x, position.y, value);
        }

        public static void SetLocalX(this Transform transform, float value)
        {
            Vector3 position = transform.localPosition;
            transform.localPosition = new Vector3(value, position.y, position.z);
        }

        public static void SetLocalY(this Transform transform, float value)
        {
            Vector3 position = transform.localPosition;
            transform.localPosition = new Vector3(position.x, value, position.z);
        }

        public static void SetLocalZ(this Transform transform, float value)
        {
            Vector3 position = transform.localPosition;
            transform.localPosition = new Vector3(position.x, position.y, value);
        }

        public static void SetAlpha(this Graphic graphic, float alpha)
        {
            var color = graphic.color;
            graphic.color = new Color(color.r, color.g, color.b, alpha);
        }
    }
}
