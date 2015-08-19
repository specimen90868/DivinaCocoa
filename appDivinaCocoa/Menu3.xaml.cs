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
    public sealed partial class Menu3 : Page
    {
        public Menu3()
        {
            this.InitializeComponent();
            this.Loaded += Menu3_Loaded;
        }

        /// <summary>
        /// Se invoca cuando esta página se va a mostrar en un objeto Frame.
        /// </summary>
        /// <param name="e">Datos de evento que describen cómo se llegó a esta página.
        /// Este parámetro se usa normalmente para configurar la página.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async void Menu3_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Uri ruta = new Uri("http://doniaelena.anabiosis.com.mx/menu.json", UriKind.Absolute);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ruta);
                WebResponse response = await request.GetResponseAsync();
                Stream stream = response.GetResponseStream();
                string contenido = Comun.LecturaDatos(stream);
                var obj = JsonConvert.DeserializeObject<RootObject>(contenido);

                List<ParaDesayunar> lstParaDesayunar = new List<ParaDesayunar>();
                for (int i = 0; i < obj.ParaDesayunar.Count; i++)
                {
                    ParaDesayunar pd = new ParaDesayunar();
                    pd.title = obj.ParaDesayunar[i].title.ToString();
                    pd.description = obj.ParaDesayunar[i].description.ToString();
                    lstParaDesayunar.Add(pd);
                }

                GridView gvParaDesayunar = Comun.FindChildControl<GridView>(HubPrincipal, "gvParaDesayunar") as GridView;
                gvParaDesayunar.ItemsSource = lstParaDesayunar.ToList();


                List<AntojosDulces> lstAntojosDulces = new List<AntojosDulces>();
                for (int i = 0; i < obj.AntojosDulces.Count; i++)
                {
                    AntojosDulces ad = new AntojosDulces();
                    ad.title = obj.AntojosDulces[i].title.ToString();
                    ad.description = obj.AntojosDulces[i].description.ToString();
                    lstAntojosDulces.Add(ad);
                }

                GridView gvAntojosDulces = Comun.FindChildControl<GridView>(HubPrincipal, "gvAntojosDulces") as GridView;
                gvAntojosDulces.ItemsSource = lstAntojosDulces.ToList();

            }
            catch (Exception error)
            {
                Windows.UI.Popups.MessageDialog msg = new Windows.UI.Popups.MessageDialog(error.ToString());
                var resp = msg.ShowAsync();
            }
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            Frame a = Window.Current.Content as Frame;
            a.Navigate(typeof(Menu4), a);
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Frame a = Window.Current.Content as Frame;
            a.Navigate(typeof(MainPage), a);
        }
    }
}
