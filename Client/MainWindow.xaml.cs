using Commands.Services.Use_Case;
using Commands.Use_Case;
using DiagramsElementsLibrary.Use_Case;
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
    private readonly Diagram _diagram = new() { Elements = new List<IElement?>()};

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
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
                    ? AddCommandService.AddCommandAction(command)
                    : AddRelationService.AddRelationAction(command, _diagram));
            }
        }

        DrawShapes();
    }

    /// <summary>Draws the shapes.</summary>
    private void DrawShapes()
    {
        if (_diagram.Elements == null) return;
        foreach (var element in _diagram.Elements)
        {
            if (element?.GetType() == typeof(Precedent))
            {
                (new AddPrecedent()).Draw(element, ImgDiagram, _diagram.Elements.Count);
            }
            else if (element?.GetType() == typeof(Actor))
            {
                (new AddActor()).Draw(element, ImgDiagram, 0);
            }
            else if (element?.GetType() == typeof(Relation))
            {
                (new AddRelation()).Draw(element, ImgDiagram, 0);
            }
        }
    }
}