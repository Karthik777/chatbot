using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ChatterBotAPI;
using Microsoft.Speech.Recognition;
using Microsoft.Speech.Synthesis;

namespace ChatterBotModel
{
    public class ChatterBotWrapper
    {
        private SpeechRecognitionEngine _recognizer = null;
        private ManualResetEvent manualResetEvent = null;
        private ChatterBotSession bot2session = null;
        private ChatterBotFactory factory;
        public ChatterBotWrapper()
        {
            InitializeChatBots();
            InitializeRecognizers();
        }

        private void InitializeRecognizers()
        {
            _recognizer = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
            var gb = new GrammarBuilder {Culture = CultureInfo.GetCultureInfoByIetfLanguageTag("en")};
            gb.AppendDictation();
            _recognizer.LoadGrammar(new Grammar(gb)); // load a "hello computer" grammar
            _recognizer.SpeechRecognized += _recognizeSpeechAndMakeSureTheComputerSpeaksToYou_SpeechRecognized;
                // if speech is recognized, call the specified method
            _recognizer.SetInputToDefaultAudioDevice();
        }

        private void InitializeChatBots()
        {
            factory = new ChatterBotFactory();
            manualResetEvent = new ManualResetEvent(false);
            ChatterBot bot2 = factory.Create(ChatterBotType.PANDORABOTS, "b0dafd24ee35a477");
            bot2session = bot2.CreateSession();
        }

        public void RecognizeText()
        {
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }
        private void _recognizeSpeechAndMakeSureTheComputerSpeaksToYou_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            var s = bot2session.Think(e.Result.Text);
            using (var speechSynthesizer = new SpeechSynthesizer())
            {
                speechSynthesizer.Speak(s);
            } 
            manualResetEvent.Set();
        }
    }
}
