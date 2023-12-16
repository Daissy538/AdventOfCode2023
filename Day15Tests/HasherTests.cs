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
            var result = hasher.CurrentValue(text);


            Assert.Equal(number, result);
        }

        [Fact]
        public void Load_From_Sequence()
        {
            var text = "rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7";
            var hasher = new Hasher();
            var result = hasher.CurrentValue(text);


            Assert.Equal(1320, result);
        }

        [Fact]
        public void Load_Box()
        {
            var text = "rn=1";
            var hasher = new Hasher();
            var result = hasher.ChangeBoxValue(text);

            var lens = new Lens()
            {
                Name = "rn",
            };

            Assert.Equal(1, result[0].Find(lens).Value.Focus);

        }

        [Fact]
        public void Load_Box_Instructions()
        {
            var text = "rn=1,cm-,qp=3";
            var hasher = new Hasher();
            var result = hasher.LoadBoxInstructions(text);

            var lens = new Lens()
            {
                Name = "rn",
            };
            Assert.Equal(1, result[0].Find(lens).Value.Focus);

            lens = new Lens()
            {
                Name = "qp",
            };
            Assert.Equal(3, result[1].Find(lens).Value.Focus);
        }

    }
}