using Eto.Parse;
using Eto.Parse.Grammars;
using Eto.Parse.Parsers;
using Services.Model;
using System.Collections.Generic;

namespace Services.Gram
{
    public class FrancaisGrammaire : Grammar
    {
        private string grammarString { get; set; }

        public FrancaisGrammaire()
        {     
            this.grammarString = @"                
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
    
                <passé-composé> ::= <conjugaison-singulier-present> <participe_passé>

                <phrase> ::= <passé-composé> 
                        | <conjugaison-singulier-present>
                        | <phrase>    
                        | ' ' <et> ' ' <phrase>
                        | ', ' <phrase> 
                        | <phrase> '. ' 
                        | '.'
                        

                <start> ::= <phrase> | <start> | <empty>
                <grammaire> ::= <start>
            ";
        }

        public AnalyseurModel Analyseur(string text)
        {
            var grammar = new BnfGrammar().Build(this.grammarString, "grammaire");

            var result = grammar.Match(text);

            return new AnalyseurModel() { Sucess = result.Success, Data = result.ErrorMessage };           
        }
    }
}
