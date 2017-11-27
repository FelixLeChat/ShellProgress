namespace ShellProgress
{
    public interface IProgressing
    {
        void Update(int completed);

        void Complete();
    }
}