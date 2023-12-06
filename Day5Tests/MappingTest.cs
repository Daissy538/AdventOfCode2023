using Day5;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5Tests
{
    public class MappingTest
    {
        [Fact]
        public void Read_Map()
        {
            var maps = new List<string>()
            {
                "583826644 2288418886 120919689",
                "2666741396 3172314277 160907737",
                "416244021 605500997 167582623",
            };

            var sut = new Mapping();

            sut.ReadSoilFertMap(maps);
        }


    }
}
