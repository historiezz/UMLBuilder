using Commands.Use_Case;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _separator = "\r\n";
        private Diagram _diagram = new() { Elements = new()};
        public MainWindow()
        {
            InitializeComponent();
        }

        private string StringFormatRichTextBox(RichTextBox richTextBox)
        {
            TextRange textRange = new TextRange(TbConsole.Document.ContentStart, TbConsole.Document.ContentEnd);

            return textRange.Text;
        }

        private void TbConsole_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.F1)
            {
                var commandSet = StringFormatRichTextBox(TbConsole).Split(_separator);

                foreach (var command in commandSet)
                {
                    Regex regex = new Regex(@".+\+.+");
                    MatchCollection matchCollection = regex.Matches(command);

                    if (matchCollection.Count == 0)
                    {
                        AddCommand(command);
                    }
                    else
                    {
                        AddRelation(command);
                    }
                }
            }
        }
        /// <summary>
        /// Добавление связи
        /// </summary>
        /// <param name="command">Строка команды</param>
        private void AddRelation(string command)
        {
            var pair = command.Split('+');
            IElement newElement = new Relation() { Id = 0, Name = "Name", Actor = _diagram.Elements.Find(e => e.Name == pair[0]) as Actor, Precedent = _diagram.Elements.Find(e => e.Name == pair[1]) as Precedent };
            _diagram.Elements.Add(newElement);
        }
        /// <summary>
        /// Добавление команды (прецедента или актора)
        /// </summary>
        /// <param name="command">Строка команды</param>
        private void AddCommand(string command)
        {
            var pair = command.Split(' ');
            IElement newElement = GetNewElement(pair);
            _diagram.Elements.Add(newElement);
        }
        /// <summary>
        /// Поиск элемента
        /// </summary>
        /// <param name="pair">Пара значений из команды</param>
        /// <returns>Найденный элемент</returns>
        private static IElement? GetNewElement(string[]? pair)
        {
            return (pair[0] == "Актор" ? new Actor() { Id = 0, Name = pair[1] } : pair[0] == "Прецедент" ? new Precedent() { Id = 0, Name = pair[1] } : null);
        }
    }
}
