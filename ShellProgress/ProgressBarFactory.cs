namespace ShellProgress
{
    public class ProgressBarFactory : IProgressFactory
    {
        public IProgressing CreateInstance(int maxValue, bool showProgressValues = false)
        {
            return new ProgressBar(maxValue, showProgressValues)
            {
                BarSize = 50,
                ProgressCharacter = '='
            };
        }
    }
}