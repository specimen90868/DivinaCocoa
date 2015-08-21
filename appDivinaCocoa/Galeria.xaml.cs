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
    public sealed partial class Galeria : Page
    {
        string imgHost = "http://divinacocoa.com.mx/beta/";

        public Galeria()
        {
            this.InitializeComponent();
            getGaleriaJson();
        }

        /// <summary>
        /// Se invoca cuando esta página se va a mostrar en un objeto Frame.
        /// </summary>
        /// <param name="e">Datos de evento que describen cómo se llegó a esta página.
        /// Este parámetro se usa normalmente para configurar la página.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        async private void getGaleriaJson()
        {
            Uri ruta = new Uri("http://divinacocoa.com.mx/beta/api/gallery", UriKind.Absolute);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ruta);
            WebResponse response = await request.GetResponseAsync();
            Stream stream = response.GetResponseStream();

            string contenido = Comun.LecturaDatos(stream);
            contenido = "{results: " + contenido + "}";

            var obj = JsonConvert.DeserializeObject<ImageObject>(contenido);

            List<Imagen> _lstImagen = new List<Imagen>();
            for (int i = 0; i < obj.Results.Count; i++)
            {
                Imagen img = new Imagen();
                img.url = obj.Results[i].url;
                img.url = imgHost + img.url;
                _lstImagen.Add(img);
            }

            gvGaleria.ItemsSource = _lstImagen;
            var a = true;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Frame a = Window.Current.Content as Frame;
            a.Navigate(typeof(MainPage), a);
        }

        public class ImageObject
        {
            public List<Imagen> Results { get; set; }
        }

        public class Imagen
        {
            public string url { get; set; }
        }
    }
}
