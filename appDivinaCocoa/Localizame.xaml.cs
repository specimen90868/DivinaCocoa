using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
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
    public sealed partial class Localizame : Page
    {
        public Localizame()
        {
            this.InitializeComponent();
            this.Loaded += Localizame_Loaded;
        }

        /// <summary>
        /// Se invoca cuando esta página se va a mostrar en un objeto Frame.
        /// </summary>
        /// <param name="e">Datos de evento que describen cómo se llegó a esta página.
        /// Este parámetro se usa normalmente para configurar la página.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Localizame_Loaded(object sender, RoutedEventArgs e)
        {
            MapIcon map;
            Mapa.ZoomLevel = 1;
            Mapa.Center = new Geopoint(new BasicGeoposition()
            {
                Latitude = 21.14363,
                Longitude = -101.69243
            });
            Mapa.ZoomLevel = 18;
            Mapa.LandmarksVisible = true;
            map = new MapIcon();
            map.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/marcador.png"));
            map.Location = new Geopoint(new BasicGeoposition()
            {
                Latitude = 21.14363,
                Longitude = -101.69243
            });
            map.NormalizedAnchorPoint = new Point(0.5, 1.0);
            map.Title = "Divina Cocoa";
            Mapa.MapElements.Add(map);
        }
    }
}
