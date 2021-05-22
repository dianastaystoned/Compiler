using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManejadorCompilador
{
    public class ManejadorSemantico
    {
        //First Rule Begin
        public string Begin(DataGridView table)
        {
            string answer = "";
            if (table.Rows[0].Cells[1].Value.ToString().Equals("Begin"))
            {
                answer = "";
            }
            else
            {
                answer = "SS020, La primera línea debe ser Begin";
            }
            return answer;
        }
        //Second Rule End
        public string End(DataGridView table)
        {
            string answer = "";
            if (table.Rows[table.RowCount-1].Cells[1].Value.ToString().Equals("End"))
            {
                answer = "";
            }
            else
            {
                answer = "SS021, La última línea debe ser End";
            }
            return answer;
        }
        //Third Rule {}
        public string CurlyBraces(DataGridView table)
        {
            string answer = "";
            if (table.Rows[1].Cells[1].Value.ToString().Equals("{"))
            {
                answer = "";
            }
            else
            {
                answer = "SS022, La segunda línea debe ser una llave de apertura";
            }
            return answer;
        }
        public string CurlyBraces2(DataGridView table)
        {
            string answer = "";
            if (table.Rows[table.RowCount - 2].Cells[1].Value.ToString().Equals("}"))
            {
                answer = "";
            }
            else
            {
                answer = "SS023, La penúltima línea debe ser una llave de cierre";
            }
            return answer;
        }
        //Fourth Rule
        public string OnlyOnceB(DataGridView table)
        {
            string answer = "";
            int count = 0;
            for (int i = 1; i < table.RowCount; i++)
            {
                if (table.Rows[i].Cells[1].Value.ToString().Equals("Begin"))
                {
                    count++;
                    if (count >= 1)
                    {
                        answer = "SS024, Solo puede existir un Begin";
                    }
                }
            }
            return answer;
        }
        public string OnlyOnceE(DataGridView table)
        {
            string answer = "";
            int count = 0;
            for (int o = 1; o < table.RowCount-1; o++)
            {
                if (table.Rows[o].Cells[1].Value.ToString().Equals("End"))
                {
                    count++;
                    if (count >= 1)
                    {
                        answer = "SS025, Solo puede existir un End";
                    }
                }
            }
            return answer;
        }
        //Fifth Rule Variables no permitidas dentro del ciclo
        public string ConstW(DataGridView table)
        {
            string answer = "";
            int count = 0;
            for (int i = 0; i < table.RowCount-2; i++)
            {
                if (table.Rows[i].Cells[2].Value.ToString().Equals("Tipo de dato"))
                {
                    for (int x = i - 1; x >= 0; x--)
                    {
                        if (table.Rows[x].Cells[1].Value.ToString().Equals("While"))
                        {
                            count++;
                            if (count == 1)
                            {
                                answer = "SS026, Las variables deben ir fuera del ciclo While";
                            }
                        }
                    }
                }
            }
            return answer;
        }
        //Para hacer el analizador sémantico
        public string Semantico(DataGridView table)
        {
            string answer = "";
            if (table.RowCount > 0)
            {
                answer = Begin(table);
                if (answer.Length == 0)
                {
                    answer = End(table);
                }
                if (answer.Length == 0)
                {
                    answer = CurlyBraces(table);
                }
                if (answer.Length == 0)
                {
                    answer = CurlyBraces2(table);
                }
                if (answer.Length == 0)
                {
                    answer = OnlyOnceB(table);
                }
                if (answer.Length == 0)
                {
                    answer = OnlyOnceE(table);
                }
                if (answer.Length == 0)
                {
                    answer = ConstW(table);
                }
            }
            return answer;
        }
        #region Revisar reglas de instrucción
        public string SemanticoA(DataGridView table) 
        {
            string answer = "";  
            string instr;
            int instruction = 0;
            for (int i = 1; i < table.RowCount - 1; i++)
            {
                if (table.Rows[i].Cells[1].Value.Equals("delay"))
                {
                    //Se le pasa el valor de la variable
                    instr = table.Rows[i + 2].Cells[1].Value.ToString().Substring(0, 4);
                    try
                    {
                        instruction = int.Parse(instr);
                        answer = "";
                    }
                    catch (System.Exception)
                    {
                        //Buscar si esta declarada esa variable..
                        answer = Search(table, instr);
                        if (answer.Equals("exist"))
                        {
                            answer = "";
                        }
                        else
                        {
                            answer = "SS028, Se esperaba un valor o varibale declarada";
                            i = table.RowCount;
                        }
                    }
                }
                else if (table.Rows[i].Cells[1].Value.Equals("While"))
                {
                    //Se le pasa el valor de la variable
                    instr = table.Rows[i + 2].Cells[1].Value.ToString().Substring(0, 4);
                    try
                    {
                        instruction = int.Parse(instr);
                        answer = "";
                    }
                    catch (System.Exception)
                    {
                        //Buscar si esta declarada esa variable..
                        answer = Search(table, instr);
                        if (answer.Equals("exist"))
                        {
                            answer = "";
                        }
                        else
                        {
                            answer = "SS028, Se esperaba un valor o varibale declarada";
                            i = table.RowCount;
                        }
                    }
                }
            }
            return answer;
        }
        public string Search(DataGridView table, string a)
        {
            string answer = "";
            int count = 0;
            for (int i = 1; i < table.RowCount-2; i++)
            {
                if (table.Rows[i].Cells[1].Value.Equals(a))
                {
                    count++;
                    if (count == 2)
                    {
                        answer = "exist";
                    }
                }
            }
            return answer;
        }
        #endregion
    }
}
