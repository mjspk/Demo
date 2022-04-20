using Xamarin.Essentials;
using Color = Xamarin.Forms.Color;

namespace Demo
{

    public static class Settings
    {
        public static void Reset()
        {
            Preferences.Clear();
        }
        public static Color PrimaryLight
        {
            get { return (Color)App.Current.Resources["PrimaryLight"]; }
            set { App.Current.Resources["PrimaryLight"] = value; }
        }
        public static Color Green
        {
            get { return (Color)App.Current.Resources["Green"]; }
            set { App.Current.Resources["Green"] = value; }
        }
        public static Color Blue
        {
            get { return (Color)App.Current.Resources["Blue"]; }
            set { App.Current.Resources["Blue"] = value; }
        }
        public static Color Purple
        {
            get { return (Color)App.Current.Resources["Purple"]; }
            set { App.Current.Resources["Purple"] = value; }
        }
        public static Color Secondary
        {
            get { return (Color)App.Current.Resources["Secondary"]; }
            set { App.Current.Resources["Secondary"] = value; }
        }
        public static Color PrimaryDark
        {
            get { return (Color)App.Current.Resources["PrimaryDark"]; }
            set { App.Current.Resources["PrimaryDark"] = value; }
        }
        public static Color PrimaryDarkLighten
        {
            get { return (Color)App.Current.Resources["PrimaryDarkLighten"]; }
            set { App.Current.Resources["PrimaryDarkLighten"] = value; }
        }
    }
}
