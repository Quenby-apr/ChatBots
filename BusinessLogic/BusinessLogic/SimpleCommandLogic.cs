using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChatBots.BusinessLogic.BusinessLogic
{
    public class SimpleCommandLogic
    {
        public string DoRoll(string message, string userName)
        {
            List<string> numbers = Regex.Split(message, @"\D+").ToList();
            numbers.RemoveAll(x => x == string.Empty);
            int value;
            Random rnd = new Random();
            if (numbers.Count == 1 && int.TryParse(numbers[0], out value) && numbers[0] != int.MaxValue.ToString())
            {
                value = rnd.Next(0, int.Parse(numbers[0]) + 1);
            }
            else if (numbers.Count == 2 && int.TryParse(numbers[0], out value) && int.TryParse(numbers[1], out value) && numbers[0] != int.MaxValue.ToString() && numbers[1] != int.MaxValue.ToString())
            {
                if (int.Parse(numbers[0]) > int.Parse(numbers[1]))
                {
                    string buf = numbers[1];
                    numbers[1] = numbers[0];
                    numbers[0] = buf;
                }
                value = rnd.Next(int.Parse(numbers[0]), int.Parse(numbers[1]) + 1);
            }
            else
            {
                value = rnd.Next(0, 101);
            }
            return userName + ", ваш результат: " + value.ToString();
        }

        public string DoFlip(string userName)
        {
            Random rnd = new Random();
            int value = rnd.Next(0, 2);
            if (value == 0)
            {
                return userName + ", вам выпадает Решка";
            }
            else
            {
                return userName + ", вам выпадает Орёл";
            }
        }
    }
}
