using System.Data;
using System.Globalization;
using System.Text;

Console.WriteLine(" ---- Home work 10 ----\n");

// Step 1
string directoryPath1 = @"D:\OTUS\TestDir1";
DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath1);
if (!directoryInfo.Exists)
{
    directoryInfo.Create();
}

string directoryPath2 = @"D:\OTUS\TestDir2";
directoryInfo = new DirectoryInfo(directoryPath2);
if (!directoryInfo.Exists)
{
    directoryInfo.Create();
}

// Step 2
for (int i = 1; i <= 10; i++)
{
    string filePath = $@"D:\OTUS\TestDir1\File_{i}.txt";
    FileInfo fileInfo = new FileInfo(filePath);

    if (!fileInfo.Exists)
    {
       File.Create(filePath).Dispose();
    }

    filePath = $@"D:\OTUS\TestDir1\File_{i}.txt";
    string newPath = $@"D:\OTUS\TestDir2\File_{i + 10}.txt";
    fileInfo = new FileInfo(filePath);

    if (fileInfo.Exists)
    {
        File.Copy(filePath, newPath, true);
    }    
}

// Step 3, 4
if (Directory.Exists(directoryPath1))
{
    var fileList = Directory.GetFiles(directoryPath1);

    for (int i = 0; i < fileList.Length; i++)
    {
        using (StreamWriter writer = new StreamWriter(fileList[i], false, Encoding.UTF8))
        {
            await writer.WriteLineAsync(new FileInfo(fileList[i]).Name);
            await writer.WriteLineAsync(Convert.ToString(DateTime.Now));
        }
    }
}

if (Directory.Exists(directoryPath2))
{
    var fileList = Directory.GetFiles(directoryPath2);

    for (int i = 0; i < fileList.Length; i++)
    {
        using (StreamWriter writer = new StreamWriter(fileList[i], false, Encoding.UTF8))
        {
            await writer.WriteLineAsync(new FileInfo(fileList[i]).Name);
            await writer.WriteLineAsync(Convert.ToString(DateTime.Now));
        }
    }
}

// Step 5
if (Directory.Exists(directoryPath1))
{
    Console.WriteLine(directoryPath1);
    Console.WriteLine("------------------------------------");
    var fileList = Directory.GetFiles(directoryPath1);
    for (int i = 0; i < fileList.Length; i++)
    {
        using (StreamReader reader = new StreamReader(fileList[i]))
        {
            string? line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                Console.Write($"{line}\t");
            }
            Console.WriteLine();
        }
    }
    Console.WriteLine("------------------------------------\n");
}

if (Directory.Exists(directoryPath2))
{
    Console.WriteLine(directoryPath2);
    Console.WriteLine("------------------------------------");
    var fileList = Directory.GetFiles(directoryPath2);
    for (int i = 0; i < fileList.Length; i++)
    {
        using (StreamReader reader = new StreamReader(fileList[i]))
        {
            string? line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                Console.Write($"{line}\t");
            }
            Console.WriteLine();
        }
    }
    Console.WriteLine("------------------------------------\n");
}