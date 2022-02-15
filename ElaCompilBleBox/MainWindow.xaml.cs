using System;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WLightBoxApi.Contracts;
using WLightBoxApi.WebServices;
using System.Drawing;

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


        private void Handle_Checked_Effect(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            this.EffectModeToSet.Text = (string)rb.Content;
        }

        private void ColorFadeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int val = Convert.ToInt32(e.NewValue);
            string msg = String.Format("Current value: {0}", val);
            this.ColorFadeValue.Text = msg;

        }

        private void EffectFadeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int val = Convert.ToInt32(e.NewValue);
            string msg = String.Format("Current value: {0}", val);
            this.EffectFadeValue.Text = msg;
        }

        private void EffectStepSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int val = Convert.ToInt32(e.NewValue);
            string msg = String.Format("Current value: {0}", val);
            this.EffectStepValue.Text = msg;
        }

        private void RedStepSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int val = Convert.ToInt32(e.NewValue);
            string msg = String.Format("Current value: {0}", val);
            this.RedValue.Text = msg;

            var redValue = Convert.ToInt32(this.RedStepSlider.Value);
            var greenValue = Convert.ToInt32(this.GreenStepSlider.Value);
            var blueValue = Convert.ToInt32(this.BlueStepSlider.Value);
            System.Drawing.Color myColor = System.Drawing.Color.FromArgb(redValue, greenValue, blueValue);
            string hex = myColor.R.ToString("X2") + myColor.G.ToString("X2") + myColor.B.ToString("X2");

            SetColor.Text = $"{hex}0000";

            var converter = new BrushConverter();          
            var brush = (Brush)converter.ConvertFromString($"#{hex}");
            this.SetColorBox.Background = brush;

        }

        private void GreenStepSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int val = Convert.ToInt32(e.NewValue);
            string msg = String.Format("Current value: {0}", val);
            this.GreenValue.Text = msg;

            var redValue = Convert.ToInt32(this.RedStepSlider.Value);
            var greenValue = Convert.ToInt32(this.GreenStepSlider.Value);
            var blueValue = Convert.ToInt32(this.BlueStepSlider.Value);
            System.Drawing.Color myColor = System.Drawing.Color.FromArgb(redValue, greenValue, blueValue);
            string hex = myColor.R.ToString("X2") + myColor.G.ToString("X2") + myColor.B.ToString("X2");

            SetColor.Text = $"{hex}0000";

            var converter = new BrushConverter();
            var brush = (Brush)converter.ConvertFromString($"#{hex}");
            this.SetColorBox.Background = brush;
        }

        private void BlueStepSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int val = Convert.ToInt32(e.NewValue);
            string msg = String.Format("Current value: {0}", val);
            this.BlueValue.Text = msg;

            var redValue = Convert.ToInt32(this.RedStepSlider.Value);
            var greenValue = Convert.ToInt32(this.GreenStepSlider.Value);
            var blueValue = Convert.ToInt32(this.BlueStepSlider.Value);
            System.Drawing.Color myColor = System.Drawing.Color.FromArgb(redValue, greenValue, blueValue);
            string hex = myColor.R.ToString("X2") + myColor.G.ToString("X2") + myColor.B.ToString("X2");

            SetColor.Text = $"{hex}0000";

            var converter = new BrushConverter();
            var brush = (Brush)converter.ConvertFromString($"#{hex}");
            this.SetColorBox.Background = brush;
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = HttpClientSetup.CreateHttpClient();
            string ipAdress = this.DeviceAdress.Text;
            GetInfo getInfo = new GetInfo(ipAdress, httpClient);
            DeviceResponse deviceStatus = getInfo.GetInfoFromApi();

            this.DeviceName.Text = deviceStatus.device.deviceName;
            this.ProductName.Text = deviceStatus.device.product;
            this.Hv.Text = deviceStatus.device.hv;
            this.Fv.Text = deviceStatus.device.fv;
            this.ActualDeviceAdress.Text = deviceStatus.device.ip;

            GetRgbw getRgbw = new GetRgbw(ipAdress, httpClient);
            RgbwResponse rgbwStatus = getRgbw.GetRgbwFromApi();

            this.ActualColorMode.Text = ColorModes[rgbwStatus.rgbw.colorMode];
            this.ActualEffectId.Text = ColorEffects[rgbwStatus.rgbw.effectID];
            this.ActualColorFade.Text = Convert.ToString(rgbwStatus.rgbw.durationsMs.colorFade);
            this.ActualEffectFade.Text = Convert.ToString(rgbwStatus.rgbw.durationsMs.effectFade);
            this.ActualEffectStep.Text = Convert.ToString(rgbwStatus.rgbw.durationsMs.effectStep);
            this.ActualColor.Text = Convert.ToString(rgbwStatus.rgbw.currentColor);

            var converter = new BrushConverter();
            
            string actualColor = Convert.ToString(rgbwStatus.rgbw.currentColor);

                var brush = (Brush)converter.ConvertFromString($"#{actualColor}");
                this.ActualColorBox.Background = brush;
           
        }

        private void UpdateColor_Click(object sender, RoutedEventArgs e)
        {
            RgbwChangeColorRequest rgbwContract = new RgbwChangeColorRequest();

            rgbwContract.rgbw.desiredColor = this.SetColor.Text;

            rgbwContract.rgbw.durationsMs.colorFade = Convert.ToInt32(this.ColorFadeSlider.Value);

            HttpClient httpClient = HttpClientSetup.CreateHttpClient();
            string ipAdress = this.DeviceAdress.Text;

            PostRgbwChangeColor postRgbw = new PostRgbwChangeColor(ipAdress, rgbwContract, httpClient);
            RgbwResponse rgbwStatus = postRgbw.PostRgbwChangeColorToApi();

            this.ActualColorMode.Text = ColorModes[rgbwStatus.rgbw.colorMode];
            this.ActualEffectId.Text = ColorEffects[rgbwStatus.rgbw.effectID];
            this.ActualColorFade.Text = Convert.ToString(rgbwStatus.rgbw.durationsMs.colorFade);
            this.ActualEffectFade.Text = Convert.ToString(rgbwStatus.rgbw.durationsMs.effectFade);
            this.ActualEffectStep.Text = Convert.ToString(rgbwStatus.rgbw.durationsMs.effectStep);
            this.ActualColor.Text = Convert.ToString(rgbwStatus.rgbw.currentColor);

            var converter = new BrushConverter();

            string actualColor = Convert.ToString(rgbwStatus.rgbw.currentColor);
            var brush = (Brush)converter.ConvertFromString($"#{actualColor}");
            this.ActualColorBox.Background = brush;


        }

        private void UpdateEffect_Click(object sender, RoutedEventArgs e)
        {
            RgbwChangeEffectRequest rgbwContract = new RgbwChangeEffectRequest();

            rgbwContract.rgbw.durationsMs.effectFade = Convert.ToInt32(this.EffectFadeSlider.Value);
            rgbwContract.rgbw.durationsMs.effectStep = Convert.ToInt32(this.EffectStepSlider.Value);

            rgbwContract.rgbw.effectID = Int32.Parse(this.EffectModeToSet.Text.Substring(0, 1));

            HttpClient httpClient = HttpClientSetup.CreateHttpClient();
            string ipAdress = this.DeviceAdress.Text;

            PostRgbwChangeEffect postRgbw = new PostRgbwChangeEffect(ipAdress, rgbwContract, httpClient);
            RgbwResponse rgbwStatus = postRgbw.PostRgbwChangeEffectToApi();

            this.ActualColorMode.Text = ColorModes[rgbwStatus.rgbw.colorMode];
            this.ActualEffectId.Text = ColorEffects[rgbwStatus.rgbw.effectID];
            this.ActualColorFade.Text = Convert.ToString(rgbwStatus.rgbw.durationsMs.colorFade);
            this.ActualEffectFade.Text = Convert.ToString(rgbwStatus.rgbw.durationsMs.effectFade);
            this.ActualEffectStep.Text = Convert.ToString(rgbwStatus.rgbw.durationsMs.effectStep);
            this.ActualColor.Text = Convert.ToString(rgbwStatus.rgbw.currentColor);

            var converter = new BrushConverter();

            string actualColor = Convert.ToString(rgbwStatus.rgbw.currentColor);
            var brush = (Brush)converter.ConvertFromString($"#{actualColor}");
            this.ActualColorBox.Background = brush;


        }

        public string[] ColorModes = new string[] {"OFF",
            "RGBW",
            "RGB",
            "MONO",
            "RGBorW",
            "CT",
            "CTx2",
            "RGBWW"};

        public string[] ColorEffects = new string[] {"OFF",
            "Fade",
            "RGB",
            "Police",
            "Relax",
            "Strobo",
            "Bell" };

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
