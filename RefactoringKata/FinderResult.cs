using System;
using System.Collections.Generic;

namespace RefactoringKata
{
    public class FinderResult
    {
        public Person YoungerPerson { get; set; }
        public Person OlderPerson { get; set; }
        public TimeSpan TimeSpan { get; set; }

    }
}