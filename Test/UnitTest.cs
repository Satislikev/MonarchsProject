using MonarchsProject.Utility;
using Xunit;

namespace MonarchsProject.Test
{
    public class UnitTest
    {
        [Fact]
        public void VerifyYearsCalculator()
        {
            const string testYearSingle = "2000";
            const string testYearDouble = "2000-2003";
            const string testYearPresent = "2000-";
            Assert.Equal(1,Utils.CalculateYears(testYearSingle));
            Assert.Equal(3,Utils.CalculateYears(testYearDouble));
            Assert.Equal(21,Utils.CalculateYears(testYearPresent));
        }
        
        [Fact]
        public void VerifyFirstNameExtractor()
        {
            const string firstName1 = "Richard I";
            const string firstName2 = "Elizabeth";
            const string firstName3 = "REdward the Elder";
            const string firstName4 = "Ethelred II the Unready";
            Assert.Equal("RICHARD",Utils.ExtractFirstName(firstName1));
            Assert.Equal("ELIZABETH",Utils.ExtractFirstName(firstName2));
            Assert.Equal("REDWARD",Utils.ExtractFirstName(firstName3));
            Assert.Equal("ETHELRED",Utils.ExtractFirstName(firstName4));
        }
    }
}

