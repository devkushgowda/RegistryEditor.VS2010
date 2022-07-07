using RegistryEditor.Helper;

namespace RegistryEditor
{
    public static class Constants
    {

        /// <summary>
        /// Root registry path.
        /// </summary>
        public static string RootRegistryPath
        {
            get { return ConfigurationHelper.Configuration.RootRegistryPath; }
        }

        public const string RegistryAttributeStateIdentifier = "All";
        public const int RegistryStateEnabled = 1;
        public const int RegistryStateDisabled = 0;

        public const string RegistryAttributeLogFilePath = "LogFilePath";

        public const string RegistryAttributeMaxDurationLimitMins = "MaxDurationLimitMins";
        public const int RegistryAttributeMaxDurationLimitMinsEnabledValue = 1000;
        public const int RegistryAttributeMaxDurationLimitMinsDisabledValue = 0;

        public const string RegistryAttributeMaxKiloBytesInLogFiles = "MaxKiloBytesInLogFiles";
        public const int RegistryAttributeMaxKiloBytesInLogFilesEnabledValue = 2000;
        public const int RegistryAttributeMaxKiloBytesInLogFilesDisabledValue = 0;

        public const string RegistryAttributeNumBufferEntries = "NumBufferEntries";
        public const int RegistryAttributeNumBufferEntriesEnabledValue = 3000;
        public const int RegistryAttributeNumBufferEntriesDisabledValue = 0;


        public const string DatabaseWarningMessage = "When you select Database the wafer scan will take more time. Do you still want to enable the setting?";
        public const string ClearAllWarningMessage = "You are going to clear all the registry values in current window, would you like to proceed?";
        public const string GroupRegistryAlreadyExistsMessage = "This group registry with name '{0}' already exists, try again with different name.";
        public const string BackupCompletedMessage = "Would you like to browse the backup location?";
        public const string GroupRegistryDeleteConfirmationMessage = "Registry group '{0}' will be deleted permanently, would you like to proceed?";
        public const string InformationTitle = "Information";
        public const string WarningTitle = "Warning!";
        public const string AddNewGroupTitle = "Add new group";
        public const string NewGroupTitle = "Rename group";
        public const string LogFileFilter = "*.log|*.txt";
        public const string BackupCompletedTitle = "Backup completed.";
        /// <summary>
        /// Add multiple comma separated values, Which will check with ending value of registry.
        /// </summary>
        public const string CriticalKeysForWarning = "database";

        /// <summary>
        /// {0} - Application name.
        /// {1} - Root registry key.
        /// </summary>
        public const string ApplicationName = "SP1 Log Collector";
        public const string MainWindowTitleFormat = ApplicationName + " (Root: {0})";
        public const string RegistryPickerTitleFormat = "RegistryPicker ({0})";
    }
}
