using System.Text;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string parthFilterFile = @"C:\Users\Brill\Desktop\WordFilter.txt";
            string parthSourceFile = @"C:\Users\Brill\Desktop\SourceFile.txt";
            if (!File.Exists(parthFilterFile))
            {
                throw new FileNotFoundException();
            }
            if (!File.Exists(parthSourceFile))
            {
                throw new FileNotFoundException();
            }
            string[] filterLines = File.ReadAllLines(parthFilterFile);
            StringBuilder stringBuilder = new StringBuilder();

            List<string> wordFilter = new List<string>();
            foreach (string s in filterLines)
            {
                string[] temp = s.Split(" ");
                foreach (string s2 in temp)
                {
                    wordFilter.Add(s2);
                }
            }
            string[] sourceLines = File.ReadAllLines(parthSourceFile);
            for (int j = 0; j < sourceLines.Length; j++)
            {
                for (int i = 0; i < wordFilter.Count; i++)
                {
                    if (sourceLines[j].Contains(wordFilter[i]))
                    {
                        string temp = new string('*', wordFilter[i].Length);
                        sourceLines[j] = sourceLines[j].Replace(wordFilter[i], temp);
                    }
                } 
            }
            File.WriteAllLines(parthSourceFile, sourceLines);
        }
    }
}

//Задание 3:
//Создайте приложение Модератор. Пользователь вводит путь к файлу с текстом и к файлу со словами для модерирования.
//По итогам работы приложения все слова для модерирования в исходном файле должны быть заменены на *.
//Например, файл со словами для модерирования:
//car telephone
//Файл с текстом:
//test best rest car
//man telephone
//Результат:
//test best rest ***
//man *********