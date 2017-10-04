using System.Threading.Tasks;
using Windows.Foundation.Metadata;
using AbnLookup.UWP;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhoneDialer))]

namespace AbnLookup.UWP
{
    public class PhoneDialer : IDialer
    {
        public Task<bool> DialAsync(string number)
        {
            if (ApiInformation.IsApiContractPresent("Windows.ApplicationModel.Calls.CallsPhoneContract", 1,0))
            {
                throw new System.NotImplementedException();
                // Windows.ApplicationModel.Calls.PhoneCallManager.ShowPhoneCallUI(number, "Phoneword");
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }
    }
}