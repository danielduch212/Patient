namespace Shared.Identity;

public class IdentityOperationResult
{
    public bool IsSuccess { get; set; }
    public IEnumerable<string> Errors { get; set; } = default!;
}
