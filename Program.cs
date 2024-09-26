Console.WriteLine(" ---- Home work 10 ----\n");

string path = @"D:\OTUS\TestDir1";
DirectoryInfo directoryInfo = new DirectoryInfo(path);

if (!directoryInfo.Exists)
{
    directoryInfo.Create();
}

path = @"D:\OTUS\TestDir2";
directoryInfo = new DirectoryInfo(path);

if (!directoryInfo.Exists)
{
    directoryInfo.Create();
}

for (int i = 1; i <= 10; i++)
{
    path = $@"D:\OTUS\TestDir1\File_{i}.txt";
    FileInfo fileInfo = new FileInfo(path);

    if (!fileInfo.Exists)
    {
       File.Create(path).Dispose();
    }
    /*
    path = $@"D:\OTUS\TestDir1\File_{i}.txt";
    string newPath = $@"D:\OTUS\TestDir2\File_{i}.txt";
    fileInfo = new FileInfo(path);

    if (fileInfo.Exists)
    {
        File.Copy(path, newPath, true);
    }
    */
}




