using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;

namespace Uslygi.Classes
{
    public class WrdHelper
    {
        private FileInfo pfileInfo;

        public WrdHelper(string fileName)
        {
            if (File.Exists(fileName))
            {
                pfileInfo = new FileInfo(fileName);
            }
            else
            {
                throw new ArgumentException("file not found");
            }
        }

        internal bool Process(Dictionary<string, string> items)
        {
            try
            {
                var app = new Word.Application();
                Object file = pfileInfo.FullName;

                Object missing = Type.Missing;

                app.Documents.Open(file);

                foreach (var item in items)
                {
                    Word.Find find = app.Selection.Find;
                    find.Text = item.Key;
                    find.Replacement.Text = item.Value;

                    Object wrap = Word.WdFindWrap.wdFindContinue;
                    Object replace = Word.WdReplace.wdReplaceAll;

                    find.Execute(FindText: Type.Missing,
                    MatchCase: false,
                    MatchWholeWord: false,
                    MatchWildcards: false,
                    MatchSoundsLike: missing,
                    MatchAllWordForms: false,
                    Forward: true,
                    Wrap: wrap,
                    Format: false,
                    ReplaceWith: missing, Replace: replace);
                }
                Object newFileName = Path.Combine(pfileInfo.DirectoryName, DateTime.Now.ToString("yyyyMMdd HHmmss ") + pfileInfo.Name);
                app.ActiveDocument.SaveAs2(newFileName);
                app.ActiveDocument.Close();
                app.Quit();
                return true;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            {
                return false;
            }
        }
    }
}
