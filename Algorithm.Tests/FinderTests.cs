using System;
using System.Collections.Generic;
using RefactoringKata;
using Xunit;

namespace Algorithm.Tests
{
    public class FinderTests
    {
        [Fact]
        public void Returns_Empty_Results_When_Given_Empty_List()
        
        {
            var list = new List<Person>();
            var finder = new Finder(list);

            var result = finder.Find(FindTypes.ClosestTwo);

            Assert.Null(result.YoungerPerson);
            Assert.Null(result.OlderPerson);
        }

        [Fact]
        public void Returns_Empty_Results_When_List_Contains_One_Person()
        {
            var list = new List<Person>() { sue };
            var finder = new Finder(list);

            var result = finder.Find(FindTypes.ClosestTwo);

            Assert.Null(result.YoungerPerson);
            Assert.Null(result.OlderPerson);
        }

        [Fact]
        public void Returns_Closest_Two_On_Finding_Closest_Two_In_List_Of_Two_People()
        {
            var list = new List<Person>() { sue, greg };
            var finder = new Finder(list);

            var result = finder.Find(FindTypes.ClosestTwo);

            Assert.Same(sue, result.YoungerPerson);
            Assert.Same(greg, result.OlderPerson);
        }

        [Fact]
        public void Returns_Furthest_Two_On_Finding_Furthest_Two_In_List_Of_Two_People()
        {
            var list = new List<Person>() { greg, mike };
            var finder = new Finder(list);

            var result = finder.Find(FindTypes.FurthestTwo);

            Assert.Same(greg, result.YoungerPerson);
            Assert.Same(mike, result.OlderPerson);
        }

        [Fact]
        public void Returns_Furthest_Two_On_Finding_Furthest_Two_In_List_Of_Four_People()
        {
            var list = new List<Person>() { greg, mike, sarah, sue };
            var finder = new Finder(list);

            var result = finder.Find(FindTypes.FurthestTwo);

            Assert.Same(sue, result.YoungerPerson);
            Assert.Same(sarah, result.OlderPerson);
        }

        [Fact]
        public void Returns_Closest_Two_On_Finding_Closest_Two_In_List_Of_Four_People()
        {
            var list = new List<Person>() { greg, mike, sarah, sue };
            var finder = new Finder(list);

            var result = finder.Find(FindTypes.ClosestTwo);

            Assert.Same(sue, result.YoungerPerson);
            Assert.Same(greg, result.OlderPerson);
        }

        Person sue = new Person() {Name = "Sue", BirthDate = new DateTime(1950, 1, 1)};
        Person greg = new Person() {Name = "Greg", BirthDate = new DateTime(1952, 6, 1)};
        Person mike = new Person() { Name = "Mike", BirthDate = new DateTime(1979, 1, 1) };
        Person sarah = new Person() { Name = "Sarah", BirthDate = new DateTime(1982, 1, 1) };
       
   
    }
}