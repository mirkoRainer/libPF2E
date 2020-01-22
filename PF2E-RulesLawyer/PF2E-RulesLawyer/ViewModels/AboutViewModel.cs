using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PF2E_RulesLawyer.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://garykrause.dev"));
        }

        public ICommand OpenWebCommand { get; }
    }
}