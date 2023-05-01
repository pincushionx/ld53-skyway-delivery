namespace Pincushion.LD53
{
    public interface IMission
    {
        string Name { get; }
        string Text { get; }
        string SourcePlatformText { get; }
        string DesitnationPlatformText { get; }
        string SourcePlatformId { get; }
        string DestinationPlatformId { get; }
    }
}