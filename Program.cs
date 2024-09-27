using System.Data;
using System.Globalization;

Console.WriteLine(" ---- Home work 10 ----\n");

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

for (int i = 1; i <= 10; i++)
{
    string filePath = $@"D:\OTUS\TestDir1\File_{i}.txt";
    FileInfo fileInfo = new FileInfo(filePath);

    if (!fileInfo.Exists)
    {
       File.Create(filePath).Dispose();
    }

    filePath = $@"D:\OTUS\TestDir1\File_{i}.txt";
    string newPath = $@"D:\OTUS\TestDir2\File_{i}.txt";
    fileInfo = new FileInfo(filePath);

    if (fileInfo.Exists)
    {
        File.Copy(filePath, newPath, true);
    }    
}



if (Directory.Exists(directoryPath1))
{
    var fileList = Directory.GetFiles(directoryPath1);

    for (int i =  0; i < fileList.Length; i++)
    {
        using (StreamWriter writer = new StreamWriter(fileList[i], false))
        { 
            await writer.WriteLineAsync(new FileInfo(fileList[i]).Name);
        }

        using (StreamWriter writer = new StreamWriter(fileList[i], true))
        {
            await writer.WriteLineAsync(Convert.ToString(DateTime.Now));
        }
    }

    /*
    Console.WriteLine($"Files: {fileList.Length}\n");

    List<string> fileNameList = new();
    foreach (var file in fileList)
    {
        FileInfo fileNameInfo = new(file);
        fileNameList.Add(fileNameInfo.Name);
        Console.WriteLine(fileNameInfo);

    }
    */
}

if (Directory.Exists(directoryPath2))
{
    var fileList = Directory.GetFiles(directoryPath2);

    for (int i = 0; i < fileList.Length; i++)
    {
        using (StreamWriter writer = new StreamWriter(fileList[i], false))
        {
            await writer.WriteLineAsync(new FileInfo(fileList[i]).Name);
        }

        using (StreamWriter writer = new StreamWriter(fileList[i], true))
        {
            await writer.WriteLineAsync(Convert.ToString(DateTime.Now));
        }
    }
}


