using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoveLib;
using MoveLib.BAC;
using MoveLib.BAC.Types;
using MoveLib.BCH;
using MoveLib.BCM;
using MoveLib.Util;
using Newtonsoft.Json;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        public const string BAC_NAME            = "BAC_NCL.uasset";
        public const string ORIGINAL_BAC_PATH   = @"Originals\BAC\" + BAC_NAME;
        public const string CONVERTED_BAC_PATH  = @"Converted\BAC\" + BAC_NAME;


        [TestMethod]
        public void OldModifiedBACJson_ShouldReadOldNames()
        {
            var filePath = "Test Files/BAC_RYU.json";

            try
            {
                var isBacSuccessful = BACConverter.JsonToBac(filePath, "fileOutput (unused in test)");

                Assert.IsTrue(isBacSuccessful);
            }
            catch (System.Exception e)
            {
                Debug.WriteLine("Caught exception:\n" + e.Message);
            }
        }

        /// <summary>
        /// The result of converting a BAC to JSON to BAC should be identical to the original BAC.
        /// </summary>
        [TestMethod]
        public void UnmodifiedBAC_ShouldNotDifferFromOriginal()
        {
            // verify that the files are in the right place for the test to proceed correctly
            Assert.IsTrue(File.Exists(ORIGINAL_BAC_PATH));


            /* Given */

            var originalFileBytes = File.ReadAllBytes(ORIGINAL_BAC_PATH);



            /* When */
            var convertedBac = BACConverter.FromUassetFile(ORIGINAL_BAC_PATH);
            BACConverter.ToUassetFile(convertedBac, CONVERTED_BAC_PATH);

            /* Then */
            var convertedFileBytes = File.ReadAllBytes(CONVERTED_BAC_PATH);
            Assert.IsTrue(Enumerable.SequenceEqual(originalFileBytes, convertedFileBytes));
        }
        
        [TestMethod]
        public void NegativeZeros_ShouldRetainSign()
        {
            // given
            //var originalFileBytes = File.ReadAllBytes(ORIGINAL_BAC_PATH);
            //var convertedBac = BACConverter.FromUassetFile(ORIGINAL_BAC_PATH);
            var hurtbox = new Hurtbox
            {
                Y = -0.0f
            };

            Assert.IsTrue(1 / hurtbox.Y < 0); // check that it's actually -0  (1/-0 = -infinity, 1/0=infinity)

            // when
            var json = JsonConvert.SerializeObject(hurtbox);
            var convertedHurtbox = JsonConvert.DeserializeObject<Hurtbox>(json, new NegativeZeroConverter());

            // then
            Assert.IsTrue(1 / convertedHurtbox.Y < 0);
        }

        /*
        To use these tests you will need to put some, or all, the 
        BAC/BCM/BCH (uasset) files in the correct folder (UnitTest/Bin/Debug/Originals/...)
        */

        [TestMethod]
        public void TestBAC()
        {
            /*
            Not correct length: BAC_B59
            Bytes does not match up: BAC_CMN Position: 21C Original was: 0 Created was: 1C
            Not correct length: BAC_EFE
            */

            List<string> exceptions = new List<string>();

            foreach (var file in Directory.GetFiles(@"Originals", @"BAC_???.uasset"))
            {
                var originalBytes = File.ReadAllBytes(file);
                var bac = BACConverter.FromUassetFile(file);
                BACConverter.ToUassetFile(bac, @"Originals\BAC\testfile.uasset");
                var createdBytes = File.ReadAllBytes(@"Originals\BAC\testfile.uasset");
                bool isCorrectLength = true;

                if (originalBytes.Length != createdBytes.Length)
                {
                    exceptions.Add("Not correct length: " + Path.GetFileNameWithoutExtension(file));
                    isCorrectLength = false;
                }

                if (isCorrectLength)
                {
                    for (int i = 0; i < originalBytes.Length; i++)
                    {
                        if (originalBytes[i] != createdBytes[i])
                        {
                            exceptions.Add("Bytes does not match up: " + Path.GetFileNameWithoutExtension(file) +
                                           " Position: " + i.ToString("X") + " Original was: " +
                                           originalBytes[i].ToString("X") + " Created was: " +
                                           createdBytes[i].ToString("X"));
                        }
                    }
                }
            }

            File.Delete(@"Originals\BAC\testfile.uasset");

            foreach (var exception in exceptions)
            {
                Debug.WriteLine(exception);
            }

            if (exceptions.Count > 0)
            {
                var output = "";
                foreach (var exception in exceptions)
                {
                    output += exception + "\n";
                }

                Assert.Fail("Test failed, found exceptions:\n" + output);
            }
        }

        [TestMethod]
        public void TestBACeff()
        {
            foreach (var file in Directory.GetFiles(@"Originals", @"BAC_???_eff.uasset"))
            {
                var originalBytes = File.ReadAllBytes(file);
                var bac = BACConverter.FromUassetFile(file);
                BACConverter.ToUassetFile(bac, @"Originals\BACeff\testfile.uasset");
                var createdBytes = File.ReadAllBytes(@"Originals\BACeff\testfile.uasset");

                Assert.AreEqual(originalBytes.Length, createdBytes.Length);

                for (int i = 0; i < originalBytes.Length; i++)
                {
                    Assert.AreEqual(originalBytes[i], createdBytes[i]);
                }
            }

            File.Delete(@"Originals\BACeff\testfile.uasset");
        }

        [TestMethod]
        public void TestBCM()
        {
            foreach (var file in Directory.GetFiles(@"Originals", @"BCM*"))
            {
                var originalBytes = File.ReadAllBytes(file);
                var bcm = BCMConverter.FromUassetFile(file);
                BCMConverter.ToUassetFile(bcm, @"Originals\BCM\testfile.uasset");
                var createdBytes = File.ReadAllBytes(@"Originals\BCM\testfile.uasset");

                Assert.AreEqual(originalBytes.Length, createdBytes.Length);

                for (int i = 0; i < originalBytes.Length; i++)
                {
                    Assert.AreEqual(originalBytes[i], createdBytes[i]);
                }
            }

            File.Delete(@"Originals\BCM\testfile.uasset");
        }

        [TestMethod]
        public void TestBCH()
        {
            foreach (var file in Directory.GetFiles(@"Originals\BCH"))
            {
                var originalBytes = File.ReadAllBytes(file);
                var bch = BCHConverter.FromUassetFile(file);
                BCHConverter.ToUassetFile(bch, @"Originals\BCH\testfile.uasset");
                var createdBytes = File.ReadAllBytes(@"Originals\BCH\testfile.uasset");

                Assert.AreEqual(originalBytes.Length, createdBytes.Length);

                for (int i = 0; i < originalBytes.Length; i++)
                {
                    Assert.AreEqual(originalBytes[i], createdBytes[i]);
                }
            }

            File.Delete(@"Originals\BCH\testfile.uasset");
        }
    }
}
