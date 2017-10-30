namespace GuessTheAnimal.Interface
{
    public interface IConsoleDisplay
    {
        string GetInputLine();
        void OutputLine(string content);
        void OutputEmptyLine();
    }
}
