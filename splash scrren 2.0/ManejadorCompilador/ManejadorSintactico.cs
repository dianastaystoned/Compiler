using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManejadorCompilador
{
    public class ManejadorSintactico
    {
        //Árbol del While
        public string While(DataGridView tabla)
        {
            string answer = "";
            for (int i = 0; i < tabla.RowCount; i++)
            {
                if (tabla.Rows[i].Cells[1].Value.ToString().Equals("While"))
                {
                    if (tabla.Rows[i + 1].Cells[1].Value.ToString().Equals("("))
                    {
                        if (tabla.Rows[i + 2].Cells[2].Value.ToString().Equals("Identificador"))
                        {
                            if (tabla.Rows[i + 3].Cells[1].Value.ToString().Equals(")"))
                            {
                                if (tabla.Rows[i + 4].Cells[1].Value.ToString().Equals("{"))
                                {
                                    if (tabla.Rows[i + 5].Cells[2].Value.ToString().Equals("Instrucción"))
                                    {
                                        if (tabla.Rows[i + 6].Cells[1].Value.ToString().Equals("("))
                                        {
                                            if (tabla.Rows[i + 7].Cells[2].Value.ToString().Equals("Forma"))
                                            {
                                                if (tabla.Rows[i + 8].Cells[1].Value.ToString().Equals(")"))
                                                {
                                                    if (tabla.Rows[i + 9].Cells[1].Value.ToString().Equals("delay"))
                                                    {
                                                        if (tabla.Rows[i + 10].Cells[1].Value.ToString().Equals("("))
                                                        {
                                                            if (tabla.Rows[i + 11].Cells[2].Value.ToString().Equals("Valor"))
                                                            {
                                                                if (tabla.Rows[i + 12].Cells[1].Value.ToString().Equals(")"))
                                                                {
                                                                    if (tabla.Rows[i + 13].Cells[1].Value.ToString().Equals("}"))
                                                                    {
                                                                        answer = "Análisis sintáctico correcto";
                                                                        break;
                                                                    }
                                                                    else
                                                                    {
                                                                        answer = "S008, Falta la llave de cierre";
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    answer = "SS004, Falta el paréntesis de cierre";
                                                                }
                                                            }
                                                            else if (tabla.Rows[i + 11].Cells[2].Value.ToString().Equals("Identificador"))
                                                            {
                                                                if (tabla.Rows[i + 12].Cells[1].Value.ToString().Equals(")"))
                                                                {
                                                                    if (tabla.Rows[i + 13].Cells[1].Value.ToString().Equals("}"))
                                                                    {
                                                                        answer = "";
                                                                        break;
                                                                    }
                                                                    else
                                                                    {
                                                                        answer = "S008, Falta la llave de cierre";
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    answer = "SS004, Falta el paréntesis de cierre";
                                                                }
                                                            }
                                                            else
                                                            {
                                                                answer = "SS002, Término de expresión invalido";
                                                                break;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            answer = "SS003, Falta el paréntesis de comienzo";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        answer = "SS002, Término de expresión invalido";
                                                    }
                                                }
                                                else
                                                {
                                                    answer = "SS004, Falta el paréntesis de cierre";
                                                }
                                            }
                                            else
                                            {
                                                answer = "SS010, Perdiste una forma ?";
                                            }
                                        }
                                        else
                                        {
                                            answer = "SS003, Falta el paréntesis de comienzo";
                                        }
                                    }
                                    else
                                    {
                                        answer = "SS009, Falta una instrucción";
                                    }
                                }
                                else
                                {
                                    answer = "SS004, Falta la llave de comienzo";
                                }
                            }
                            else
                            {
                                answer = "SS004, Falta el paréntesis de cierre";
                            }
                        }
                        else
                        {
                            answer = "SS002, Término de expresión invalido";
                        }
                    }
                    else
                    {
                        answer = "SS003, Falta el paréntesis de comienzo";
                    }
                }
                /*else
                {
                    answer = "SS002, Término de expresión invalido";
                }*/
            }
            return answer;
        }
        //Árbol del Type
        public string Type(DataGridView tabla)
        {
            string answer = "";
            for (int i = 0; i < tabla.RowCount; i++)
            {
                if (tabla.Rows[i].Cells[1].Value.ToString().Equals("type"))
                {
                    if (tabla.Rows[i + 1].Cells[1].Value.ToString().Equals("("))
                    {
                        if (tabla.Rows[i + 2].Cells[2].Value.ToString().Equals("Forma"))
                        {
                            if (tabla.Rows[i + 3].Cells[1].Value.ToString().Equals(")"))
                            {
                                answer = "";
                                break;
                            }
                            else
                            {
                                answer = "SS004, Falta el paréntesis de cierre";
                            }
                        }
                        else
                        {
                            answer = "SS002, Término de expresión invalido";
                        }
                    }
                    else
                    {
                        answer = "SS003, Falta el paréntesis de comienzo";
                    }
                }
            }
            return answer;
        }
        //Árbol del Tipo de dato
        public string TipoDato(DataGridView tabla)
        {
            string answer = "";
            for (int i = 0; i < tabla.RowCount; i++)
            {
                if (tabla.Rows[i].Cells[2].Value.ToString().Equals("Tipo de dato"))
                {
                    if (tabla.Rows[i+1].Cells[2].Value.ToString().Equals("Identificador"))
                    {
                        if (tabla.Rows[i+2].Cells[1].Value.ToString().Equals("="))
                        {
                            if (tabla.Rows[i + 3].Cells[2].Value.ToString().Equals("Valor"))
                            {
                                answer = "";
                                break;
                            }
                            else
                            {
                                answer = "SS006, Falta un valor para la expresión"; 
                            }
                        }
                        else
                        {
                            answer = "SS005, Falta un 'Signo' despues del identificador";
                        }
                    }
                    else
                    {
                        answer = "SS002, Término de expresión invalido";
                    }
                }
            }
            return answer;
        }
        
        //Árbol del Delay
        public string Delay(DataGridView tabla)
        {
            string answer = "";
            for (int i = 0; i < tabla.RowCount; i++)
            {
                if (tabla.Rows[i].Cells[1].Value.ToString().Equals("delay"))
                {
                    if (tabla.Rows[i + 1].Cells[1].Value.ToString().Equals("("))
                    {
                        if (tabla.Rows[i + 2].Cells[2].Value.ToString().Equals("Valor"))
                        {
                            if (tabla.Rows[i + 3].Cells[1].Value.ToString().Equals(")"))
                            {
                                answer = "";
                                break;
                            }
                            else
                            {
                                answer = "SS004, Falta el paréntesis de cierre";
                                break;
                            }
                        }
                        else if (tabla.Rows[i + 2].Cells[2].Value.ToString().Equals("Identificador"))
                        {
                            if (tabla.Rows[i + 3].Cells[1].Value.ToString().Equals(")"))
                            {
                                answer = "";
                                break;
                            }
                            else
                            {
                                answer = "SS004, Falta el paréntesis de cierre";
                                break;
                            }
                        }
                        else
                        {
                            answer = "SS002, Término de expresión invalido";
                            break;
                        }
                    }
                    else
                    {
                        answer = "SS003, Falta el paréntesis de comienzo";
                        break;
                    }
                }
            }
            return answer;
        }
        //Método para juntar todos los árboles.
        public string Metodos(DataGridView tabla)
        {
            if (Delay(tabla).Contains("SS00"))
            {
                return Delay(tabla);
            }
            if (TipoDato(tabla).Contains("SS00"))
            {
                return TipoDato(tabla);
            }
            if (Type(tabla).Contains("SS00"))
            {
                return Type(tabla);
            }
            if (While(tabla).Contains("SS00"))
            {
                return While(tabla);
            }
            return "";
        }
    }
}
