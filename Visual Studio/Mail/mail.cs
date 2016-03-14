using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Mail
{
    /// <summary>
    /// Classe
    /// </summary>
    public partial class mail : Form
    {
        /// <summary>
        /// Initialisation de la fenêtre
        /// </summary>
        /// <returns></returns>
        public mail()
        {
            InitializeComponent();
        }
//Codez une fonction qui vérifie que l’adresse mail fournie est cohérente.
//En entrée, cette fonction reçoit l’adresse à vérifier.
//On considère qu’une adresse email est correcte si elle contient @, et au moins un
//point dans la partie qui suit @.
//Le partie devant @ doit faire au moins deux caractères, entre @ et le point au
//moins deux caractères et après le point au moins deux caractères.
//La fonction renvoie une chaîne de caractère vide si l’adresse est correcte, ou
//contenant l’erreur détectée si l’adresse n’est pas cohérente.
//Votre fonction doit être documentée en utilisant les règles en vigueur dans votre
//IDE.
//La fonction doit être testée par le framework de tests unitaires
        /// <summary>
        /// Evenement sur le clique du bouton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_check_Click(object sender, EventArgs e)
        {
            //Vérififcation que le champ texte a bien été rempli
            if (textBox1.Text == "")
            {
                label4.Text = "Le champ texte est vide...";
            }
            else
            {
                //Analyse de la saisie avec la fonction VerificationMail
                label4.Text = VerificationMail(textBox1.Text);
            }
        }
        /// <summary>
        /// Fonction qui vérifie la cohérence de l'adresse email
        /// </summary>
        /// <param name="email">adresse email saisie</param>
        /// <returns></returns>
        public static string VerificationMail(string email)
        {
            //email = partieA + '@' + partieB
            //partieB = elementA + '.' + elementB
            //En premier, vérification du nombre de caractères.
            //En second, vérification des types de caractères.
            string resultat = "x";
            try
            {
                //IndexOf recherche la présence de '@' et retourne sa position
                int a = email.IndexOf("@");
                if (a == -1)
                {
                    //Si IndexOf retourne la position -1, le caractère n'a pas été trouvé
                    resultat = "Le caractère '@' est manquant.";
                }
                else
                {
                    //Première division, PartieA et PartieB
                    string partieA = email.Substring(0, a); //chaîne de caractère avant '@'
                    string partieB = email.Substring(a + 1); //chaîne de caractère après '@'
                    //Vérification du nombre de caractère avant '@' (minimum 2)
                    if (partieA.Length < 2)
                    {

                        resultat = "Deux caractères minimums avant '@'.";
                    }
                    else
                    {
                        //IndexOf recherche la présence du '.' et retourne sa position
                        int p = partieB.IndexOf(".");
                        if (p == -1)
                        {
                            //Si IndexOf retourne la position -1, le caractère n'a pas été trouvé
                            resultat = "Le caractère '.' est manquant.";
                        }
                        else
                        {
                            //Deuxième division, PartieA et PartieB
                            string elementA = partieB.Substring(0, p); //chaîne de caractère avant '.'
                            string elementB = partieB.Substring(p + 1); //chaîne de caractère après '.'
                            //Vérification du nombre de caractère avant '.' (minimum 2)
                            if (elementA.Length < 2)
                            {
                                resultat = "Deux caractères minimums avant '.'.";
                            }
                            //Vérification du nombre de caractère après '.' (minimum 2)
                            else if (elementB.Length < 2)
                            {
                                resultat = "Deux caractères minimums après '.'.";
                            }
                            else
                            {
                                //Vérification du contenu des différentes parties
                                if (Regex.IsMatch(partieA, @"^[A-Za-z0-9][\w-.]{2,}$") == false)
                                //Premier caractère alphanumerique [A-Za-z0-9]. Accepte le".", le"_" et le "-" à partir du deuxième caractère
                                {
                                    resultat = "Caractères avant '@' incorrects.";
                                }
                                else if (Regex.IsMatch(elementA, @"^[A-Za-z0-9-]{2,}$") == false)
                                //Caractère alphanumerique [A-Za-z0-9]. Accepte le "-"
                                {
                                    resultat = "Caractères entre '@' et '.' incorrects.";
                                }
                                else if (Regex.IsMatch(elementB, @"^[A-Za-z]{2,}") == false)
                                //Caractère alphanumerique [A-Za-z0-9]
                                {
                                    resultat = "Caractères après le '.' incorrects.";
                                }
                                else
                                //Chaîne de caractères en cas de succès
                                {
                                    resultat = "";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                //Message en cas d'erreur
                MessageBox.Show("Un problème est survenu", "Echec");
            }
            //Retourne le résultat
            return resultat;
        }
    }
}
