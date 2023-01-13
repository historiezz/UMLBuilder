using Commands.Use_Case;

namespace Commands.Services.Use_Case;

/// <summary>
/// Class GetNewElement.
/// </summary>
public class GetNewElementService
{
    /// <summary>
    /// Поиск элемента.
    /// </summary>
    /// <param name="pair">Пара значений из команды.</param>
    /// <returns>Найденный элемент.</returns>
    public static IElement? GetNewElementAction(string[]? pair)
    {
        if (pair?[0] == "Прецедент")
        {
            Precedent.Count++;
        }
        if (pair?[0] == "Актор")
        {
            Actor.Count++;
        }

        return (pair?[0] == "Актор" ? new Actor() { Name = pair[1] } :
            pair?[0] == "Прецедент" ? new Precedent() { Name = pair[1] } : null);
    }
}