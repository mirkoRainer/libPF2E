using Xamarin.Forms;
using PF2E_RulesLawyer.Services;
using PF2E_RulesLawyer.Views;

namespace PF2E_RulesLawyer
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
