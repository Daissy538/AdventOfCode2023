using Day15;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Day15Tests
{
    public class HasherTests
    {
        [Fact]
        public void Determine_ASCII()
        {
            var hasher = new Hasher();
            var result = hasher.ConvertToASCII("H");

            Assert.Equal([72], result);
        }

        [Theory]
        [InlineData("H", 200)]
        [InlineData("HASH", 52)]
        public void Get_Sum_Of_String(string text, int number)
        {
            var hasher = new Hasher();
            var result = hasher.currentValue(text);


            Assert.Equal(number, result);
        }

        [Fact]
        public void Load_From_Sequence()
        {
            var text = "rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7";
            var hasher = new Hasher();
            var result = hasher.currentValue(text);


            Assert.Equal(1320, result);
        }
    }
}