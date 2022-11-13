using System.Collections.Generic;
using Commands.Use_Case;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using Commands.Services.Use_Case;

namespace Client;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private const string Separator = "\r\n";
    private Diagram _diagram = new() { Elements = new List<IElement?>()};
    public MainWindow()
    {
        InitializeComponent();
    }

    private string StringFormatRichTextBox(RichTextBox richTextBox)
    {
        var textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);

        return textRange.Text;
    }

    private void TbConsole_KeyDown(object sender, KeyEventArgs e)
    {
        if(e.Key == Key.F1)
        {
            var commandSet = StringFormatRichTextBox(TbConsole).Split(Separator);

            foreach (var command in commandSet)
            {
                var regex = new Regex(@".+\+.+");
                var matchCollection = regex.Matches(command);

                _diagram.Elements.Add(matchCollection.Count == 0
                    ? AddCommand.AddCommandAction(command)
                    : AddRelation.AddRelationAction(command, _diagram));
            }
        }
    }
}