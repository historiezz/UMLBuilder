using Commands.Services.Use_Case;
using Commands.Use_Case;
using DiagramsElementsLibrary;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows;

namespace Client;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    /// <summary>
    /// The separator
    /// </summary>
    private const string Separator = "\r\n";
    /// <summary>
    /// The diagram
    /// </summary>
    private Diagram _diagram = new() { Elements = new List<IElement?>()};

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
        (new DiagramsElementsLibrary.Use_Case.AddPrecedent()).Draw(new Precedent() {Id = 1, Name = "Test"}, ImgDiagram);
    }

    /// <summary>
    /// Strings the format rich text box.
    /// </summary>
    /// <param name="richTextBox">The rich text box.</param>
    /// <returns>System.String.</returns>
    private string StringFormatRichTextBox(RichTextBox richTextBox)
    {
        var textRange = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);

        return textRange.Text;
    }

    /// <summary>
    /// Handles the KeyDown event of the TbConsole control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
    private void TbConsole_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.F1)
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