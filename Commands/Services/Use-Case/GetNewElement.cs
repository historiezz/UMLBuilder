using Commands.Use_Case;

namespace Commands.Services.Use_Case;

public class GetNewElement
{
    /// <summary>
    /// Поиск элемента.
    /// </summary>
    /// <param name="pair">Пара значений из команды.</param>
    /// <returns>Найденный элемент.</returns>
    public static IElement? GetNewElementAction(string[]? pair)
    {
        return (pair[0] == "Актор" ? new Actor() { Id = 0, Name = pair[1] } :
            pair[0] == "Прецедент" ? new Precedent() { Id = 0, Name = pair[1] } : null);
    }
}