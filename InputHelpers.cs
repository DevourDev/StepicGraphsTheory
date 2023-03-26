namespace GraphsTheory
{
    public static class InputHelpers
    {
        public static int ReadIntFromConsole()
        {
            return int.Parse(Console.ReadLine()!);
        }

        public static int[] ReadIntsArrayFromConsole()
        {
            string input = Console.ReadLine()!;
            string[] splitted = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int count = splitted.Length;
            int[] ints = new int[count];

            for (int i = 0; i < count; i++)
            {
                ints[i] = int.Parse(splitted[i]);
            }

            return ints;
        }


        //todo: implement ACTUALLY 0 alloc (write custom string splitter method)
        public static int ReadIntsArrayFromConsoleNonAlloc(int[] buffer)
        {
            string input = Console.ReadLine()!;
            string[] splitted = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int count = splitted.Length;

            for (int i = 0; i < count; i++)
            {
                buffer[i] = int.Parse(splitted[i]);
            }

            return count;
        }
    }
}
