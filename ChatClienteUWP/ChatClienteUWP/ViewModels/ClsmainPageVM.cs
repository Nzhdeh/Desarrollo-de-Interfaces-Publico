using ChatClienteUWP.Models;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace ChatClienteUWP.ViewModels
{
    public class ClsmainPageVM
    {
        public ObservableCollection<ClsMensage> Messages { get; set; } = new ObservableCollection<ClsMensage>();
        private HubConnection conn;
        private IHubProxy proxy;

        private void SignalR()
        {
            conn = new HubConnection("http://< Jump ;your-mobile-app>.azurewebsites.net");
            proxy = conn.CreateHubProxy("ChatHub");
            conn.Start();

            proxy.On<ClsMensage>("broadcastMessage", OnMessage);

        }

        public void Broadcast(ClsMensage msg)
        {
            proxy.Invoke("Send", msg);
        }

        private async void OnMessage(ClsMensage msg)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Messages.Add(msg);//no se hace nonifi porque es observabele collection
            });
        }
    }
}
