using Xamarin.Essentials;

namespace HealthCareApp.Helpers
{
    public static class Authentication
    {
        public static void  SetAuthenticate(bool value = true)
        {
            Preferences.Set("isAuthenticated", value);
        }

        public static bool IsAuthenticated()
        {
            return Preferences.Get("isAuthenticated", false);
        }
    }
}
