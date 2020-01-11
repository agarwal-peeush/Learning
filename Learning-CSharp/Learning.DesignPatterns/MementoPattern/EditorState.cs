namespace Learning.DesignPatterns.MementoPattern
{
    internal class EditorState
    {
        public string Content { get; }

        public EditorState(string content)
        {
            this.Content = content;
        }
    }
}
