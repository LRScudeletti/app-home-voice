using Microsoft.Speech.Recognition;
using Microsoft.Speech.Synthesis;
using System.Globalization;
using System.Windows;

namespace HomeVoice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly SpeechSynthesizer speechSynthesizer;
        private readonly SpeechRecognitionEngine speechRecognitionEngine;

        public MainWindow()
        {
            InitializeComponent();

            speechRecognitionEngine = new SpeechRecognitionEngine();
            speechRecognitionEngine.SetInputToDefaultAudioDevice();

            speechSynthesizer = new SpeechSynthesizer();
            speechSynthesizer.SetOutputToDefaultAudioDevice();

            var choices = new Choices();
            choices.Add("Ligar luz quarto");
            choices.Add("Desligar luz quarto");
            choices.Add("Ligar computador quarto");
            choices.Add("Desligar computador quarto");
            choices.Add("Ligar ar condicionado quarto");
            choices.Add("Desligar ar condicionado quarto");
            choices.Add("Ligar luz banheiro");
            choices.Add("Desligar luz banheiro");
            choices.Add("Ligar chuveiro");
            choices.Add("Desligar chuveiro");
            choices.Add("Ligar luz cozinha");
            choices.Add("Desligar luz cozinha");
            choices.Add("Ligar ventilador");
            choices.Add("Desligar ventilador");
            choices.Add("Ligar micro-ondas");
            choices.Add("Desligar micro-ondas");
            choices.Add("Ligar luz sala");
            choices.Add("Desligar luz sala");
            choices.Add("Ligar TV sala");
            choices.Add("Desligar TV sala");
            choices.Add("Ligar ar condicionado sala");
            choices.Add("Desligar ar condicionado sala");

            var grammarBuilder = new GrammarBuilder { Culture = CultureInfo.CurrentCulture };
            grammarBuilder.Append(choices);
            var grammar = new Grammar(grammarBuilder);

            speechRecognitionEngine.LoadGrammar(grammar);
            speechRecognitionEngine.SpeechRecognized += SpeechRecognitionEngineSpeechRecognized;
            speechRecognitionEngine.SpeechRecognitionRejected += SpeechRejected;

            speechRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void SpeechRecognitionEngineSpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            // if (e.Result.Confidence < 0.8) return;

            switch (e.Result.Text)
            {
                case "Ligar luz quarto":
                    ImgBedroomLampOn.Visibility = Visibility.Visible;
                    ImgBedroomLampOff.Visibility = Visibility.Collapsed;
                    speechSynthesizer.Speak("A luz do quarto foi ligada");
                    break;

                case "Desligar luz quarto":
                    ImgBedroomLampOn.Visibility = Visibility.Collapsed;
                    ImgBedroomLampOff.Visibility = Visibility.Visible;
                    speechSynthesizer.Speak("A luz do quarto foi desligada");
                    break;

                case "Ligar computador quarto":
                    ImgComputerOn.Visibility = Visibility.Visible;
                    ImgComputerOff.Visibility = Visibility.Collapsed;
                    speechSynthesizer.Speak("O computador do quarto foi ligado");
                    break;

                case "Desligar computador quarto":
                    ImgComputerOn.Visibility = Visibility.Collapsed;
                    ImgComputerOff.Visibility = Visibility.Visible;
                    speechSynthesizer.Speak("O computador do quarto foi desligado");
                    break;

                case "Ligar ar condicionado quarto":
                    ImgBedroomAirConditionerOn.Visibility = Visibility.Visible;
                    ImgBedroomAirConditionerOff.Visibility = Visibility.Collapsed;
                    speechSynthesizer.Speak("O ar condicionado do quarto foi ligado");
                    break;

                case "Desligar ar condicionado quarto":
                    ImgBedroomAirConditionerOn.Visibility = Visibility.Collapsed;
                    ImgBedroomAirConditionerOff.Visibility = Visibility.Visible;
                    speechSynthesizer.Speak("O ar condicionado do quarto foi desligado");
                    break;

                case "Ligar luz banheiro":
                    ImgBathroomLampOn.Visibility = Visibility.Visible;
                    ImgBathroomLampOff.Visibility = Visibility.Collapsed;
                    speechSynthesizer.Speak("A luz do banheiro foi ligada");
                    break;

                case "Desligar luz banheiro":
                    ImgBathroomLampOn.Visibility = Visibility.Collapsed;
                    ImgBathroomLampOff.Visibility = Visibility.Visible;
                    speechSynthesizer.Speak("A luz do banheiro foi desligada");
                    break;

                case "Ligar chuveiro":
                    ImgShowerOn.Visibility = Visibility.Visible;
                    speechSynthesizer.Speak("O chuveiro foi ligado");
                    break;

                case "Desligar chuveiro":
                    ImgShowerOn.Visibility = Visibility.Collapsed;
                    speechSynthesizer.Speak("O chuveiro foi desligado");
                    break;

                case "Ligar luz cozinha":
                    ImgKitchenLampOn.Visibility = Visibility.Visible;
                    ImgKitchenLampOff.Visibility = Visibility.Collapsed;
                    speechSynthesizer.Speak("A luz da cozinha foi ligada");
                    break;

                case "Desligar luz cozinha":
                    ImgKitchenLampOn.Visibility = Visibility.Collapsed;
                    ImgKitchenLampOff.Visibility = Visibility.Visible;
                    speechSynthesizer.Speak("A luz da cozinha foi desligada");
                    break;

                case "Ligar ventilador":
                    ImgFanOn.Visibility = Visibility.Visible;
                    ImgFanOff.Visibility = Visibility.Collapsed;
                    speechSynthesizer.Speak("O ventilador foi ligado");
                    break;

                case "Desligar ventilador":
                    ImgFanOn.Visibility = Visibility.Collapsed;
                    ImgFanOff.Visibility = Visibility.Visible;
                    speechSynthesizer.Speak("O ventilador foi desligado");
                    break;

                case "Ligar micro-ondas":
                    ImgMicrowaveOn.Visibility = Visibility.Visible;
                    speechSynthesizer.Speak("O micro-ondas foi ligado");
                    break;

                case "Desligar micro-ondas":
                    ImgMicrowaveOn.Visibility = Visibility.Collapsed;
                    speechSynthesizer.Speak(" Omicro-ondas foi desligado");
                    break;

                case "Ligar luz sala":
                    ImgRoomLampOn.Visibility = Visibility.Visible;
                    ImgRoomLampOff.Visibility = Visibility.Collapsed;
                    speechSynthesizer.Speak("A luz da sala foi ligada");
                    break;

                case "Desligar luz sala":
                    ImgRoomLampOn.Visibility = Visibility.Collapsed;
                    ImgRoomLampOff.Visibility = Visibility.Visible;
                    speechSynthesizer.Speak("A luz da sala foi desligada");
                    break;

                case "Ligar TV sala":
                    ImgTVOn.Visibility = Visibility.Visible;
                    ImgTVOff.Visibility = Visibility.Collapsed;
                    speechSynthesizer.Speak("A televisão da sala foi ligada");
                    break;

                case "Desligar TV sala":
                    ImgTVOn.Visibility = Visibility.Collapsed;
                    ImgTVOff.Visibility = Visibility.Visible;
                    speechSynthesizer.Speak("A televisão da sala foi desligada");
                    break;

                case "Ligar ar condicionado sala":
                    ImgLivingRoomAirConditionerOn.Visibility = Visibility.Visible;
                    ImgLivingRoomAirConditionerOff.Visibility = Visibility.Collapsed;
                    speechSynthesizer.Speak("O ar condicionado da sala foi ligado");
                    break;

                case "Desligar ar condicionado sala":
                    ImgLivingRoomAirConditionerOn.Visibility = Visibility.Collapsed;
                    ImgLivingRoomAirConditionerOff.Visibility = Visibility.Visible;
                    speechSynthesizer.Speak("O ar condicionado da sala foi desligado");
                    break;
            }
        }


        private void SpeechRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            // No recognized phrases
        }

        private void MainWindow_OnUnloaded(object sender, RoutedEventArgs e)
        {
            speechRecognitionEngine.RecognizeAsyncStop();
        }
    }
}
