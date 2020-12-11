using System;
using System.Linq;

namespace NYSS_WPF_Vizhener {
    public class VizhenerAlgorithm {
        private static readonly char[] _charsAlphabet = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и',
            'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 
            'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь',
            'э', 'ю', 'я'};
        
        public static string Encode(string input, string keyword)
        {
            if (keyword.Length == 0)
                return input;
            string result = "";
            int keywordIndex = 0;
 
            foreach (char symbol in input) {
                char curSymbol = Convert.ToChar(symbol.ToString().ToLower());
                if (!_charsAlphabet.Any(x => x == curSymbol))
                {
                    result += symbol;
                    continue;
                }
                int c = (Array.IndexOf(_charsAlphabet, curSymbol) +
                         Array.IndexOf(_charsAlphabet, keyword[keywordIndex])) % _charsAlphabet.Length;
 
                result += IsUpper(curSymbol) ? _charsAlphabet[c].ToString().ToUpper() : _charsAlphabet[c].ToString();
 
                keywordIndex++;
                if (keywordIndex == keyword.Length)
                    keywordIndex = 0;
            }
 
            return result;
        }
        
        public static string Decode(string input, string keyword)
        {
            if (keyword.Length == 0)
                return input;
            string result = "";
            int keywordIndex = 0;
 
            foreach (char symbol in input) {
                char curSymbol = Convert.ToChar(symbol.ToString().ToLower());
                if (!_charsAlphabet.Any(x => x == curSymbol))
                {
                    result += symbol;
                    continue;
                }
                int c = (Array.IndexOf(_charsAlphabet, curSymbol) + _charsAlphabet.Length -
                         Array.IndexOf(_charsAlphabet, keyword[keywordIndex])) % _charsAlphabet.Length;
                result += IsUpper(curSymbol) ? _charsAlphabet[c].ToString().ToUpper() : _charsAlphabet[c].ToString();
 
                keywordIndex++;
                if (keywordIndex == keyword.Length)
                    keywordIndex = 0;
            }
 
            return result;
        }
        private static bool IsUpper(char c) {
            return c.ToString().ToUpper() == c.ToString();
        }
    }
}