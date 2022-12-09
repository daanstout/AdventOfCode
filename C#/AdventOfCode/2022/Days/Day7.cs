using System.Collections;

namespace _2022.Days;
public class Day7 : AdventDay {
    private class Directory : IEnumerable<Directory> {
        public string Name { get; set; }

        public Dictionary<string, Directory> SubDirectories { get; } = new Dictionary<string, Directory>();

        public Dictionary<string, int> Files { get; } = new Dictionary<string, int>();

        public Directory? ParentDirectory { get; }

        public int Size {
            get {
                if (size == -1)
                    CalculateSize();

                return size;
            }
        }

        private int size = -1;

        public Directory(string name, Directory? parent) => (Name, ParentDirectory) = (name, parent);

        public IEnumerator<Directory> GetEnumerator() {
            yield return this;

            foreach (var sub in SubDirectories.Values) {
                foreach (var dir in sub) {
                    yield return dir;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString() => $"Name: {Name} - Size: {Size}";

        private void CalculateSize() {
            size = SubDirectories.Values.Select(directory => directory.Size).Sum() + Files.Values.Sum();
        }
    }

    public Day7() : base(7, 2022, "No Space Left On Device") { }

    protected override object SolvePart1() => CreateDirectoryStructure().Where(dir => dir.Size <= 100000).Sum(dir => dir.Size);

    protected override object SolvePart2() {
        var root = CreateDirectoryStructure();

        List<Directory> directories = new List<Directory>(root);

        directories.Sort((left, right) => left.Size.CompareTo(right.Size));

        int totalSize = root.Size;

        int sizeToSave = totalSize - 40000000;

        if (sizeToSave <= 0)
            return "Nothing to delete";

        return directories.SkipWhile(dir => dir.Size < sizeToSave).First().Size;
    }

    private Directory CreateDirectoryStructure() {
        Directory currentDirectory = new Directory("/", null);
        Directory rootDirectory = currentDirectory;

        int i = 1;
        while (i < Lines.Length) {
            string line = Lines[i];
            var commands = line.Split(' ');

            if (commands[0] == "$") {
                switch (commands[1]) {
                    case "ls":
                        i++;
                        line = Lines[i];
                        while (!line.StartsWith('$')) {
                            commands = line.Split(' ');
                            if (commands[0] == "dir") {
                                currentDirectory.SubDirectories.Add(commands[1], new Directory(commands[1], currentDirectory));
                            } else {
                                currentDirectory.Files.Add(commands[1], int.Parse(commands[0]));
                            }
                            i++;
                            if (i >= Lines.Length)
                                break;
                            line = Lines[i];
                        }
                        break;
                    case "cd":
                        if (commands[2] == "..") {
                            currentDirectory = currentDirectory.ParentDirectory!;
                        } else {
                            currentDirectory = currentDirectory.SubDirectories[commands[2]];
                        }
                        i++;
                        break;
                }
            }
        }

        return rootDirectory;
    }
}
