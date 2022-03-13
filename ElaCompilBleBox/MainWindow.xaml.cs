using System;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WLightBoxApi.Contracts;
using WLightBoxApi.WebServices;

namespace ElaCompilBleBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event Handler for all radiobuttons. It is triggered when radiobutton is checked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Handle_Checked_Effect(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            //Sends Content of checked radiobutton to textblock. Im using this text block for effect id picking
            EffectModeToSet.Text = (string)rb.Content;
        }
        // handlers for durationMs sliders
        /// <summary>
        /// Event Handler for Color fade slider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorFadeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //logic for visual represenation of Color Fade value, posted in textblock
            int val = Convert.ToInt32(e.NewValue);
            string msg = String.Format("Current value: {0}", val);
            ColorFadeValue.Text = msg;

        }
        /// <summary>
        /// Event Handler for EffectFade slider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EffectFadeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //logic for visual represenation of Effect Fade value, posted in textblock
            int val = Convert.ToInt32(e.NewValue);
            string msg = String.Format("Current value: {0}", val);
            EffectFadeValue.Text = msg;
        }
        /// <summary>
        /// Event Handler for Effect Step slider.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EffectStepSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //logic for visual represenation of Effect step value, posted in textblock
            int val = Convert.ToInt32(e.NewValue);
            string msg = String.Format("Current value: {0}", val);
            EffectStepValue.Text = msg;
        }
        //handlers for RGB color setup sliders
        /// <summary>
        /// Event handler for Red color slider
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RedStepSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //logic for visual represenation of Color red value, posted in textblock
            int val = Convert.ToInt32(e.NewValue);
            string msg = String.Format("Current value: {0}", val);
            RedValue.Text = msg;

            RgbwWwCwUpdate();
        }
        
        /// <summary>
        /// Event handler for Green color slider
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GreenStepSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //logic for visual represenation of Color Green value, posted in textblock
            int val = Convert.ToInt32(e.NewValue);
            string msg = String.Format("Current value: {0}", val);
            GreenValue.Text = msg;

            RgbwWwCwUpdate();
        }

        /// <summary>
        /// Event handler for Blue color slider
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BlueStepSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //logic for visual represenation of Color Blue value, posted in textblock
            int val = Convert.ToInt32(e.NewValue);
            string msg = String.Format("Current value: {0}", val);
            BlueValue.Text = msg;
            
            RgbwWwCwUpdate();
        }

        private void WWSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //logic for visual represenation of WW value, posted in textblock
            int val = Convert.ToInt32(e.NewValue);
            string msg = String.Format("Current value: {0}", val);
            WWValue.Text = msg;
            
            RgbwWwCwUpdate();
        }

        private void CWSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //logic for visual represenation of CW value, posted in textblock
            int val = Convert.ToInt32(e.NewValue);
            string msg = String.Format("Current value: {0}", val);
            CWValue.Text = msg;
           
            RgbwWwCwUpdate();
        }

        private void RgbwWwCwUpdate()
        {
            //taking all rgb values and converts this from rgb string to hex string
            var redValue = Convert.ToInt32(this.RedStepSlider.Value);
            var greenValue = Convert.ToInt32(this.GreenStepSlider.Value);
            var blueValue = Convert.ToInt32(this.BlueStepSlider.Value);
            System.Drawing.Color myColor = System.Drawing.Color.FromArgb(redValue, greenValue, blueValue);
            string hex = myColor.R.ToString("X2") + myColor.G.ToString("X2") + myColor.B.ToString("X2");

            var wwValue = Convert.ToInt32(this.WWSlider.Value);
            var cwValue = Convert.ToInt32(this.CWSlider.Value);
            string light = wwValue.ToString("X2") + cwValue.ToString("X2");

            //posting complete rgb color value in hex to textblock
            SetColor.Text = $"{hex}{light}";

            //converting hex string to brush and changing background of corelated border for visual representation of new color
            var converter = new BrushConverter();
            var brush = (Brush)converter.ConvertFromString($"#{hex}");
            SetColorBox.Background = brush;
        }



        //Device Api communication
        /// <summary>
        /// Handler for Connect Button. Trying to get device status and state of lightning and post it to mainview related controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Connect_Click(object sender, RoutedEventArgs e)
        {
            //Creation of new httpclient and using it in GetInfo class together with ipAdress from related textbox
            HttpClient httpClient = HttpClientSetup.CreateHttpClient();
            string ipAdress = DeviceAdress.Text;
            GetInfo getInfo = new GetInfo(ipAdress, httpClient);
            try
            {
                //Connection to device status Api 
                DeviceResponse deviceStatus = await getInfo.GetInfoFromApi();
                //Posting device status data to related textblocks
                DeviceName.Text = deviceStatus.Device.DeviceName;
                ProductName.Text = deviceStatus.Device.Product;
                Hv.Text = deviceStatus.Device.Hv;
                Fv.Text = deviceStatus.Device.Fv;
                ActualDeviceAdress.Text = deviceStatus.Device.Ip;
            }
            catch(AggregateException err)
            {
                MessageBox.Show(err.Message, "Error");
            }
            catch (HttpRequestException err)
            {
                MessageBox.Show(err.Message, "Error");
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot connect to device", "Error");
            }

            //New GetRgbw class that is using previously created httpclient and ip adress
            GetRgbw getRgbw = new GetRgbw(ipAdress, httpClient);
            try
            {
                //Connection to State of Lightning Api
                RgbwResponse rgbwStatus = await getRgbw.GetRgbwFromApi();
                //Posting State of Lightning data to related textblocks
                UpdateStateOfLightning(rgbwStatus);
            }
            catch (AggregateException err)
            {
                MessageBox.Show(err.Message, "Error");
            }
            catch (HttpRequestException err)
            {
                MessageBox.Show(err.Message, "Error");
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot connect to device", "Error");
            }
        }

        /// <summary>
        /// Handler for Update Color Button. Posting new color settings to device api and getting back State of Lightning to post it in mainview controls.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void UpdateColor_Click(object sender, RoutedEventArgs e)
        {
            //Creation of new httpclient and using it in Post class together with ipAdress from related textbox
            HttpClient httpClient = HttpClientSetup.CreateHttpClient();
            string ipAdress = DeviceAdress.Text;
            PostRgbwChangeColor postRgbw = new PostRgbwChangeColor(ipAdress, httpClient, SetColor.Text, Convert.ToInt32(ColorFadeSlider.Value));
            try
            {
                //Connection to State of Lightning Api
                RgbwResponse rgbwStatus = await postRgbw.PostRgbwChangeColorToApi();
                //Posting State of Lightning data to related textblocks
                UpdateStateOfLightning(rgbwStatus);
            }
            catch(AggregateException err)
            {
                MessageBox.Show(err.Message, "Error");
            }
            catch (HttpRequestException err)
            {
                MessageBox.Show(err.Message, "Error");
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot connect to device", "Error");
            }
        }

        private async void UpdateEffect_Click(object sender, RoutedEventArgs e)
        {
            //Creation of new httpclient and using it in Post class together with ipAdress from related textbox
            HttpClient httpClient = HttpClientSetup.CreateHttpClient();
            string ipAdress = DeviceAdress.Text;
            PostRgbwChangeEffect postRgbw = new PostRgbwChangeEffect(ipAdress, httpClient, Convert.ToInt32(EffectFadeSlider.Value), Convert.ToInt32(EffectStepSlider.Value), Int32.Parse(this.EffectModeToSet.Text.Substring(0, 1)));
            try
            {
                //Connection to State of Lightning Api
                RgbwResponse rgbwStatus = await postRgbw.PostRgbwChangeEffectToApi();
                //Posting State of Lightning data to related textblocks
                UpdateStateOfLightning(rgbwStatus);
            }
            catch (AggregateException err)
            {
                MessageBox.Show(err.Message, "Error");
            }
            catch (HttpRequestException err)
            {
                MessageBox.Show(err.Message, "Error");
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot connect to device", "Error");
            }
        }

        private void UpdateStateOfLightning(RgbwResponse rgbwStatus)
        {
            ActualColorMode.Text = ColorModes[rgbwStatus.Rgbw.ColorMode];
            ActualEffectId.Text = ColorEffects[rgbwStatus.Rgbw.EffectID];
            ActualColorFade.Text = Convert.ToString(rgbwStatus.Rgbw.DurationsMs.ColorFade);
            ActualEffectFade.Text = Convert.ToString(rgbwStatus.Rgbw.DurationsMs.EffectFade);
            ActualEffectStep.Text = Convert.ToString(rgbwStatus.Rgbw.DurationsMs.EffectStep);
            ActualColor.Text = rgbwStatus.Rgbw.CurrentColor;

            //converting hex string to brush and changing background of corelated border for visual representation of current color
            var converter = new BrushConverter();
            string actualColor = rgbwStatus.Rgbw.CurrentColor.Substring(0, 6);

            try
            {
                var brush = (Brush)converter.ConvertFromString($"#{actualColor}");
                ActualColorBox.Background = brush;
            }

            catch (NotSupportedException)
            {
                MessageBox.Show("Provided color format is not supported", "Error");
            }
        }

        //some values that could be usefull later
        public string[] ColorModes = new string[]
        { 
            "OFF",
            "RGBW",
            "RGB",
            "MONO",
            "RGBorW",
            "CT",
            "CTx2",
            "RGBWW"
        };

        public string[] ColorEffects = new string[]
        {
            "OFF",
            "Fade",
            "RGB",
            "Police",
            "Relax",
            "Strobo",
            "Bell" 
        };

        public enum ColorModeEnum
        {
            RGBW = 1,
            RGB,
            MONO,
            RGBorW,
            CT,
            CTx2,
            RGBWW
        }

        public enum EffectModeEnum
        {
            OFF,
            Fade,
            RGB,
            Police,
            Relax,
            Strobo,
            Bell
        }
 
    }
}
