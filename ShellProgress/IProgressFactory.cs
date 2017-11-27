namespace ShellProgress
{
    public interface IProgressFactory
    {
        IProgressing CreateInstance(int maxValue, bool showProgressValues = false);
    }
}