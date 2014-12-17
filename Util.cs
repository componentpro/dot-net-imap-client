using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ImapClient
{
    public static class Util
    {
        /// <summary>
        /// Saves a key value pair to the registry.
        /// </summary>
        /// <param name="keyName">The key name.</param>
        /// <param name="value">The value.</param>
        public static void SaveProperty(string keyName, object value)
        {
            try
            {
                RegistryKey Key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\ComponentPro\\Samples\\ImapClient");
                Key.SetValue(keyName, value);
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// Gets the saved value from the Registry.
        /// </summary>
        /// <param name="keyName">The key name to get value.</param>
        /// <param name="defaultValue">The default value that is used when the key name not found.</param>
        /// <returns>The value.</returns>
        public static object GetProperty(string keyName, object defaultValue)
        {
            try
            {
                RegistryKey Key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\ComponentPro\\Samples\\ImapClient");
                return Key.GetValue(keyName, defaultValue);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static object GetProperty(string keyName)
        {
            return GetProperty(keyName, null);
        }

        public static int GetIntProperty(string keyName, int defaultValue)
        {
            try
            {
                RegistryKey Key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\ComponentPro\\Samples\\ImapClient");
                return int.Parse(Key.GetValue(keyName, defaultValue).ToString());
            }
            catch
            {
                return defaultValue;
            }
        }

        public static long GetLongProperty(string keyName, long defaultValue)
        {
            try
            {
                RegistryKey Key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\ComponentPro\\Samples\\ImapClient");
                return long.Parse(Key.GetValue(keyName, defaultValue).ToString());
            }
            catch
            {
                return defaultValue;
            }
        }

        public static void ShowError(Exception exc)
        {
            string str;

            if (exc.InnerException != null)
                str = string.Format(null, "An error occurred: {0}", exc.InnerException.Message);
            else
                str = string.Format(null, "An error occurred: {0}", exc.Message);

            MessageBox.Show(str, "Error");
        }

        public static void ShowError(Exception exc, string msg)
        {
            string str;

            if (exc.InnerException != null)
                str = string.Format(null, "{0}. An error occurred: {1}", msg, exc.InnerException.Message);
            else
                str = string.Format(null, "{0}. An error occurred: {1}", msg, exc.Message);

            MessageBox.Show(str, "Error");
        }

        const int MF_BYCOMMAND = 0;
        const int MF_ENABLED = 0x00000000;
        const int MF_GRAYED = 0x00000001;

        [DllImport("User32")]
        private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("User32")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("User32")]
        private static extern bool EnableMenuItem(IntPtr hMenu, IntPtr hMenuItem, int nEnable);

        [DllImport("User32")]
        private static extern IntPtr GetMenuItemID(IntPtr hMenu, int nPos);

        [DllImport("User32")]
        private static extern int GetMenuItemCount(IntPtr hWnd);

        static readonly Dictionary<string, bool> _map = new Dictionary<string, bool>();

        /// <summary>
        /// Disables Close(X) button.
        /// </summary>
        /// <param name="form">Form object.</param>
        /// <param name="enable">Indicates whether the close button is enabled.</param>
        static void EnableCloseButtonInt(Form form, bool enable)
        {
            IntPtr hMenu = GetSystemMenu(form.Handle, false);
            int menuItemCount = GetMenuItemCount(hMenu);
            IntPtr hItem = GetMenuItemID(hMenu, menuItemCount - 1);
            EnableMenuItem(hMenu, hItem, MF_BYCOMMAND | (enable ? MF_ENABLED : MF_GRAYED));
        }

        /// <summary>
        /// Disables Close(X) button.
        /// </summary>
        /// <param name="form">Form object.</param>
        /// <param name="enable">Indicates whether the close button is enabled.</param>
        public static void EnableCloseButton(Form form, bool enable)
        {
            EnableCloseButtonInt(form, enable);

            if (!_map.ContainsKey(form.Name))
            {
                lock (_map)
                {
                    _map.Add(form.Name, enable);
                    form.Resize += form_Resize;
                }
            }
            else
                _map[form.Name] = enable;
        }

        static void form_Resize(object sender, EventArgs e)
        {
            Form form = (Form)sender;

            if (!_map[form.Name])
                EnableCloseButtonInt(form, false);
        }

        /// <summary>
        /// Returns a formatted file size in bytes, kbytes, or mbytes.
        /// </summary>
        /// <param name="size">The input file size.</param>
        /// <returns>The formatted file size.</returns>
        public static string FormatSize(long size)
        {
            if (size < 1024)
                return size + " B";
            else if (size < 1024 * 1024)
                return string.Format("{0:#.#} K", size / 1024.0f);
            else if (size < 1024 * 1024 * 1024)
                return string.Format("{0:#.#} M", size / 1024.0f / 1024.0f);
            /*else if (size < 1024 * 1024 * 1024 * 1024)
                return string.Format("{0:#.#} G", size / 1024 / 1024 / 1024);
            else
                return string.Format("{0:#.#} T", size / 1024 / 1024 / 1024 / 1024);*/

            return size.ToString();
        }

        public static void PopulateEnum(Type enumType, ComboBox ddl)
        {
            Array arr = Enum.GetValues(enumType);

            foreach (object item in arr)
            {
                ddl.Items.Add(item);
            }
        }
    }
}