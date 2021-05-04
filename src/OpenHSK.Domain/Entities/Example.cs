// <copyright file="Example.cs" company="openhsk.com">
//     Open Hsk
// </copyright>
// <author>Christophe DEBOVE</author>

namespace OpenHSK.Domain
{
    /// <summary>
    /// In order to practice the exam good examples are mandatories
    /// </summary>
    public struct Example
    {
        public Example(NotEmptyText text, HskLevel level, Student student)
        {
            this.Text = text;
            this.Level = level;
            this.Author = student;
        }

        public Student Author { get; }

        public HskLevel Level { get; }

        public NotEmptyText Text { get; }
    }
}
