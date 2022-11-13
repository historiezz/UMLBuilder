using Commands.Use_Case;

namespace Commands.Services.Use_Case;

public class AddRelation
{
    /// <summary>
    /// Добавление связи.
    /// </summary>
    /// <param name="command">Текст команды.</param>
    /// <param name="diagram">Диаграмма.</param>
    /// <returns></returns>
    public static Relation AddRelationAction(string command, Diagram diagram)
    {
        var pair = command.Split('+');
        var newElement = new Relation()
        {
            Id = 0,
            Name = (diagram.Elements.Find(e => e.Name == pair[0]) as Actor)?.Name + "+" + (diagram.Elements.Find(e => e.Name == pair[1]) as Precedent)?.Name,
            Actor = diagram.Elements.Find(e => e.Name == pair[0]) as Actor,
            Precedent = diagram.Elements.Find(e => e.Name == pair[1]) as Precedent
        };
        return newElement;
    }
}