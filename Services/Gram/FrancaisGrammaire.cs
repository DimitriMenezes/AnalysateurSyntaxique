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
            var verbInfinitive = "";// ReadJson();

            this.grammarString = @"
                <mot> ::= (<Letter>)
                <article-def-les> ::= 'les'
                <article-def-la> ::= 'la'
                <article-def-le> ::= 'le'
                <et> ::= 'et'
                <pronom-personnel-je> ::= 'je' | 'Je' | 'J' | 'j'
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
                <sujet> ::= <sujet-simple> | <sujet-composé> | <sujet> ', ' <sujet> | <sujet> ' ' <et> ' ' <sujet>

	            <conjugaison-primeire-personne-singulier-present> ::= 'suis' | 'ai'
	            <conjugaison-seconde-personne-singulier-present> ::= 'es' | 'a' | 'née'
	            <conjugaison-troisienne-personne-singulier-present> ::= 'est' | 'as'
	            <conjugaison-premiere-personne-pluriel-present> ::= 'sommes' | 'avons'
	            <conjugaison-seconde-personne-pluriel-present> ::= 'êtes' | 'avez'
	            <conjugaison-troisienne-personne-pluriel-present> ::= 'sont' | 'ont'
                <conjugaison-singulier-present> ::= <pronom-personnel-je> <conjugaison-primeire-personne-singulier-present>
                                                | <pronom-personnel-tu> <conjugaison-seconde-personne-singulier-present>
                                                | <pronom-personnel-il> <conjugaison-troisienne-personne-singulier-present>
                                                | <pronom-personnel-elle> <conjugaison-troisienne-personne-singulier-present>
                                                | <pronom-personnel-on> <conjugaison-troisienne-personne-singulier-present>
                                                | <pronom-personnel-nous> <conjugaison-premiere-personne-pluriel-present>
                                                | <pronom-personnel-vous> <conjugaison-seconde-personne-pluriel-present>	
		                                        | <pronom-personnel-ils> <conjugaison-troisienne-personne-pluriel-present>
                                                | <pronom-personnel-elles> <conjugaison-troisienne-personne-pluriel-present>
            
                <participe_passé> ::= 'née'
                <participe-passé-masculin-sing> ::= 'né' | 'allé' | 'venu'
                <participe-passé-feminin-sing> ::= 'née' | 'allée' | 'venue'               
                <participe-passé-masculin-plur> ::= 'nés'  | 'allés' | 'venus'
                <participe-passé-feminin-plur> ::= 'nées'  | 'allés' | 'venues'                
                
                <participe-passé-avoir> ::= 'eu' |'écrit' | 'pris' | 'fait'                           

                <verb-etre-prem-pers-sing> ::= 'suis'
                <verb-etre-sec-pers-sing> ::= 'es'
                <verb-etre-troi-pers-sing> ::= 'est'
                <verb-etre-prem-pers-plur> ::= 'sommes'
                <verb-etre-sec-pers-plur> ::= 'êtes'
                <verb-etre-troi-pers-plur> ::= 'sont'

                <verb-avoir-prem-pers-sing> ::= 'ai'
                <verb-avoir-sec-pers-sing> ::= 'as'
                <verb-avoir-troi-pers-sing> ::= 'a'
                <verb-avoir-prem-pers-plur> ::= 'avons'
                <verb-avoir-sec-pers-plur> ::= 'avez'
                <verb-avoir-troi-pers-plur> ::= 'ont'

                <passé-composé-avoir> ::= <pronom-personnel-je> <verb-avoir-prem-pers-sing> <participe-passé-avoir> 
                                        | <pronom-personnel-tu> <verb-avoir-sec-pers-sing> <participe-passé-avoir>
                                        |(<pronom-personnel-il> | <pronom-personnel-elle> | <pronom-personnel-on>) <verb-avoir-troi-pers-sing> <participe-passé-avoir>
                                        |<pronom-personnel-nous> <verb-avoir-prem-pers-plur> <participe-passé-avoir>
                                        |<pronom-personnel-vous> <verb-avoir-sec-pers-plur> <participe-passé-avoir>
                                        |(<pronom-personnel-ils> | <pronom-personnel-elles>) <verb-avoir-troi-pers-plur> <participe-passé-avoir>

                <passé-composé-etre> ::= <pronom-personnel-je> <verb-etre-prem-pers-sing> <participe-passé-masculin-sing>
                                        | <pronom-personnel-tu> <verb-etre-sec-pers-sing> <participe-passé-masculin-sing>
                                        | <pronom-personnel-il> <verb-etre-troi-pers-sing> <participe-passé-masculin-sing>
                                        | <pronom-personnel-elle> <verb-etre-troi-pers-sing> <participe-passé-feminin-sing>
                                        | <pronom-personnel-nous> <verb-etre-prem-pers-plur> <participe-passé-masculin-plur>
                                        | <pronom-personnel-vous> <verb-etre-sec-pers-plur> <participe-passé-masculin-plur>
                                        | <pronom-personnel-ils> <verb-etre-troi-pers-plur> <participe-passé-masculin-plur>
                                        | <pronom-personnel-ils> <verb-etre-troi-pers-plur> <participe-passé-feminin-plur>

                <passé-composé> ::= <passé-composé-avoir> | <passé-composé-etre>
                <phrase> ::=  <passé-composé> 'D' | <conjugaison-singulier-present> 'D' | '.' | ',' | <et> | <empty> | <EOL>                   
                <start> ::= {<phrase>}
                <grammaire> ::= <start>
            ";
        }

        public AnalyseurModel Analyseur(string text)
        {
            var grammar = new BnfGrammar().Build(this.grammarString, "grammaire");

            var result = grammar.Match(text);

            return new AnalyseurModel() { Sucess = result.Success, Data = result.ErrorMessage };           
        }


        public string ReadJson()
        {
            var sb = new System.Text.StringBuilder();
           
            var myJsonString = File.ReadAllText("../Services/Json/verbs-infinitive.json");
            var myJObject = JObject.Parse(myJsonString);
            var fisrtGroup = myJObject["verbs"]["first_group"];
            var secondGroup = myJObject["verbs"]["second_group"];
            var thirdGroup = myJObject["verbs"]["third_group"];

            sb.Append("<verb-infinitive-premiere-group> ::= ");
            foreach (var verb in fisrtGroup)
            {
                sb.Append("'" + verb + "'");
                if (verb.Next != null)
                    sb.Append(" | ");                
            }
            sb.AppendLine();
            sb.Append("<verb-infinitive-second-group> ::= ");
            foreach (var verb in secondGroup)
            {
                sb.Append("'" + verb + "'");
                if (verb.Next != null)
                    sb.Append(" | ");
            }
            sb.AppendLine();
            sb.Append("<verb-infinitive-troisiene-group> ::= ");
            foreach (var verb in thirdGroup)
            {
                sb.Append("'" + verb + "'");
                if (verb.Next != null)
                    sb.Append(" | ");
            }
            sb.AppendLine();
            sb.Append("<verb-infinitive> ::= <verb-infinitive-premiere-group> | <verb-infinitive-second-group> | <verb-infinitive-troisiene-group>");
            return sb.ToString();
        }
    }
}
