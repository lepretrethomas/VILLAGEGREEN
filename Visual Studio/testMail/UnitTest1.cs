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
            string resultat = mail.VerificationMail("abc@abc.abc");
            Assert.AreEqual(resultat, "");
        }
        [TestMethod]
        public void a()
        {
            string resultat = mail.VerificationMail("abc_abc.abc");
            Assert.AreEqual(resultat, "Le caractère '@' est manquant.");
        }
        [TestMethod]
        public void b()
        {
            string resultat = mail.VerificationMail("a@abc.abc");
            Assert.AreEqual(resultat, "Deux caractères minimums avant '@'.");
        }
        [TestMethod]
        public void c()
        {
            string resultat = mail.VerificationMail("abc@abc_abc");
            Assert.AreEqual(resultat, "Le caractère '.' est manquant.");
        }
        [TestMethod]
        public void d()
        {
            string resultat = mail.VerificationMail("abc@a.abc");
            Assert.AreEqual(resultat, "Deux caractères minimums avant '.'.");
        }
        [TestMethod]
        public void e()
        {
            string resultat = mail.VerificationMail("abc@abc.a");
            Assert.AreEqual(resultat, "Deux caractères minimums après '.'.");
        }
        [TestMethod]
        public void f()
        {
            string resultat = mail.VerificationMail(".bc@abc.abc");
            Assert.AreEqual(resultat, "Caractères avant '@' incorrects.");
        }
        [TestMethod]
        public void g()
        {
            string resultat = mail.VerificationMail("a.c@abc.abc");
            Assert.AreEqual(resultat, "");
        }
        [TestMethod]
        public void h()
        {
            string resultat = mail.VerificationMail("abc@a_c.abc");
            Assert.AreEqual(resultat, "Caractères entre '@' et '.' incorrects.");
        }
        [TestMethod]
        public void i()
        {
            string resultat = mail.VerificationMail("abc@abc.a_c");
            Assert.AreEqual(resultat, "Caractères après le '.' incorrects.");
        }
    }
}

