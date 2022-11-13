using Commands.Use_Case;

namespace Commands.Services.Use_Case;

public class AddCommand
{
    /// <summary>
    /// Добавление команды (прецедента или актора).
    /// </summary>
    /// <param name="command">Строка команды.</param>
    /// <returns>Найденная команда.</returns>
    public static IElement? AddCommandAction(string command)
    {
        var pair = command.Split(' ');
        return GetNewElement.GetNewElementAction(pair);
    }
}