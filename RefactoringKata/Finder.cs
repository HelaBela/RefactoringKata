using System.Collections.Generic;
using System.Linq;

namespace RefactoringKata
{
    public class Finder
    {
        
        private readonly List<Person> _listOfPeople;

        public Finder(List<Person> listOfPeople)
        {
            _listOfPeople = listOfPeople;
        }

        public FinderResult Find(FindTypes findTypes)
        {

            var results = GetResults();

            if(results.Count < 1)
            {
                return new FinderResult();
            }
            
            var sortedResults = results.OrderBy(result => result.TimeSpan).ToList();
            var resultWithShortestTimeSpan = sortedResults[0];
            var resultWithLongestTimeSpan = sortedResults[sortedResults.Count - 1];
            
            return findTypes == FindTypes.ClosestTwo ? resultWithShortestTimeSpan : resultWithLongestTimeSpan;
            
        }
        
        // var list = new List<Person>() { greg, mike, sarah, sue };

        private List<FinderResult> GetResults()
        {
            var results = new List<FinderResult>();

            for (var i = 0; i < _listOfPeople.Count - 1; i++)
            {
                for (var j = i + 1; j < _listOfPeople.Count; j++)
                {
                    var result = new FinderResult();
                    if (_listOfPeople[i].BirthDate < _listOfPeople[j].BirthDate)
                    {
                        result.YoungerPerson = _listOfPeople[i];
                        result.OlderPerson = _listOfPeople[j];
                    }
                    else
                    {
                        result.YoungerPerson = _listOfPeople[j];
                        result.OlderPerson = _listOfPeople[i];
                    }

                    result.TimeSpan = result.OlderPerson.BirthDate - result.YoungerPerson.BirthDate;
                    results.Add(result);
                }
            }

            return results;
        }
    }
}