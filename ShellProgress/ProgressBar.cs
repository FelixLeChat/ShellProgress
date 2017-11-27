using System;

namespace ShellProgress
{
    public class ProgressBar : IProgressing
    {
        private readonly int maxValue;
        private readonly bool showProgressValues;

        public ProgressBar(int maxValue, bool showProgressValues)
        {
            if (maxValue <= 0)
                throw new ArgumentException("Max value should be greater than zero.", nameof(maxValue));

            this.maxValue = maxValue;
            this.showProgressValues = showProgressValues;
            this.BarSize = 10;
            this.ProgressCharacter = '.';
        }

        public int BarSize { get; set; }

        public char ProgressCharacter { get; set; }

        public void Update(int completed)
        {
            Console.CursorVisible = false;
            var left = Console.CursorLeft;
            var perc = completed / (decimal) this.maxValue;
            var chars = (int)Math.Floor(perc / (1 / (decimal) this.BarSize));
            string p1 = string.Empty, p2 = string.Empty;

            Console.Write('[');

            for (var i = 0; i < chars; i++)
                p1 += this.ProgressCharacter;
            for (var i = 0; i < this.BarSize - chars; i++)
                p2 += this.ProgressCharacter;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(p1);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(p2);

            Console.ResetColor();
            Console.Write(']');
            Console.Write(" {0:N2}%", perc * 100);
            if (this.showProgressValues)
            {
                Console.Write($" ({completed} / {this.maxValue})");
            }
            Console.CursorLeft = left;
        }

        public void Complete()
        {
            this.Update(this.maxValue);
            Console.Write(Environment.NewLine);
        }
    }
}