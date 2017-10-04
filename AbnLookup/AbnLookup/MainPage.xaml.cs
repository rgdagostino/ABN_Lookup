using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AbnLookup
{

    public partial class MainPage : ContentPage
    {
        
        Entry abnNumberText;
        Button searchButton;
        Label EntityNameLabel;
        Label AbnStatusLabel;
        Label EntityTypeLabel;
        Label GstLabel;
        Label MainBusinessLocationLabel;

        public MainPage()
        {

            //string s = "\\My Test\\\\";
            //int i = s.LastIndexOf(@"\\");



            this.Padding = new Thickness(20, Device.OnPlatform<Double>(40,20,20), 20, 200);
            StackLayout panel = new StackLayout();
            panel.Spacing = 15;

            panel.Children.Add(new Label()
            {
                Text = "Enter an ABN",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            });

            abnNumberText = new Entry();
            abnNumberText.Text = "55835730711";
            abnNumberText.Keyboard = Keyboard.Numeric;
            panel.Children.Add(abnNumberText);

            abnNumberText.TextChanged += AbnNumberText_TextChanged;

            searchButton = new Button();
            searchButton.Text = "Search";
            searchButton.IsEnabled = true;
            panel.Children.Add(searchButton);

            searchButton.Clicked += SearchButton_ClickedAsync;

            EntityNameLabel = new Label
            {
                Text = String.Empty,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };
            panel.Children.Add(EntityNameLabel);

            AbnStatusLabel = new Label
            {
                Text = String.Empty,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };
            panel.Children.Add(AbnStatusLabel);

            EntityTypeLabel = new Label
            {
                Text = String.Empty,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };
            panel.Children.Add(EntityTypeLabel);

            GstLabel = new Label
            {
                Text = String.Empty,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };
            panel.Children.Add(GstLabel);

            MainBusinessLocationLabel = new Label
            {
                Text = String.Empty,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };
            panel.Children.Add(MainBusinessLocationLabel);

            this.Content = panel;
        }

        private void AbnNumberText_TextChanged(object sender, TextChangedEventArgs e)
        {
            EntityNameLabel.Text = String.Empty;
            AbnStatusLabel.Text = String.Empty;
            EntityTypeLabel.Text = String.Empty;
            GstLabel.Text = String.Empty;
            MainBusinessLocationLabel.Text = String.Empty;
        }

        private async void SearchButton_ClickedAsync(object sender, EventArgs e)
        {
            try
            {
                var myEntity = await AbnManager.AbnSearchAsync(abnNumberText.Text);
                if (myEntity != null)
                {
                    EntityNameLabel.Text = myEntity.familyName + " , " + myEntity.givenName;
                    AbnStatusLabel.Text = "Active from " + myEntity.entityStatus.effectiveFrom;
                    EntityTypeLabel.Text = myEntity.entityDescription;
                    GstLabel.Text = "Registered from " + myEntity.goodsAndServicesTax.effectiveFrom;
                    MainBusinessLocationLabel.Text = myEntity.stateCode + " " + myEntity.postCode;
                }
            } catch {

                await DisplayAlert(
                    "Error",
                    "The ABN digited does not exist or your internet connection might not be available.",
                    "OK");
            }


        }

        private async void CallButton_Clicked(object sender, EventArgs e)
        {
            //if (await this.DisplayAlert(
            //    "Dial a number", 
            //    "Would you like to call " + translatedNumber + "?" , 
            //    "Yes", 
            //    "No"))
            //{
            //    var dialer = DependencyService.Get<IDialer>();
            //    if (dialer != null){
            //        await dialer.DialAsync(translatedNumber);
            //    }
            //}
        }

        private void TranslateButton_Clicked(object sender, EventArgs e)
        {
            

            //throw new NotImplementedException();
            //translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
            //if (!string.IsNullOrEmpty(translatedNumber))
            //{
            //    callButton.IsEnabled = true;
            //    callButton.Text = "Call";
            //}
            //else
            //{
            //    callButton.IsEnabled = false;
            //    callButton.Text = "Call";
            //}
        }

        
    }
}
