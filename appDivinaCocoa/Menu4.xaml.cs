using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkID=390556

namespace appDivinaCocoa
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Menu4 : Page
    {
        public Menu4()
        {
            this.InitializeComponent();
            this.Loaded += Menu4_Loaded;
        }

        /// <summary>
        /// Se invoca cuando esta página se va a mostrar en un objeto Frame.
        /// </summary>
        /// <param name="e">Datos de evento que describen cómo se llegó a esta página.
        /// Este parámetro se usa normalmente para configurar la página.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void Menu4_Loaded(object sender, RoutedEventArgs e)
        { 
            try{

                Uri ruta = new Uri("http://doniaelena.anabiosis.com.mx/menu.json", UriKind.Absolute);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ruta);
                WebResponse response = await request.GetResponseAsync();
                Stream stream = response.GetResponseStream();
                string contenido = Comun.LecturaDatos(stream);
                var obj = JsonConvert.DeserializeObject<RootObject>(contenido);

                List<AntojosSalados> lstAntojosSalados = new List<AntojosSalados>();
                for (int i = 0; i < obj.AntojosSalados.Count; i++)
                {
                    AntojosSalados aS = new AntojosSalados();
                    aS.title = obj.AntojosSalados[i].title.ToString();
                    aS.description = obj.AntojosSalados[i].description.ToString();
                    lstAntojosSalados.Add(aS);
                }

                GridView gvAntojosSalados = Comun.FindChildControl<GridView>(HubPrincipal, "gvAntojosSalados") as GridView;
                gvAntojosSalados.ItemsSource = lstAntojosSalados.ToList();

            }
            catch (Exception error)
            {
                Windows.UI.Popups.MessageDialog msg = new Windows.UI.Popups.MessageDialog(error.ToString());
                var resp = msg.ShowAsync();
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Frame a = Window.Current.Content as Frame;
            a.Navigate(typeof(MainPage), a);
        }
    }
}
