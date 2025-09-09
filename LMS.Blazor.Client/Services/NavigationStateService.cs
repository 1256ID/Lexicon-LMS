public class NavigationStateService
{
    // --- COURSE ---
    public int? CurrentCourseId { get; private set; }
    public string? CurrentCourseName { get; private set; }

    public void SetCourse(int id, string name)
    {
        CurrentCourseId = id;
        CurrentCourseName = name;
        ClearModule();
        ClearActivity();
        NotifyStateChanged();
    }

    public void ClearCourse()
    {
        CurrentCourseId = null;
        CurrentCourseName = null;
        ClearModule();
        ClearActivity();
        NotifyStateChanged();
    }

    // --- MODULE ---
    public int? CurrentModuleId { get; private set; }
    public string? CurrentModuleName { get; private set; }

    public void SetModule(int id, string name)
    {
        CurrentModuleId = id;
        CurrentModuleName = name;
        ClearActivity();
        NotifyStateChanged();
    }

    public void ClearModule()
    {
        CurrentModuleId = null;
        CurrentModuleName = null;
        ClearActivity();
        NotifyStateChanged();
    }

    // --- ACTIVITY ---
    public int? CurrentActivityId { get; private set; }
    public string? CurrentActivityName { get; private set; }

    public void SetActivity(int moduleId, string moduleName, int id, string name)
    {
        CurrentModuleId = moduleId;
        CurrentModuleName = moduleName;
        CurrentActivityId = id;
        CurrentActivityName = name;
        NotifyStateChanged();
    }

    public void ClearActivity()
    {
        CurrentActivityId = null;
        CurrentActivityName = null;
        NotifyStateChanged();
    }

    // --- EVENTING ---
    public event Action? OnChange;
    private void NotifyStateChanged() => OnChange?.Invoke();
}
