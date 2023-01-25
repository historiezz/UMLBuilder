using System.Windows;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Commands.Use_Case;

namespace DiagramsElementsLibrary.Use_Case;

public class AddActor : IFigure
{
    public double X { get; set; }
    public double Y { get; set; }
    public double W { get; set; } = 30;
    public double H { get; set; } = 30;
    public double ActualFontSize { get; set; } = 12;
    public double ActualOffset { get; set; } = 20;
    public Panel Draw(IElement element, Panel panel, int numberOfElements)
    {
        SizeAdaptation(panel, numberOfElements);

        var canvas = new Canvas();
        panel.Children.Add(canvas);

        #region Circle

        var ellipse = new Ellipse()
        {
            Width = W,
            Height = H,
            Stroke = Brushes.Black
        };
        canvas.Children.Add(ellipse);

        var count = canvas.Children.Count;
        Canvas.SetLeft(canvas.Children[count - 1], panel.ActualWidth / 10 );
        Canvas.SetTop(canvas.Children[count - 1], panel.ActualHeight * element.Id / numberOfElements);

        #endregion
        #region Triangle
        var triangle = new Polygon();       
        triangle.Points = new PointCollection();
        triangle.Points.Add(new Point(panel.ActualWidth / 10 - W / 2, panel.ActualHeight * element.Id / numberOfElements  + 2*H));
        triangle.Points.Add(new Point(panel.ActualWidth / 10 + W/2, panel.ActualHeight * element.Id / numberOfElements + H) );
        triangle.Points.Add(new Point(panel.ActualWidth / 10 + (W*3)/2, panel.ActualHeight * element.Id / numberOfElements + 2 * H));
        triangle.Stroke = Brushes.Black;
        canvas.Children.Add(triangle);
        Canvas.SetLeft(canvas.Children[count], panel.ActualWidth / 10 + ellipse.Width/2 - triangle.Width / 2 );
        Canvas.SetTop(canvas.Children[count], panel.ActualHeight * element.Id  / numberOfElements + triangle.Width * 2 );
        #endregion
        #region TextBlock
        var textBlock = new TextBlock()
        {
            Name = "textBlock" + element.Id,
            Text = element.Name,
            TextAlignment = TextAlignment.Center,
            Width = W,
            Height = H,
            FontSize = ActualFontSize
        };
        canvas.Children.Add(textBlock);

        Canvas.SetLeft(canvas.Children[count+1], panel.ActualWidth / 10 + ellipse.Width / 2 - textBlock.Width / 2);
        Canvas.SetTop(canvas.Children[count+1], panel.ActualHeight * element.Id / numberOfElements + ellipse.Height*2.5 - textBlock.Height/2);
        #endregion


        ///Добавить текст к актору 
        return canvas;      
    }
    private void SizeAdaptation(FrameworkElement panel, int numberOfElements)
    {
        while (numberOfElements > (Convert.ToInt32(panel.ActualHeight / H) - 1))
        {
            this.W *= 0.75;
            this.H *= 0.75;
            this.ActualFontSize *= 0.75;
            this.ActualOffset *= 0.75;
        }
    }
}