using Eto.Parse;
using Eto.Parse.Grammars;
using Eto.Parse.Parsers;
using Newtonsoft.Json.Linq;
using Services.Model;
using System.Collections.Generic;
using System.IO;

namespace Services.Gram
{
    public class FrancaisGrammaire : Grammar
    {
        private string grammarString { get; set; }

        public FrancaisGrammaire()
        {
            var verbInfinitive = ReadJson();
            var alfabet = Alphabet();

            this.grammarString = string.Concat(verbInfinitive) + @"
                <mot>::=     {'A'|'a'|'B'|'b'|'C'|'c'|'D'|'d'|'E'|'e'|'F'|'f'
                |'G'|'g'|'H'|'h'|'I'|'i'|'J'|'j'|'K'|'k'|'L'|'l'
                |'M'|'m'|'N'|'n'|'O'|'o'|'P'|'p'|'Q'|'q'|'R'|'r'
                |'S'|'s'|'T'|'t'|'U'|'u'|'V'|'v'|'W'|'w'|'X'|'x'
                |'Y'|'y'|'Z'|'z'
                |'À' | 'à' | 'Â' | 'â' | 'Æ' | 'æ' | 'Ç' | 'ç' 
                | 'É' | 'é' | 'È' | 'è' | 'Ê' | 'ê' | 'Ë' | 'ë'
                | 'Î' | 'î' | 'Ï' | 'ï' | 'Ô' | 'ô' | 'Œ' | 'œ' 
                | 'Ù' | 'ù' | 'Û' | 'û' | 'Ü' | 'ü' | 'Ÿ' | 'ÿ'}

                <article-def-les> ::= 'les'
                <article-def-la> ::= 'la'
                <article-def-le> ::= 'le'
                <article-def-l> ::= 'l`'
                <et> ::= 'et'
                <pronom-personnel-je> ::= 'je' | 'Je' | 'J`' | 'j`'
                <pronom-personnel-tu> ::= 'Tu' | 'tu'
                <pronom-personnel-il> ::= 'Il' | 'il'
                <pronom-personnel-elle> ::= 'Elle' | 'elle'
                <pronom-personnel-on> ::= 'On' | 'on'
                <pronom-personnel-nous> ::= 'Nous' | 'nous'
                <pronom-personnel-vous> ::= 'Vous' | 'vous'
                <pronom-personnel-elles> ::= 'Elles' | 'elles'
                <pronom-personnel-ils> ::= 'Ils' | 'ils'

                <pronom-possesif-mon> ::= 'mon'
                <pronom-possesif-ma> ::= 'ma' 
                <pronom-possesif-mes> ::= 'mes'
                <pronom-possesif-ton> ::= 'ton'
                <pronom-possesif-ta> ::= 'ta'
                <pronom-possesif-tes> ::= 'tes'
                <pronom-possesif-votre> ::= 'votre'
                <pronom-possesif-vos> ::= 'vos'
                <pronom-possesif-notre> ::= 'notre'
                <pronom-possesif-nos> ::= 'nos'
                <pronom-possesif-leur> ::= 'leur'
                <pronom-possesif-leurs> ::= 'leurs'
                
                <pronom-personnel-singulier> ::= <pronom-personnel-je> 
                                            | <pronom-personnel-tu> 
                                            | <pronom-personnel-il> 
                                            | <pronom-personnel-elle>
                <pronom-personnel-pluriel> ::= <pronom-personnel-on> 
                                            | <pronom-personnel-nous> 
                                            | <pronom-personnel-vous> 
                                            | <pronom-personnel-elles> 
                                            | <pronom-personnel-ils>
                <sujet-simple> ::= <pronom-personnel-singulier>
                <sujet-composé> ::= <pronom-personnel-pluriel>
                <sujet> ::= <sujet-simple> | <sujet-composé> | <sujet> ',' <sujet> | <sujet> <et> <sujet>

	            <conjugaison-primeire-personne-singulier-present> ::= 'suis' | 'ai'
	            <conjugaison-deuxieme-personne-singulier-present> ::= 'es' | 'a' | 'née'
	            <conjugaison-troisieme-personne-singulier-present> ::= 'est' | 'as'
	            <conjugaison-premiere-personne-pluriel-present> ::= 'sommes' | 'avons'
	            <conjugaison-deuxieme-personne-pluriel-present> ::= 'êtes' | 'avez'
	            <conjugaison-troisieme-personne-pluriel-present> ::= 'sont' | 'ont'
                <conjugaison-singulier-present-posit> ::= <pronom-personnel-je> <conjugaison-primeire-personne-singulier-present> 
                                                | <pronom-personnel-tu> <conjugaison-deuxieme-personne-singulier-present>
                                                | <pronom-personnel-il> <conjugaison-troisieme-personne-singulier-present>
                                                | <pronom-personnel-elle> <conjugaison-troisieme-personne-singulier-present>
                                                | <pronom-personnel-on> <conjugaison-troisieme-personne-singulier-present>
                                                | <pronom-personnel-nous> <conjugaison-premiere-personne-pluriel-present>
                                                | <pronom-personnel-vous> <conjugaison-deuxieme-personne-pluriel-present>	
		                                        | <pronom-personnel-ils> <conjugaison-troisieme-personne-pluriel-present>
                                                | <pronom-personnel-elles> <conjugaison-troisieme-personne-pluriel-present>

                <conjugaison-singulier-present-negat> ::= <pronom-personnel-je> 'ne' <conjugaison-primeire-personne-singulier-present> ('pas' | <empty>)
                                                | <pronom-personnel-tu> ('ne' | 'n`') <conjugaison-deuxieme-personne-singulier-present> 'pas'
                                                | <pronom-personnel-il> 'ne' <conjugaison-troisieme-personne-singulier-present> 'pas'
                                                | <pronom-personnel-elle> 'ne' <conjugaison-troisieme-personne-singulier-present> 'pas'
                                                | <pronom-personnel-on> 'ne' <conjugaison-troisieme-personne-singulier-present> 'pas'
                                                | <pronom-personnel-nous> 'ne' <conjugaison-premiere-personne-pluriel-present> 'pas'
                                                | <pronom-personnel-vous> 'ne' <conjugaison-deuxieme-personne-pluriel-present> 'pas'
		                                        | <pronom-personnel-ils> 'ne' <conjugaison-troisieme-personne-pluriel-present> 'pas'
                                                | <pronom-personnel-elles> 'ne' <conjugaison-troisieme-personne-pluriel-present> 'pas'
              
                <participe-passé-masculin-sing> ::= 'né' | 'allé' | 'venu'
                <participe-passé-feminin-sing> ::= 'née' | 'allée' | 'venue'               
                <participe-passé-masculin-plur> ::= 'nés'  | 'allés' | 'venus'
                <participe-passé-feminin-plur> ::= 'nées'  | 'allés' | 'venues'                
                
                <participe-passé-avoir> ::= 'eu' |'écrit' | 'pris' | 'fait'                           

                <verb-etre-prem-pers-sing> ::= 'suis'
                <verb-etre-deux-pers-sing> ::= 'es'
                <verb-etre-troi-pers-sing> ::= 'est'
                <verb-etre-prem-pers-plur> ::= 'sommes'
                <verb-etre-deux-pers-plur> ::= 'êtes'
                <verb-etre-troi-pers-plur> ::= 'sont'

                <verb-avoir-prem-pers-sing> ::= 'ai'
                <verb-avoir-deux-pers-sing> ::= 'as'
                <verb-avoir-troi-pers-sing> ::= 'a'
                <verb-avoir-prem-pers-plur> ::= 'avons'
                <verb-avoir-deux-pers-plur> ::= 'avez'
                <verb-avoir-troi-pers-plur> ::= 'ont'

                <passé-composé-avoir> ::= <pronom-personnel-je> <verb-avoir-prem-pers-sing> <participe-passé-avoir> 
                                        | <pronom-personnel-tu> <verb-avoir-deux-pers-sing> <participe-passé-avoir>
                                        |(<pronom-personnel-il> | <pronom-personnel-elle> | <pronom-personnel-on>) <verb-avoir-troi-pers-sing> <participe-passé-avoir>
                                        |<pronom-personnel-nous> <verb-avoir-prem-pers-plur> <participe-passé-avoir>
                                        |<pronom-personnel-vous> <verb-avoir-deux-pers-plur> <participe-passé-avoir>
                                        |(<pronom-personnel-ils> | <pronom-personnel-elles>) <verb-avoir-troi-pers-plur> <participe-passé-avoir>

                <passé-composé-etre> ::= <pronom-personnel-je> <verb-etre-prem-pers-sing> (<participe-passé-feminin-sing>|<participe-passé-masculin-sing>)
                                        | <pronom-personnel-tu> <verb-etre-deux-pers-sing> (<participe-passé-feminin-sing>|<participe-passé-masculin-sing>)
                                        | <pronom-personnel-il> <verb-etre-troi-pers-sing> <participe-passé-masculin-sing>
                                        | <pronom-personnel-elle> <verb-etre-troi-pers-sing> <participe-passé-feminin-sing>
                                        | <pronom-personnel-on> <verb-etre-deux-pers-sing> (<participe-passé-feminin-sing>|<participe-passé-masculin-sing>) 
                                        | <pronom-personnel-nous> <verb-etre-prem-pers-plur> (<participe-passé-feminin-plur> |<participe-passé-masculin-plur>)
                                        | <pronom-personnel-vous> <verb-etre-deux-pers-plur> (<participe-passé-feminin-plur> |<participe-passé-masculin-plur>)
                                        | <pronom-personnel-ils> <verb-etre-troi-pers-plur> <participe-passé-masculin-plur>
                                        | <pronom-personnel-ils> <verb-etre-troi-pers-plur> <participe-passé-feminin-plur>
                
                <conjugaison-venir-premiere-person-sing> ::= 'viens'
                <conjugaison-venir-deuxieme-person-sing> ::= 'viens'
                <conjugaison-venir-troisieme-person-sing> ::= 'vient'
                <conjugaison-venir-premiere-person-plur> ::= 'venons'
                <conjugaison-venir-deuxieme-person-plur> ::= 'venez'
                <conjugaison-venir-troisieme-person-plur> ::= 'viennent'

                <passé-recent> ::= <pronom-personnel-je> <conjugaison-venir-premiere-person-sing> 'de' <verb-infinitive-consonne> 
                                 | <pronom-personnel-je> <conjugaison-venir-premiere-person-sing>  'd`' <verb-infinitive-vowel>                                

                <passé-composé> ::= <passé-composé-avoir> | <passé-composé-etre>
                <phrase> ::=  <passé-recent> <mot> (',' | '.')
                            | <passé-composé> <mot> (',' | '.')
                            | <conjugaison-singulier-present-posit> <mot> (',' | '.')
                            | <conjugaison-singulier-present-negat> <mot> (',' | '.')                           

                <text> ::= {<phrase>}
                <start> ::= <text>            
                <grammaire> ::= <start>
            ";
        }

        private string Alphabet()
        {
            return @"<letter>::=    'A'|'a'|'B'|'b'|'C'|'c'|'D'|'d'|'E'|'e'|'F'|'f'
                                    |'G'|'g'|'H'|'h'|'I'|'i'|'J'|'j'|'K'|'k'|'L'|'l'
                                    |'M'|'m'|'N'|'n'|'O'|'o'|'P'|'p'|'Q'|'q'|'R'|'r'
                                    |'S'|'s'|'T'|'t'|'U'|'u'|'V'|'v'|'W'|'w'|'X'|'x'
                                    |'Y'|'y'|'Z'|'z'
                                    |'À' | 'à' | 'Â' | 'â' | 'Æ' | 'æ' | 'Ç' | 'ç' 
                                    | 'É' | 'é' | 'È' | 'è' | 'Ê' | 'ê' | 'Ë' | 'ë'
                                    | 'Î' | 'î' | 'Ï' | 'ï' | 'Ô' | 'ô' | 'Œ' | 'œ' 
                                    | 'Ù' | 'ù' | 'Û' | 'û' | 'Ü' | 'ü' | 'Ÿ' | 'ÿ'

                    <mot>::=     {'A'|'a'|'B'|'b'|'C'|'c'|'D'|'d'|'E'|'e'|'F'|'f'
                                    |'G'|'g'|'H'|'h'|'I'|'i'|'J'|'j'|'K'|'k'|'L'|'l'
                                    |'M'|'m'|'N'|'n'|'O'|'o'|'P'|'p'|'Q'|'q'|'R'|'r'
                                    |'S'|'s'|'T'|'t'|'U'|'u'|'V'|'v'|'W'|'w'|'X'|'x'
                                    |'Y'|'y'|'Z'|'z'
                                    |'À' | 'à' | 'Â' | 'â' | 'Æ' | 'æ' | 'Ç' | 'ç' 
                                    | 'É' | 'é' | 'È' | 'è' | 'Ê' | 'ê' | 'Ë' | 'ë'
                                    | 'Î' | 'î' | 'Ï' | 'ï' | 'Ô' | 'ô' | 'Œ' | 'œ' 
                                    | 'Ù' | 'ù' | 'Û' | 'û' | 'Ü' | 'ü' | 'Ÿ' | 'ÿ'}";
        }

        public AnalyseurModel Analyseur(string text)
        {
            text = FilterString(text);
            var grammar = new BnfGrammar();
            var grammarBuilt = grammar.Build(this.grammarString, "grammaire");
            grammarBuilt.CaseSensitive = false;

            var result = grammarBuilt.Match(text);

            return new AnalyseurModel() { Sucess = result.Success, Data = result.ErrorMessage };           
        }

        private string FilterString(string grammar)
        {
            return grammar.Replace("'", "`");
        }


        public string ReadJson()
        {
            var sb = new System.Text.StringBuilder();
           
            var myJsonString = File.ReadAllText("../Services/Json/verbs-infinitive.json");
            var myJObject = JObject.Parse(myJsonString);
            var verbPronominauxVowel = myJObject["verbs"]["proniminaux"]["vowel"];
            var verbPronominauxConsonne = myJObject["verbs"]["proniminaux"]["consonne"];
            var fisrtGroupVowel = myJObject["verbs"]["premier_group"]["vowel"];
            var fisrtGroupConsonne = myJObject["verbs"]["premier_group"]["consonne"];
            var secondGroupVowel = myJObject["verbs"]["deuxieme_group"]["vowel"];
            var secondGroupConsonne = myJObject["verbs"]["deuxieme_group"]["consonne"];
            var thirdGroupVowel = myJObject["verbs"]["troisieme_group"]["vowel"];
            var thirdGroupConsonne = myJObject["verbs"]["troisieme_group"]["consonne"];

            #region VERB INFINITIVE PRONOMINAUX
            sb.Append("<verb-infinitive-pronominaux-vowel> ::= ");
            foreach (var verb in verbPronominauxVowel)
            {
                sb.Append("'" + verb + "'");
                if (verb.Next != null)
                    sb.Append(" | ");
            }
            sb.AppendLine();

            sb.Append("<verb-infinitive-pronominaux-consonne> ::= ");
            foreach (var verb in verbPronominauxConsonne)
            {
                sb.Append("'" + verb + "'");
                if (verb.Next != null)
                    sb.Append(" | ");
            }
            sb.AppendLine();
            #endregion

            #region VERB INFINITIVE PREMIER GROUP
            sb.Append("<verb-infinitive-premiere-group-vowel> ::= ");
            foreach (var verb in fisrtGroupVowel)
            {
                sb.Append("'" + verb + "'");
                if (verb.Next != null)
                    sb.Append(" | ");                
            }
            sb.AppendLine();

            sb.Append("<verb-infinitive-premiere-group-consonne> ::= ");
            foreach (var verb in fisrtGroupConsonne)
            {
                sb.Append("'" + verb + "'");
                if (verb.Next != null)
                    sb.Append(" | ");
            }
            sb.AppendLine();
            #endregion

            #region VERB INFINITIVE DEUXIEME GROUP
            sb.Append("<verb-infinitive-deuxieme-group-vowel> ::= ");
            foreach (var verb in secondGroupVowel)
            {
                sb.Append("'" + verb + "'");
                if (verb.Next != null)
                    sb.Append(" | ");
            }
            sb.AppendLine();

            sb.Append("<verb-infinitive-deuxieme-group-consonne> ::= ");
            foreach (var verb in secondGroupConsonne)
            {
                sb.Append("'" + verb + "'");
                if (verb.Next != null)
                    sb.Append(" | ");
            }
            sb.AppendLine();
            #endregion

            #region VERB INFINITIVE TROISIEME GROUP
            sb.Append("<verb-infinitive-troisieme-group-vowel> ::= ");
            foreach (var verb in thirdGroupVowel)
            {
                sb.Append("'" + verb + "'");
                if (verb.Next != null)
                    sb.Append(" | ");
            }
            sb.AppendLine();

            sb.Append("<verb-infinitive-troisieme-group-consonne> ::= ");
            foreach (var verb in thirdGroupConsonne)
            {
                sb.Append("'" + verb + "'");
                if (verb.Next != null)
                    sb.Append(" | ");
            }
            sb.AppendLine();
            #endregion


            sb.Append("<verb-infinitive-vowel> ::= <verb-infinitive-premiere-group-vowel> | <verb-infinitive-deuxieme-group-vowel> | <verb-infinitive-troisieme-group-vowel> | <verb-infinitive-pronominaux-vowel>");
            sb.AppendLine();
            sb.Append("<verb-infinitive-consonne> ::= <verb-infinitive-premiere-group-consonne> | <verb-infinitive-deuxieme-group-consonne> | <verb-infinitive-troisieme-group-consonne> | <verb-infinitive-pronominaux-consonne>");
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
