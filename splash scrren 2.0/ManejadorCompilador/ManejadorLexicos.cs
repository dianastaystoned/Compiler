using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using EntidadesCompilador;

namespace ManejadorCompilador
{
    public class ManejadorLexicos //11n + 10(3n+x(n)) + 2(5n) + 3n + 13n = 37n + 10(3n+x(n)) = 37n + 30n + 10x(n) = 67n + 10x(n)
        //Una vez ya hecha la optimización quedo como 58n
    {
        //Arreglos o Expresiones Reservadas
        string[] keywords = { "Begin", "End", "Time", "While" };//n
        string[] reserved = { "int", "double" };//n
        string variable = "^[a-z]*$";//n
        string number = @"^\d+$";//n
        string[] type = { "bomberman", "mario", "pacman", "shadow" };//n
        string[] pattern = { "{" };//n
        string[] pattern2 = { "}" };//n
        string[] equal = {"=", "<=", ">=" };//n
        string[] sign = { "(", ")" };//n
        string[] instruction = { "type", "delay" };//n

        //Método para llenar la lista
        public List<EntidadLexico> Analizar(string text) //3n +x(n)
        {
            List<EntidadLexico> lexico = new List<EntidadLexico>(); //n
            string[] tokens = text.Split(' ', '\r', '\n');//n
            for (int i = 0; i < tokens.Length; i++) //N(x)
            {
                if (!tokens[i].Equals("")) //n=1
                {
                    lexico.Add(new EntidadLexico(i + 1, tokens[i], Metd(tokens[i]), "1"));
                }
            }
            return lexico;//n
        }
        //Método para dar seguimiento en el botón
        public bool AnalisisLexico(DataGridView table, string text) //5n
        {
            table.Columns.Clear(); //n
            table.DataSource = Analizar(text).ToList(); //n
            table.AutoResizeColumns(); //n
            if (table.RowCount > 0) //n(2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Método para obtener la línea (NO FUNCIONA AÚN)
        /*private int CountNewLines(string text)
        {
            foreach (char c in text)
            {
                if (c == '\r' | c == '\n') 
                {
                    line++;
                }
            }
            return line;
        }*/
        #region Métodos sin aplicar la recursividad.
        //Método para identificar las Palabras reservadas ("start", "end", "time", "while")
        /*public string Keyword(string text) //3n+x(n)
        {
            string answer = ""; //n
            for (int i = 0; i < keywords.Length; i++) //N(x)
            {
                if (text.Equals(keywords[i]))//n=1
                {
                    answer = "Palabra reservada";
                }
            }
            return answer; //n
        }
        //Método para identificar los Tipos de dato (int)
        public string Reserved(string text) //3n+x(n)
        {
            string answer = "";
            for (int i = 0; i < reserved.Length; i++)
            {
                if (text.Contains(reserved[i]))
                {
                    answer = "Tipo de dato";
                }
            }
            return answer;
        }
        //Método para identificar los Signos(=)
        public string Equal(string text) //3n+x(n)
        {
            string answer = "";
            for (int i = 0; i < equal.Length; i++)
            {
                if (text.Contains(equal[i]))
                {
                    answer = "Comparador";
                }
            }
            return answer;
        }
        //Método para identificar los Parentesis ( () )
        public string Sing(string text) //3n+x(n)
        {
            string answer = "";
            for (int i = 0; i < sign.Length; i++)
            {
                if (text.Contains(sign[i]))
                {
                    answer = "Parentesis";
                }
            }
            return answer;
        }
        //Método para identificar las Variables
        public string Variable(string text) //3n+x(n)
        {
            string answer = "";
            for (int i = 0; i < variable.Length; i++)
            {
                if (text.Contains(variable[i]))
                {
                    answer = "Identificador";
                }
            }
            return answer;
        }
        //Método para identificar los Valores (Cualquier número)
        public string Number(string text) //5n
        {
            string answer = ""; //n
            try //2n+(n)
            {
                Int32.Parse(text); //n
                if (Regex.IsMatch(text, number)) //n=1
                {
                    answer = "Valor";
                }
            }
            catch (System.Exception)
            {
                answer = "Símbolo no identificado";
            }
            return answer; //n
        }
        //Método para identificar las Formas ("on", "off", "numbers", "edges", "flash")
        public string Type(string text) //3n+x(n)
        {
            string answer = "";
            for (int i = 0; i < type.Length; i++)
            {
                if (text.Contains(type[i]))
                {
                    answer = "Forma";
                }
            }
            return answer;
        }
        //Método para identificar las Llaves de inicio o fin ({})
        public string Pattern(string text) //3n+x(n)
        {
            string answer = "";
            for (int i = 0; i < pattern.Length; i++)
            {
                if (text.Contains(pattern[i]))
                {
                    answer = "Llaves de apertura";
                }
            }
            return answer;
        }
        public string Pattern2(string text)//3n+x(n)
        {
            string answer = "";
            for (int i = 0; i < pattern2.Length; i++)
            {
                if (text.Contains(pattern2[i]))
                {
                    answer = "Llaves de cierre";
                }
            }
            return answer;
        }
        //Método para identificar los Comentarios
        public string Comment(string text) //3n
        {
            string answer = "";
            if (text.StartsWith("$") && text.EndsWith("$"))
            {
                answer = "Comentario";
            }
            return answer;
        }
        //Método para identificar las Instrucciones(type,delay)
        public string Instruction(string text) //3n+x(n)
        {
            string answer = "";
            for (int i = 0; i < instruction.Length; i++)
            {
                if (text.Contains(instruction[i]))
                {
                    answer = "Instrucción";
                }
            }
            return answer;
        }
        //Método para juntar todos los métodos anteriores
        public string Metd(string text) //13n
        {
            string answer = "Símbolo no identificado";
            if (Keyword(text).Contains("Palabra reservada"))
            {
                answer = Keyword(text);
            }
            if (Variable(text).Contains("Identificador"))
            {
                answer = Variable(text);
            }
            if (Reserved(text).Contains("Tipo de dato"))
            {
                answer = Reserved(text);
            }
            if (Type(text).Contains("Forma"))
            {
                answer = Type(text);
            }
            if (Pattern(text).Contains("Llaves de apertura"))
            {
                answer = Pattern(text);
            }
            if (Pattern2(text).Contains("Llaves de cierre"))
            {
                answer = Pattern2(text);
            }
            if (Instruction(text).Contains("Instrucción"))
            {
                answer = Instruction(text);
            }
            if (Comment(text).Contains("Comentario"))
            {
                answer = Comment(text);
            }
            if (Number(text).Contains("Valor"))
            {
                answer = Number(text);
            }
            if (Equal(text).Contains("Comparador"))
            {
                answer = Equal(text);
            }
            if (Sing(text).Contains("Parentesis"))
            {
                answer = Sing(text);
            }
            return answer;
        }*/
        #endregion
        #region Métodos aplicando la recursividad
        public bool KeywordRecursive(string text, int index) //4n
        {
            bool state = false;//n
            if (index < keywords.Length)//n
            {
                if (text.Contains(keywords[index]))//n
                {
                    state = true;
                }
                else
                {
                    index++;
                    return KeywordRecursive(text, index);
                }
            }
            return state;//n
        }
        public bool VariableRecursive(string text, int index)//4n
        {
            bool state = false;
            if (index < variable.Length)
            {
                if (text.Contains(variable[index]))
                {
                    state = true;
                }
                else
                {
                    index++;
                    return VariableRecursive(text, index);
                }
            }
            return state;
        }
        public string NumberRecursive(string text) //5n
        {
            string answer = ""; //n
            try //2n+(n)
            {
                Int32.Parse(text); //n
                if (Regex.IsMatch(text, number)) //n=1
                {
                    answer = "Valor";
                }
            }
            catch (System.Exception)
            {
                answer = "Símbolo no identificado";
            }
            return answer; //n
        }
        public string CommentRecursive(string text) //3n
        {
            string answer = "";
            if (text.StartsWith("$") && text.EndsWith("$"))
            {
                answer = "Comentario";
            }
            return answer;
        }
        public bool ReservedRecursive(string text, int index)//4n
        {
            bool state = false;
            if (index < reserved.Length)
            {
                if (text.Contains(reserved[index]))
                {
                    state = true;
                }
                else
                {
                    index++;
                    return ReservedRecursive(text, index);
                }
            }
            return state;
        }
        public bool TypeRecursive(string text, int index)//4n
        {
            bool state = false;
            if (index < type.Length)
            {
                if (text.Contains(type[index]))
                {
                    state = true;
                }
                else
                {
                    index++;
                    return TypeRecursive(text, index);
                }
            }
            return state;
        }
        public bool PatternRecursive(string text, int index)//4n
        {
            bool state = false;
            if (index < pattern.Length)
            {
                if (text.Contains(pattern[index]))
                {
                    state = true;
                }
                else
                {
                    index++;
                    return PatternRecursive(text, index);
                }
            }
            return state;
        }
        public bool Pattern2Recursive(string text, int index)//4n
        {
            bool state = false;
            if (index < pattern2.Length)
            {
                if (text.Contains(pattern2[index]))
                {
                    state = true;
                }
                else
                {
                    index++;
                    return Pattern2Recursive(text, index);
                }
            }
            return state;
        }
        public bool InstructionRecursive(string text, int index)//4n
        {
            bool state = false;
            if (index < instruction.Length)
            {
                if (text.Contains(instruction[index]))
                {
                    state = true;
                }
                else
                {
                    index++;
                    return InstructionRecursive(text, index);
                }
            }
            return state;
        }
        public bool EqualRecursive(string text, int index)//4n
        {
            bool state = false;
            if (index < equal.Length)
            {
                if (text.Contains(equal[index]))
                {
                    state = true;
                }
                else
                {
                    index++;
                    return EqualRecursive(text, index);
                }
            }
            return state;
        }
        public bool SignRecursive(string text, int index)//4n
        {
            bool state = false;
            if (index < sign.Length)
            {
                if (text.Contains(sign[index]))
                {
                    state = true;
                }
                else
                {
                    index++;
                    return SignRecursive(text, index);
                }
            }
            return state;
        }
        public string Metd(string text) //13n
        {
            string answer = "Símbolo no identificado";
            if (VariableRecursive(text,0) == true)
            {
                answer = "Identificador";
            }
            if (ReservedRecursive(text, 0) == true)
            {
                answer = "Tipo de dato";
            }
            if (TypeRecursive(text, 0) == true)
            {
                answer = "Forma";
            }
            if (PatternRecursive(text, 0) == true)
            {
                answer = "Llaves de apertura";
            }
            if (Pattern2Recursive(text, 0) == true)
            {
                answer = "Llaves de cierre";
            }
            if (InstructionRecursive(text, 0) == true)
            {
                answer = "Instrucción";
            }
            if (CommentRecursive(text).Contains("Comentario"))
            {
                answer = CommentRecursive(text);
            }
            if (NumberRecursive(text).Contains("Valor"))
            {
                answer = NumberRecursive(text);
            }
            if (EqualRecursive(text, 0) == true)
            {
                answer = "Comparador";
            }
            if (SignRecursive(text, 0) == true)
            {
                answer = "Parentesis";
            }
            if (KeywordRecursive(text, 0) == true)
            {
                answer = "Palabra reservada";
            }
            return answer;
        }
        #endregion
    }
}