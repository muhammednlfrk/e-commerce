namespace ECommerce.Application.Authentication;

/// <summary>
/// Configuration for <see cref="PasswordHasher"/>.
/// </summary>
public sealed class PasswordHasherConfiguration
{
    /// <summary>
    /// The hasing algorithm name for hashing.
    /// </summary>
    public required string AlgorithmName { get; init; }
}
