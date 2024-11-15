using kirill_gubaydulin_kt_31_21;
using kirill_gubaydulin_kt_31_21.Models;


namespace kirill_gubaydulin_kt_31_21.Tests
{
    public class GroupTests
    {
        [Fact]
        public void IsValidPosition_Docent_True()
        {
            var testPosition = new Position
            {
                PositionName = "Доцент"
            };

            var result = testPosition.IsValidPositionName();

            Assert.True(result);
        }
    }
}
