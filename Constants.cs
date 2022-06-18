namespace RegistryEditor
{
    public static class Constants
    {

        /// <summary>
        /// Root registry path.
        /// </summary>
        public const string RootRegistryPath = "SOFTWARE\\Vijay\\DemoPro\\Log";

        public const string RegistryAttributeStateIdentifier = "All";
        public const int RegistryStateEnabled = 1;
        public const int RegistryStateDisabled = 0;

        public const string RegistryAttributeMaxDurationLimitMins = "MaxDurationLimitMins";
        public const int RegistryAttributeMaxDurationLimitMinsEnabledValue = 1000;
        public const int RegistryAttributeMaxDurationLimitMinsDisabledValue = 0;

        public const string RegistryAttributeMaxKiloBytesInLogFiles = "MaxKiloBytesInLogFiles";
        public const int RegistryAttributeMaxKiloBytesInLogFilesEnabledValue = 2000;
        public const int RegistryAttributeMaxKiloBytesInLogFilesDisabledValue = 0;

        public const string RegistryAttributeNumBufferEntries = "NumBufferEntries";
        public const int RegistryAttributeNumBufferEntriesEnabledValue = 3000;
        public const int RegistryAttributeNumBufferEntriesDisabledValue = 0;


        public const string DatabaseWarningMessage = "You are going to modify Database registry/group registry, would you like to proceed?";
        public const string ClearAllWarningMessage = "You are going to clear all the registry values in current window, would you like to proceed?";
        public const string GroupRegistryAlreadyExistsMessage = "This group registry with name '{0}' already exists, try again with different name.";
        public const string RegistryAlreadyMappedMessage = "Registry '{0}' already mapped to this group.";
        public const string GroupRegistryDeleteConfirmationMessage = "Registry group '{0}' will be deleted permanently, would you like to proceed?";
        public const string InformationTitle = "Information";
        public const string WarningTitle = "Warning!";
        public const string AddNewGroupTitle = "Add new group";
        public const string NewGroupTitle = "Rename group";

        /// <summary>
        /// Add multiple comma separated values, Which will check with ending value of registry.
        /// </summary>
        public const string CriticalKeysForWarning = "database";

        /// <summary>
        /// {0} - Application name.
        /// {1} - Root registry key.
        /// </summary>
        public const string MainWindowTitleFormat = "{0}(Root: {1})";
    }
}
