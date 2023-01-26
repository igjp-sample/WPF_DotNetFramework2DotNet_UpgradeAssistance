using System;
using System.Collections.Generic;

namespace ScoreSheets_SampleWPFApplication.Model
{
    internal class SubjectAndFrequencyData
    {
        public String Subject { get; set; }
        public List<Frequency> Frequencies { get; set; }

        public SubjectAndFrequencyData()
        {
        }
    }
}
