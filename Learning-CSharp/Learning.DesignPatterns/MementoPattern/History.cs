using System.Collections.Generic;

namespace Learning.DesignPatterns.MementoPattern
{
    class History
    {
        private Stack<EditorState> _EditorStates = new Stack<EditorState>();

        public void Push(EditorState state)
        {
            _EditorStates.Push(state);
        }

        public EditorState Pop()
        {
            return _EditorStates.Pop();
        }
    }
}
