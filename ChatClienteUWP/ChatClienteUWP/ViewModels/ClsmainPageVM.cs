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
    public class ClsMainPageVM
    {
        public ObservableCollection<ClsMensage> listadoMensaje { get; set; } = new ObservableCollection<ClsMensage>();
        private HubConnection conn;
        private IHubProxy proxy;
        private ClsMensage mensaje;//nuestro mensaje al servidor 
        private ClsDelegateCommand command;
       

       public ClsMensage Mensaje { get; set; }
        public ClsDelegateCommand Command { get; set; }

        private void SignalR()
        {
            conn = new HubConnection("http://< Jump ;chatservernzhdeh.azurewebsites.net");
            proxy = conn.CreateHubProxy("ChatHub");
            conn.Start();

            proxy.On<String,String>("broadcastMessage", OnMessage);

        }

        public void Broadcast(ClsMensage msg)
        {
            proxy.Invoke("Send", msg.Nombre,msg.Mensage);
        }

        private async void OnMessage(String nombre,String mensaje)
        {
           
            await Windows.ApplicationModel.Core.CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                ClsMensage mensaje1 = new ClsMensage(nombre, mensaje);
                listadoMensaje.Add(mensaje1);//no se hace notificar porque es observabele collection
            });
        }
    }
}
