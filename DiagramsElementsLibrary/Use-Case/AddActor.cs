using System.Windows.Controls;
using Commands.Use_Case;

namespace DiagramsElementsLibrary.Use_Case;

public class AddActor : IFigure
{
    public double X { get; set; }
    public double Y { get; set; }
    public double W { get; set; }
    public double H { get; set; }
    public Panel Draw(IElement element, Panel panel, int numberOfElements)
    {
        return null;
    }
}