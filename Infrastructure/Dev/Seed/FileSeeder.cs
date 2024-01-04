using Domain.Enum;
using Domain.Model.Generic;
using File = System.IO.File;
using FileEntity= Domain.Model.Generic.File;

namespace Infrastructure.Dev.Seed;

public class FileSeeder
{
    private List<IUser> _users;
    
    private Random _random = new Random();

    private string _fileDevPath;

    public FileSeeder(List<IUser> users, string imagesPath)
    {
        _fileDevPath = imagesPath;
        _users = users;
    }

    public List<FileEntity> CreateFiles(int fileCount)
    {
        return Enumerable.Range(1, fileCount).Select(i => CreateFile()).ToList();
    }

    private FileEntity CreateFile()
    {
        FileData fileData = GenerateRandomFileData();

        return new FileEntity()
        {
            Date = DateTime.Now,
            Format = fileData.Format,
            Name = fileData.Name,
            User = RandomizeUser(),
            Size = fileData.Size
        };
    }

    private FileData GenerateRandomFileData()
    {
        string[] filePaths = GetFilesDirectories();
        if (filePaths.Length == 0)
            throw new Exception("Could not find any files in given directory !");
        string path = filePaths[_random.Next(filePaths.Length)];
        FileInfo fileInfo = new FileInfo(path);

        if (!Enum.TryParse(fileInfo.Extension.Trim('.'),true, out FileFormatEnum formatEnum))
        {
            formatEnum = FileFormatEnum.Jpg;
        }

        return new FileData()
        {
            Format = formatEnum,
            Name = fileInfo.Name,
            Size = fileInfo.Length
        };
    }

    private string[] GetFilesDirectories()
    {
        List<string> fileDirectories = new List<string>();
        foreach (FileFormatEnum format in Enum.GetValues(typeof(FileFormatEnum)))
        {
            fileDirectories.AddRange(Directory.GetFiles(_fileDevPath, $"*.{format.ToString().ToLower()}"));
        }

        return fileDirectories.ToArray();
    }
    
    private IUser RandomizeUser()
    {
        return _users[_random.Next(_users.Count)];
    }
    
    private record FileData
    {
        public long Size { get; set; }
    
        public string Name { get; set; }
    
        public FileFormatEnum Format { get; set; }
    }
}