namespace SupportChance_CustomerCallSystem_ClaudeCode.Services
{
    public static class ScreenAssignmentHelper
    {
        public static (Screen Staff, Screen Customer) GetAssignment()
        {
            var primary = Screen.PrimaryScreen ?? Screen.AllScreens[0];
            var secondary = Screen.AllScreens.FirstOrDefault(s => !s.Equals(primary));
            return (primary, secondary ?? primary);
        }

        public static void ApplyBorderlessFullScreen(this Form form, Screen screen)
        {
            form.FormBorderStyle = FormBorderStyle.None;
            form.StartPosition = FormStartPosition.Manual;
            form.WindowState = FormWindowState.Normal;
            form.Bounds = screen.Bounds;
        }
    }
}
