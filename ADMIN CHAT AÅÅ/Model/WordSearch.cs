using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace ADMIN_CHAT_AÅÅ.Model
{
    public class WordSearch
    {
        public int happyWordCount { get; set; }
        public int sadWordCount { get; set; }
        public int neutralWordCount { get; set; }
  
        /*
         * Søger igenmme hvert sentiment efter et bestemt ord
         * Når det ord er fundet vil counteren blive updateret
         */
        public void SøgEfterOrd(string ord, ListBox happyChatListBox,ListBox sadChatListBox,ListBox neutralChatListBox)
        {
            neutralWordCount = 0;
            sadWordCount = 0;
            happyWordCount = 0;

            foreach (var item in happyChatListBox.Items)
            {
                if (ContainsWholeWord(item.ToString(), ord))
                {
                    happyWordCount++;
                    Debug.WriteLine(item);
                }
            }

            foreach (var item in sadChatListBox.Items)
            {
                if (ContainsWholeWord(item.ToString(), ord))
                {
                    sadWordCount++;
                    Debug.WriteLine(item);
                }
            }

            foreach (var item in neutralChatListBox.Items)
            {
                if (ContainsWholeWord(item.ToString(), ord))
                {
                    neutralWordCount++;
                    Debug.WriteLine(item);
                }
            }
        }

        /*
         * Opbygger regex pattern 
         * Check if the input contains the whole word.
         */
        public  bool ContainsWholeWord(string input, string search)
        {
            
            string pattern = @"\b" + Regex.Escape(search) + @"\b";

            
            return Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase);
        }

    }
}
