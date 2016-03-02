using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mail;

namespace testMail
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ok()
        {
            string resultat = mail.Verification("abc@abc.abc");
            Assert.AreEqual(resultat, "");
        }
        [TestMethod]
        public void a()
        {
            string resultat = mail.Verification("abc_abc.abc");
            Assert.AreEqual(resultat, "Le caractère '@' est manquant.");
        }
        [TestMethod]
        public void b()
        {
            string resultat = mail.Verification("a@abc.abc");
            Assert.AreEqual(resultat, "Deux caractères minimums avant '@'.");
        }
        [TestMethod]
        public void c()
        {
            string resultat = mail.Verification("abc@a");
            Assert.AreEqual(resultat, "Deux caractères minimums après '@'.");
        }
        [TestMethod]
        public void d()
        {
            string resultat = mail.Verification("abc@abc_abc");
            Assert.AreEqual(resultat, "Le caractère '.' est manquant.");
        }
        [TestMethod]
        public void e()
        {
            string resultat = mail.Verification("abc@a.abc");
            Assert.AreEqual(resultat, "Deux caractères minimums avant '.'.");
        }
        [TestMethod]
        public void f()
        {
            string resultat = mail.Verification("abc@abc.a");
            Assert.AreEqual(resultat, "Deux caractères minimums après '.'.");
        }
    }
}

