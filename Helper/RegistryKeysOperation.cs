using Microsoft.Win32;

namespace RegistryEditor.Helper
{
    public enum RegistryState
    {
        Enabled,
        Disabled,
        None
    }
    public static class RegistryKeysOperation
    {


        public static string[] GetSubKeys(string path)
        {
            using (var kr = Registry.LocalMachine.OpenSubKey(path))
            {
                return kr != null ? kr.GetSubKeyNames() : new string[] { };
            }
        }

        public static RegistryState GetValue(string path)
        {
            using (var kr = Registry.LocalMachine.OpenSubKey(path))
            {
                if (kr == null)
                    return RegistryState.None;

                var obj = kr.GetValue(Constants.RegistryAttributeStateIdentifier);
                if (obj == null)
                {
                    return RegistryState.None;
                }
                else
                {
                    return obj.ToString() == Constants.RegistryStateEnabled.ToString() ? RegistryState.Enabled : RegistryState.Disabled;
                }
            }
        }

        public static bool SetRegistryValue(string path, bool value)
        {
            using (var key = Registry.LocalMachine.OpenSubKey(path, true))
            {
                if (key == null) return false;
                if (key.GetValue(Constants.RegistryAttributeStateIdentifier) == null) return false;
                key.SetValue(Constants.RegistryAttributeStateIdentifier, value ? Constants.RegistryStateEnabled : Constants.RegistryStateDisabled);
                return true;
            }
        }

        public static void SetLogParameters(bool isEnabled)
        {
            using (var key = Registry.LocalMachine.OpenSubKey(Constants.RootRegistryPath, true))
            {
                if (key == null) return;
                if (key.GetValue(Constants.RegistryAttributeMaxDurationLimitMins) != null)
                    key.SetValue(Constants.RegistryAttributeMaxDurationLimitMins,
                        isEnabled ? Constants.RegistryAttributeMaxDurationLimitMinsEnabledValue :
                            Constants.RegistryAttributeMaxDurationLimitMinsDisabledValue);
                if (key.GetValue(Constants.RegistryAttributeMaxKiloBytesInLogFiles) != null)
                    key.SetValue(Constants.RegistryAttributeMaxKiloBytesInLogFiles,
                        isEnabled ? Constants.RegistryAttributeMaxKiloBytesInLogFilesEnabledValue :
                            Constants.RegistryAttributeMaxKiloBytesInLogFilesDisabledValue);
                if (key.GetValue(Constants.RegistryAttributeNumBufferEntries) != null)
                    key.SetValue(Constants.RegistryAttributeNumBufferEntries,
                        isEnabled ? Constants.RegistryAttributeNumBufferEntriesEnabledValue :
                            Constants.RegistryAttributeNumBufferEntriesDisabledValue);
            }
        }

        public static string GetLogFilePath()
        {
            using (var key = Registry.LocalMachine.OpenSubKey(Constants.RootRegistryPath, true))
            {
                if (key == null) return string.Empty;
                var path = key.GetValue(Constants.RegistryAttributeLogFilePath).ToString();
                return path == null ? string.Empty : path;
            }
        }
    }
}