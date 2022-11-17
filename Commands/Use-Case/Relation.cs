namespace Commands.Use_Case;

/// <summary>
/// Class Relation.
/// Implements the <see cref="Commands.Use_Case.IElement" />
/// </summary>
/// <seealso cref="Commands.Use_Case.IElement" />
public class Relation : IElement
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>The identifier.</value>
    public int Id { get; set; }
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string? Name { get; set; }
    /// <summary>
    /// Gets or sets the actor.
    /// </summary>
    /// <value>The actor.</value>
    public Actor? Actor { get; set; }
    /// <summary>
    /// Gets or sets the precedent.
    /// </summary>
    /// <value>The precedent.</value>
    public Precedent? Precedent { get; set; }
}
