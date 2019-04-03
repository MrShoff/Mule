using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveScreenshots
{
    public class Rule
    {
        #region Enums
        public enum RuleType
        {
            Consolidate,
            Backup,
            Unknown
        }
        public enum FileType
        {
            jpg,
            png,
            jpgAndPng,
            AllFiles
        }
        #endregion

        #region Attributes
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Name { get; set; }
        public FileType TypeOfFile { get; set; }
        public RuleType TypeOfRule { get; set; }
        public int FilesAffectedCount { get; set; }
        public int FilesIgnoredCount { get; set; }
        #endregion

        #region Initialization
        public Rule()
        {
            TypeOfRule = RuleType.Unknown;
            Source = "";
            Destination = "";
            Name = "";
            TypeOfFile = FileType.AllFiles;
        }

        public Rule (RuleType ruletype, string source, string destination, string name)
        {
            TypeOfRule = ruletype;
            Source = source;
            Destination = destination;
            Name = name;
            TypeOfFile = FileType.AllFiles;
        }

        public Rule(RuleType ruletype, string source, string destination, string name, FileType filetype)
        {
            TypeOfRule = ruletype;
            Source = source;
            Destination = destination;
            Name = name;
            TypeOfFile = filetype;
        }
        #endregion

    }
}
