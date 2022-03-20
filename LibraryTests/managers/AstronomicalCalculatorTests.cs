﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Genso.Astrology.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genso.Astrology.Library.Tests
{
    [TestClass()]
    public class AstronomicalCalculatorTests
    {
        [TestMethod()]
        public void GetPlanetRasiSignTest()
        {
            var endStdTime = DateTimeOffset.ParseExact("06:42 16/04/2021 +08:00", Time.GetDateTimeFormat(), null);
            var geoLocation = new GeoLocation("Ipoh", 101, 4.59);
            var birthTime = new Time(endStdTime, geoLocation);


            AstronomicalCalculator.GetPlanetRasiSign(PlanetName.Mercury, birthTime);
        }

        [TestMethod()]
        public void CountFromSignToSignTest()
        {
            //test
            var count = AstronomicalCalculator.CountFromSignToSign(ZodiacName.Aquarius, ZodiacName.Taurus);

            //correct result is 4
            Assert.IsTrue(count == 4);

        }


        [TestMethod()]
        public void GetLongitudeAtZodiacSignTest()
        {
            //TEST 190 = 10 in Libra
            var libra10 = new ZodiacSign(ZodiacName.Libra, Angle.FromDegrees(10));
            var longitude = AstronomicalCalculator.GetLongitudeAtZodiacSign(libra10);
            var testSign = AstronomicalCalculator.GetZodiacSignAtLongitude(longitude);

            var expected = libra10.GetDegreesInSign().TotalDegrees;
            var actual = testSign.GetDegreesInSign().TotalDegrees;

            Assert.AreEqual(expected, actual);
        }
    }
}