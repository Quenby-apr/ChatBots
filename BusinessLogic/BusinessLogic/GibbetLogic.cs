using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChatBots.BusinessLogic.BusinessLogic
{
    public class GibbetLogic
    {
        public CancellationTokenSource cancellationTokenSource { get; set; }
        private CancellationToken cancellationToken;
        private readonly int gibbetLetter = 10000;

        public GibbetLogic()
        {
            cancellationTokenSource = new CancellationTokenSource();
            cancellationToken = cancellationTokenSource.Token;
        }

        public void SendWord(TwitchIRCClient client, Tuple<string,string> word, CancellationToken cancellation)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                cancellationTokenSource = new CancellationTokenSource();
                cancellationToken = cancellationTokenSource.Token;
            }
            SendDescription(client, word.Item2);
            Thread.Sleep(gibbetLetter);
            
            if (!cancellationToken.IsCancellationRequested && !cancellation.IsCancellationRequested)
            {
                var hiddenWord = HideWord(word.Item1);
                client.SendMessage(hiddenWord + " ("+hiddenWord.Length+" букв)");
                Thread.Sleep(gibbetLetter);
                for (int i = 0; i < 3; i++)
                {
                    if (cancellationToken.IsCancellationRequested && !cancellation.IsCancellationRequested)
                    {
                        return;
                    }
                    hiddenWord = OpenWord(word.Item1, hiddenWord);
                    client.SendMessage(hiddenWord);
                    Thread.Sleep(gibbetLetter);
                }
                if (!cancellationToken.IsCancellationRequested && !cancellation.IsCancellationRequested)
                    client.SendMessage("К сожалению, никто не отгадал, правильное слово: " + word.Item1);
            } 
        }

        public void FinishRound(string msg, TwitchIRCClient client)
        {
            string userName = client.getUserName(msg);
            cancellationTokenSource.Cancel();
            client.answers.Remove(client.gibbetWord.Item1);
            client.SendMessage(userName + " назвал верное слово: "+ client.gibbetWord.Item1);
        }

        public Tuple<string,string> GenerateWord()
        {
            Random random = new Random();
            var word = GibbetDictionary.dictionary[random.Next(0, GibbetDictionary.dictionary.Count)];
            return word;
        }

        private void SendDescription(TwitchIRCClient client, string desc)
        {
            client.SendMessage("Отгадайте слово по описанию: " + desc);
        }
        private string HideWord(string word)
        {
            char[] newWord = word.ToCharArray();
            for (int i = 0;i < newWord.Count();i++)
            {
                newWord[i] = '*';
            }
            return new string (newWord);
        }

        private string OpenWord(string word, string hiddenWord)
        {
            char[] wordArray = word.ToCharArray();
            char[] hiddenWordArray = hiddenWord.ToCharArray();
            while (true) {
                Random random = new Random();
                int index = random.Next(0, word.Length);
                if (hiddenWordArray[index] == '*')
                {
                    hiddenWordArray[index] = wordArray[index];
                    return new string (hiddenWordArray);
                }
            }
        }
    }
}
