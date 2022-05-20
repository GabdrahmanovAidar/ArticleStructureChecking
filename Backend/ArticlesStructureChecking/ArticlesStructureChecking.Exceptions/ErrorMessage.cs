namespace ArticlesStructureChecking.Exceptions
{
    internal sealed class ErrorMessage
    {
        public IReadOnlyCollection<string> Controversy { get; }

        public ErrorMessage(IReadOnlyCollection<string> controversy)
        {
            Controversy = controversy;
        }
    }
}
