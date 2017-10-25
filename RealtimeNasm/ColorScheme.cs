using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealtimeNasm
{
    /// <summary>
    /// Върши syntax highlighting
    /// </summary>
    public abstract class ColorScheme
    {
        #region Keyword highlighting backstage
        enum KeywordType
        {
            Instruction,
            Register,
            Other
        }

        class KeywordGroup : IComparable
        {
            public int wordSize;
            public Dictionary<string, KeywordType> words = new Dictionary<string, KeywordType>();

            public int CompareTo(object obj)
            {
                KeywordGroup other = obj as KeywordGroup;
                return -wordSize.CompareTo(other.wordSize);
            }
        }

        /// <summary>
        /// Сортиран по големина (големи -> малки) списък от ключови думи
        /// </summary>
        static List<KeywordGroup> keywordGroups = new List<KeywordGroup>();

        static Color[] colors = new Color[16];

        static Color commentColor = Color.FromArgb(60, 150, 60);

        public static void LoadKeywords()
        {
            colors[(int)KeywordType.Instruction] = Color.FromArgb(170, 120, 170);
            colors[(int)KeywordType.Register] = Color.FromArgb(0, 120, 170);
            colors[(int)KeywordType.Other] = Color.FromArgb(230, 100, 0);

            KeywordGroup[] groups = new KeywordGroup[16];

            // зареждане от ресурсния файл
            string[] instructions = Keywords.instructions.Split(',');
            foreach(string instr in instructions)
            {
                if (groups[instr.Length] == null)
                {
                    groups[instr.Length] = new KeywordGroup();
                    groups[instr.Length].wordSize = instr.Length;
                }

                KeywordGroup current = groups[instr.Length];
                current.words.Add(instr, KeywordType.Instruction);
            }

            string[] registers = Keywords.registers.Split(',');
            foreach (string reg in registers)
            {
                if (groups[reg.Length] == null)
                {
                    groups[reg.Length] = new KeywordGroup();
                    groups[reg.Length].wordSize = reg.Length;
                }

                KeywordGroup current = groups[reg.Length];
                current.words.Add(reg, KeywordType.Register);
            }

            string[] others = Keywords.other.Split(',');
            foreach (string other in others)
            {
                if (groups[other.Length] == null)
                {
                    groups[other.Length] = new KeywordGroup();
                    groups[other.Length].wordSize = other.Length;
                }

                KeywordGroup current = groups[other.Length];
                current.words.Add(other, KeywordType.Other);
            }

            for (int i = 15; i >= 0; i--)
                if (groups[i] != null) keywordGroups.Add(groups[i]);
        }

        #endregion

        /// <summary>
        /// Highlight-ва последното написаната дума
        /// </summary>
        /// <param name="rtb"></param>
        public static void Highlight(RichTextBox rtb)
        {
            if (rtb.TextLength == 0) return;

            int idx = rtb.SelectionStart;
            bool isComment = false;
            int commentIdx = 0;

            while (idx-- > 0)
            {
                if (rtb.Text[idx] == ';')
                {
                    isComment = true;
                    commentIdx = idx;
                    break;
                }

                if (rtb.Text[idx] == '\n')
                {
                    rtb.SelectionColor = rtb.ForeColor;
                    break;
                }
            }            

            if (isComment)
            {
                int endIdx = commentIdx;
                while (endIdx < rtb.TextLength && rtb.Text[endIdx] != '\n') endIdx++;

                rtb.SelectionStart = commentIdx;
                rtb.SelectionLength = endIdx - commentIdx;
                rtb.SelectionColor = commentColor;
                rtb.SelectionStart = endIdx;
                rtb.SelectionLength = 0;

                return;
            }

            foreach (KeywordGroup kwg in keywordGroups)
            {
                int startIdx = rtb.SelectionStart - kwg.wordSize;
                if (startIdx < 0) continue;
                string testWord = rtb.Text.Substring(startIdx, kwg.wordSize);

                if (kwg.words.ContainsKey(testWord))
                {
                    Color color = colors[(int)kwg.words[testWord]];

                    rtb.SelectionStart = startIdx;
                    rtb.SelectionLength = kwg.wordSize;
                    rtb.SelectionColor = color;

                    rtb.SelectionStart = startIdx + kwg.wordSize;
                    rtb.SelectionLength = 0;
                    rtb.SelectionColor = rtb.ForeColor;

                    break;
                }
            }
        }

        public static void HighlightAll(RichTextBox rtb)
        {
            int idx = 0;
            int len = rtb.TextLength;
            string text = rtb.Text;

            while (idx < len)
            {
                int start = idx;
                while (idx < len && text[idx] != '\n') idx++;
                if (idx >= len) idx = len - 1;
                HighlightLine(rtb, start, idx);
                idx++;
            }
        }

        static void HighlightLine(RichTextBox rtb, int start, int end)
        {
            while (start <= end)
            {
                if (rtb.Text[start] == ';')
                {
                    rtb.SelectionStart = start;
                    rtb.SelectionLength = end - start;
                    rtb.SelectionColor = commentColor;

                    rtb.SelectionStart = end;
                    rtb.SelectionLength = 0;
                    rtb.SelectionColor = rtb.ForeColor;
                    break;
                }

                foreach (KeywordGroup kwg in keywordGroups)
                {
                    if (start + kwg.wordSize > end) continue;
                    string testWord = rtb.Text.Substring(start, kwg.wordSize);

                    if (kwg.words.ContainsKey(testWord))
                    {
                        Color color = colors[(int)kwg.words[testWord]];
                        
                        rtb.SelectionStart = start;
                        rtb.SelectionLength = kwg.wordSize;
                        rtb.SelectionColor = color;

                        rtb.SelectionStart = start + kwg.wordSize;
                        rtb.SelectionLength = 0;
                        rtb.SelectionColor = rtb.ForeColor;

                        start += kwg.wordSize;
                        break;
                    }
                }

                start++;
            }
        }

        static bool CompareAt(string pattern, string source, int offset)
        {
            for (int i = 0; i < pattern.Length; i++)
                if (source[offset + i] != pattern[i]) return false;

            return true;
        }
    }
}
