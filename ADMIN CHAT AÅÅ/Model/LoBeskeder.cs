using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Controls;
using System.Xml.Linq;

namespace ADMIN_CHAT_AÅÅ.ViewModel
{
    public class LoBeskeder
    {
        /*
         * Henter alle beskeder ind
         * sotere dem efter sentiment, og adder dem til en list box
         */
        public void LoadBeskeder(ListBox happyChatListBox, ListBox sadChatListBox, ListBox neutralListBox)
        {
            try
            {
                string fileName = "Beskeder.xml";

                XDocument xdoc = XDocument.Load(fileName);


                happyChatListBox.Items.Clear();

                foreach (XElement Element in xdoc.Root.Elements())
                {
                    string sentiment = Element.Name.LocalName;
                    Debug.WriteLine(sentiment + " sentiment");
                    foreach (XElement messageElement in Element.Elements("message"))
                    {
                        string message = messageElement.Value;

                        ListBoxItem item = new ListBoxItem();
                        item.Content = message;

                        if (sentiment == "happy")
                        {
                            happyChatListBox.Items.Add(item);
                        }
                        else if (sentiment == "sad")
                        {
                            sadChatListBox.Items.Add(item);
                        }
                        else if (sentiment == "neutral")
                        {
                            neutralListBox.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error loading chat messages: " + ex.Message);
            }
        }
    }
}
