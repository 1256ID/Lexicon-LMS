namespace LMS.Blazor.Client.Services
{
    public class NavigationStateService
    {
        public int? CurrentModuleId { get; private set; }
        public string? CurrentModuleName { get; private set; }

        public int? CurrentActivityId { get; private set; }
        public string? CurrentActivityName { get; private set; }


        public event Action? OnChange;

        public void SetModule(int moduleId, string moduleName)
        {
            CurrentModuleId = moduleId;
            CurrentModuleName = moduleName;
            CurrentActivityId = null;
            CurrentActivityName = null;

            NotifyStateChanged();
        }

        public void SetActivity(int moduleId, string moduleName, int activityId, string activityName)
        {
            CurrentModuleId = moduleId;
            CurrentModuleName = moduleName;
            CurrentActivityId = activityId;
            CurrentActivityName = activityName;

            NotifyStateChanged();
        }

        public void ClearModule()
        {
            CurrentModuleId = null;
            CurrentModuleName = null;
            CurrentActivityId = null;
            CurrentActivityName = null;
            NotifyStateChanged();
        }

        public void ClearActivity()
        {
            CurrentActivityId = null;
            CurrentActivityName = null;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
