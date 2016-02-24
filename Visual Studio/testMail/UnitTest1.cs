using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GUI;

namespace testMail
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ok()
        {
            string resultat = GUI.mail.Verification("abc@abc.abc");
            Assert.AreEqual(resultat, "Adresse correcte.");
        }
        [TestMethod]
        public void a()
        {
            string resultat = GUI.mail.Verification("abc_abc.abc");
            Assert.AreEqual(resultat, "Le caractère '@' est manquant.");
        }
        [TestMethod]
        public void b()
        {
            string resultat = GUI.mail.Verification("a@abc.abc");
            Assert.AreEqual(resultat, "Deux caractères minimums avant '@'.");
        }
        [TestMethod]
        public void c()
        {
            string resultat = GUI.mail.Verification("abc@a");
            Assert.AreEqual(resultat, "Deux caractères minimums après '@'.");
        }
        [TestMethod]
        public void d()
        {
            string resultat = GUI.mail.Verification("abc@abc_abc");
            Assert.AreEqual(resultat, "Le caractère '.' est manquant.");
        }
        [TestMethod]
        public void e()
        {
            string resultat = GUI.mail.Verification("abc@a.abc");
            Assert.AreEqual(resultat, "Deux caractères minimums avant '.'.");
        }
        [TestMethod]
        public void f()
        {
            string resultat = GUI.mail.Verification("abc@abc.a");
            Assert.AreEqual(resultat, "Deux caractères minimums après '.'.");
        }
    }
}

