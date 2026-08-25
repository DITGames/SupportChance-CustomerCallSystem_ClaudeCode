using SupportChance_CustomerCallSystem_ClaudeCode.Services;

namespace SupportChance_CustomerCallSystem_ClaudeCode
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var persistence = new PersistenceService();
            var settingsService = new SettingsService();
            var manager = new CallQueueManager(persistence.Load());
            var settings = settingsService.Load();

            var (staffScreen, customerScreen) = ScreenAssignmentHelper.GetAssignment();

            var customerForm = new CustomerForm(manager);
            customerForm.ApplyBorderlessFullScreen(customerScreen);
            customerForm.Show();

            var staffForm = new StaffForm(manager, settingsService, settings, persistence, customerForm);
            staffForm.ApplyBorderlessFullScreen(staffScreen);
            staffForm.Show();

            Application.Run(new ApplicationContext(staffForm));
        }
    }
}