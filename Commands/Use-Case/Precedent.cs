namespace Commands.Use_Case;

/// <summary>
/// Class Precedent.
/// Implements the <see cref="Commands.Use_Case.IElement" />
/// </summary>
/// <seealso cref="Commands.Use_Case.IElement" />
public class Precedent : IElement
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
    /// <summary>Gets or sets the count.</summary>
    /// <value>The count.</value>
    public static int Count { get; set; }

    /// <summary>Initializes a new instance of the <see cref="T:Commands.Use_Case.Precedent" /> class.</summary>
    public Precedent()
    {
        Id = Count - 1;
    }
}
