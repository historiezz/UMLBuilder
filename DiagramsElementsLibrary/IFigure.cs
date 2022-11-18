using System.Windows.Controls;
using Commands.Use_Case;

namespace DiagramsElementsLibrary;

/// <summary>
/// Interface IFigure
/// </summary>
public interface IFigure
{
    /// <summary>
    /// Gets or sets the x.
    /// </summary>
    /// <value>The x.</value>
    double X { get; set; }
    /// <summary>
    /// Gets or sets the y.
    /// </summary>
    /// <value>The y.</value>
    double Y { get; set; }
    /// <summary>
    /// Gets or sets the w.
    /// </summary>
    /// <value>The w.</value>
    double W { get; set; }
    /// <summary>
    /// Gets or sets the h.
    /// </summary>
    /// <value>The h.</value>
    double H { get; set; }
    /// <summary>
    /// Draws this instance.
    /// </summary>
    /// <returns>StackPanel.</returns>
    public Panel Draw(IElement element, Panel panel, int numberOfElements);
}