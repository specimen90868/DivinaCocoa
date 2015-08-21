using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

using SlideView.Library;
using Windows.Phone.UI.Input;
using Windows.ApplicationModel.Contacts;
using Windows.UI.Popups;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=391641

namespace appDivinaCocoa
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        /// <summary>
        /// Se invoca cuando esta página se va a mostrar en un objeto Frame.
        /// </summary>
        /// <param name="e">Datos de evento que describen cómo se llegó a esta página.
        /// Este parámetro se usa normalmente para configurar la página.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Preparar la página que se va a mostrar aquí.

            // TODO: Si la aplicación contiene varias páginas, asegúrese de
            // controlar el botón para retroceder del hardware registrándose en el
            // evento Windows.Phone.UI.Input.HardwareButtons.BackPressed.
            // Si usa NavigationHelper, que se proporciona en algunas plantillas,
            // el evento se controla automáticamente.
        }

        void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame != null && rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
                e.Handled = true;
            }
        }

        private void lblLocalizame_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame a = Window.Current.Content as Frame;
            a.Navigate(typeof(Localizame), a);
        }

        private void lblLlamame_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Windows.ApplicationModel.Calls.PhoneCallManager.ShowPhoneCallUI("4777719329", "Divina Cocoa");
        }

        private void lblGaleria_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame a = Window.Current.Content as Frame;
            a.Navigate(typeof(Galeria), a);
        }

        private void lblMenu_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame a = Window.Current.Content as Frame;
            a.Navigate(typeof(Menu), a);
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame a = Window.Current.Content as Frame;
            a.Navigate(typeof(MainPage), a);
        }

        private void lblCorreo_Tapped(object sender, TappedRoutedEventArgs e)
        {
            CrearCorreo();
        }

        private async void CrearCorreo()
        {
            var Contactos = new Windows.ApplicationModel.Contacts.ContactPicker();
            Contactos.DesiredFieldsWithContactFieldType.Add(ContactFieldType.Email);
            Contact Direcciones = await Contactos.PickContactAsync();
            if (Direcciones != null)
            {
                this.DatosdelContactoCorreo(Direcciones.Emails);
            }
            else
            {
                var dialog = new MessageDialog("Usuario no Encontrado");
                await dialog.ShowAsync();
            }
        }

        private async void DatosdelContactoCorreo<T>(IList<T> campos)
        {
            if (campos[0].GetType() == typeof(ContactEmail))
            {
                foreach (ContactEmail Email in campos as IList<ContactEmail>)
                {
                    var MensajeCorreo = new Windows.ApplicationModel.Email.EmailMessage();
                    MensajeCorreo.Body = "";
                    MensajeCorreo.Subject = "Saludos Divina Cocoa!!!";
                    var ContactoCorreo = new Windows.ApplicationModel.Email.EmailRecipient("fabricio.vilchis@it-esupport.com.mx");
                    MensajeCorreo.To.Add(ContactoCorreo);
                    await Windows.ApplicationModel.Email.EmailManager.ShowComposeNewEmailAsync(MensajeCorreo);
                    break;
                }
            }
        }
    }
}
