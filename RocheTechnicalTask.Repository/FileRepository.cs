using Microsoft.Extensions.Configuration;
using RocheTechnicalTask.Entities;
using System.Text.RegularExpressions;

namespace RocheTechnicalTask.Repository
{
    public class FileRepository
    {
        private static List<TextFile> textFiles;
        public FileRepository()
        {

        }

        public static List<TextFile> GetTextFilesFromDir(string sDir, string sText)
        {
            textFiles = new List<TextFile>();
            //DirSearch(sDir, sText);
            
            FindFiles(sDir, sText);

            return textFiles;
        }

        private static void FindFiles(string sDir, string sText)
        {
            try
            {
                string[] files = Directory.GetFiles(sDir, "*.txt", SearchOption.AllDirectories);

                foreach (var file in files)
                {
                    using (var streamReader = new StreamReader(file))
                    {
                        var contents = streamReader.ReadToEnd();

                        if (contents.Contains(sText))
                        {
                            MatchCollection matches = Regex.Matches(contents, sText);
                            TextFile tf = new TextFile();
                            tf.Name = file;
                            tf.Coincidences = matches.Count;
                            textFiles.Add(tf);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        
    }
}