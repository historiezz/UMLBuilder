namespace Commands.Use_Case;

public class Relation : IElement
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public Actor? Actor { get; set; }
    public Precedent? Precedent { get; set; }
}
