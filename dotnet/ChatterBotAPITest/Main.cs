using System;
using System.ComponentModel;
using System.Threading;
using ChatterBotModel;
using System.Speech;
using System.Speech.Recognition;

/*
    ChatterBotAPI
    Copyright (C) 2011 pierredavidbelanger@gmail.com
 
    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU Lesser General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
namespace ChatterBotAPITest {

    class Program
    {
        static void Main(string[] args)
        {

            // Select a speech recognizer that supports English.
            RecognizerInfo info = null;
            foreach (RecognizerInfo ri in SpeechRecognitionEngine.InstalledRecognizers())
            {
                if (ri.Culture.TwoLetterISOLanguageName.Equals("en"))
                {
                    info = ri;
                    break;
                }
            }
            if (info == null) return;

            // Create the selected recognizer.
            using (SpeechRecognitionEngine recognizer =
              new SpeechRecognitionEngine(info))
            {
                var gb = new GrammarBuilder();
                gb.AppendDictation();
                var g = new Grammar(gb);
                // Create and load a dictation grammar.
                recognizer.LoadGrammar(g);

                // Add a handler for the speech recognized event.
                recognizer.SpeechRecognized +=
                  new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);

                // Configure input to the speech recognizer.
                recognizer.SetInputToDefaultAudioDevice();

                // Start asynchronous, continuous speech recognition.
                recognizer.RecognizeAsync(RecognizeMode.Multiple);

                // Keep the console window open.
                while (true)
                {
                    Console.ReadLine();
                }
            }
        }

        // Handle the SpeechRecognized event.
        static void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine("Recognized text: " + e.Result.Text);
        }
    }

    /*  class Program
      {
          public static void Main()
          {
              ChatterBotFactory factory = new ChatterBotFactory();
              ChatterBot bot2 = factory.Create(ChatterBotType.PANDORABOTS, "b0dafd24ee35a477");
              ChatterBotSession bot2session = bot2.CreateSession();

              var r1 = new Recognizer();
              r1.Completed += (sender, e) =>
              {
                  var s = bot2session.Think(r1.Result.Text);
                  SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
                  speechSynthesizer.Speak(s);
                  speechSynthesizer.Dispose();
              };
              Console.ReadLine();
          }
      }

      class Recognizer
      {

          private readonly AsyncOperation _operation;
          private volatile RecognitionResult _result;

          public Recognizer()
          {

              _operation = AsyncOperationManager.CreateOperation(null);
              _result = null;

              var worker = new Action(Run);
              worker.BeginInvoke(delegate (IAsyncResult result) {
                  worker.EndInvoke(result);
              }, null);
          }

          private void Run()
          {
              try
              {
                  SpeechRecognitionEngine engine = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-US"));
                  engine.SetInputToDefaultAudioDevice();
                  engine.LoadGrammar(new DictationGrammar());
                  engine.BabbleTimeout = TimeSpan.FromSeconds(10.0);
                  engine.EndSilenceTimeout = TimeSpan.FromSeconds(10.0);
                  engine.EndSilenceTimeoutAmbiguous = TimeSpan.FromSeconds(10.0);
                  engine.InitialSilenceTimeout = TimeSpan.FromSeconds(10.0);
                  _result = engine.Recognize();
              }
              finally
              {
                  _operation.PostOperationCompleted(delegate {
                      RaiseCompleted();
                  }, null);
              }
          }

          public RecognitionResult Result
          {
              get { return _result; }
          }

          public event EventHandler Completed;

          protected virtual void OnCompleted(EventArgs e)
          {
              if (Completed != null)
                  Completed(this, e);
          }

          private void RaiseCompleted()
          {
              OnCompleted(EventArgs.Empty);
          }
      }*/
}
