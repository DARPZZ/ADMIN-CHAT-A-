using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ADMIN_CHAT_AÅÅ.Helpers;
using ADMIN_CHAT_AÅÅ.Model;
using ADMIN_CHAT_AÅÅ.ViewModel;

namespace ADMIN_CHAT_AÅÅ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ICommand RemoveMessageCommand { get; private set; }
        public ICommand SearchWordCommand { get; private set; }
        LoBeskeder loBeskeder = new LoBeskeder();
        WordSearch wordSearch = new WordSearch();
        private ListBox currentListBox;
        private object selectedItem;
        public MainWindow()
        {
            InitializeComponent();
            PositionWindowAtTopLeft();
            DataContext = this;
            loBeskeder.LoadBeskeder(happyChatListBox, sadChatListBox, neutralChatListBox);
            RemoveMessageCommand = new RelayCommand(RemoveMessages);
            SearchWordCommand = new RelayCommand(SearchWord);
        }

        private void SearchWord(object parameter)
        {
            string ord = searchTextBox.Text;
            wordSearch.SøgEfterOrd(ord, happyChatListBox, sadChatListBox, neutralChatListBox);
            Result.Text = ("There is " + wordSearch.happyWordCount + " Happy word(s) " + wordSearch.neutralWordCount +
                " neutral word(s) " + wordSearch.sadWordCount + " Sad word(s)" + " Of " + ord);
            searchTextBox.Clear();
        }

        private void RemoveMessages(object parameter)
        {
            if (currentListBox != null && selectedItem != null)
            {
                currentListBox.Items.Remove(selectedItem);
            }
            else
            {
                Debug.WriteLine("Failed to remove");
            }
        }
        private void ListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            currentListBox = sender as ListBox;
            selectedItem = currentListBox.SelectedItem;
        }
        private void PositionWindowAtTopLeft()
        {
            Left = 0;
            Top = 0;
        }

    }
}
