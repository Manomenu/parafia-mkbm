namespace parafia_mbkm.test
{
    public class ContactServiceTests
    {
        [Fact]
        public void TrivialTest()
        {
            Assert.Equal(true, true);
        }
        [Fact]
        public void NotTrivialTest()
        {
            Assert.NotEqual(false, true);
        }
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TrivialTestWhatever(bool value)
        {
            Assert.False(false);
        }
        [Theory]
        [InlineData(true)]
        public void TrivialTestValid(bool value)
        {
            Assert.True(value);
        }
    }
}