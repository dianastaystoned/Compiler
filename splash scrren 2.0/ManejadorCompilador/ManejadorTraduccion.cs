using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManejadorCompilador
{
    public class ManejadorTraduccion
    {
        public string Begin(DataGridView table)
        {
            string answer = "";
            if (table.Rows[0].Cells[1].Value.ToString().Equals("Begin"))
            {
                answer = "void loop()" + "\n" + "{" + "\n";
            }
            return answer;
        }
        public string End(DataGridView table)
        {
            string answer = "";
            if (table.Rows[table.RowCount - 1].Cells[1].Value.ToString().Equals("End"))
            {
                answer = "}";
            }
            return answer;
        }
        public string Delay(DataGridView table)
        {
            string answer = "";
            for (int i = 0; i < table.RowCount; i++)
            {
                if (table.Rows[i].Cells[1].Value.ToString().Equals("delay"))
                {
                    answer = "delay" + " (" + table.Rows[i + 2].Cells[1].Value.ToString() + ");" + "\n" + "}" + "\n";
                }
            }
            return answer;
        }
        public string Variable(DataGridView table)
        {
            string answer = "";
            string variable = "";
            for (int i = 0; i < table.RowCount; i++)
            {
                if (table.Rows[i].Cells[2].Value.ToString().Equals("Tipo de dato"))
                {
                    variable += table.Rows[i].Cells[1].Value.ToString() + " " + table.Rows[i + 1].Cells[1].Value.ToString() + table.Rows[i + 2].Cells[1].Value.ToString() + table.Rows[i + 3].Cells[1].Value.ToString() + ";" + "\n";
                }
                if (table.Rows[i].Cells[1].Value.ToString().Equals("While"))
                {
                    answer = variable + "int latchPin = 8;" + "\n" + "int clockPin = 12;" + "\n" + "int dataPin = 11;" + " \n" + "int tiempo = 1;" + "\n" + "void setup()" + "\n" + "{" + "\n" + "Serial.begin(9600);" + "\n" + "pinMode (latchPin, OUTPUT);" + "\n" + "pinMode (clockPin, OUTPUT);" + "\n" + "pinMode (dataPin, OUTPUT);" + "\n" + "}" + "\n";
                }
            }
            return answer;
        }
        public string While(DataGridView table)
        {
            string answer = "";
            for (int i = 0; i < table.RowCount; i++)
            {
                if (table.Rows[i].Cells[1].Value.ToString().Equals("While"))
                {
                    answer = "for (int i = 0; i < " + table.Rows[i + 2].Cells[1].Value.ToString() + "; i++)" + "\n" + "{" + "\n";
                }
            }
            return answer;
        }
        public string Comment(DataGridView table)
        {
            string answer = "";
            for (int i = 0; i < table.RowCount; i++)
            {
                if (table.Rows[i].Cells[2].Value.ToString().Equals("Comentario"))
                {
                    answer += "//" + table.Rows[i].Cells[1].Value.ToString() + "\n";
                }
            }
            return answer;
        }
        public string Type(DataGridView table)
        {
            string answer = "";
            for (int i = 0; i < table.RowCount; i++)
            {
                if (table.Rows[i].Cells[1].Value.ToString().Equals("mario"))
                {
                    answer = mario;
                }
                else if (table.Rows[i].Cells[1].Value.ToString().Equals("bomberman"))
                {
                    answer = bomberman;
                }
                else if (table.Rows[i].Cells[1].Value.ToString().Equals("shadow"))
                {
                    answer = shadow;
                }
                else if (table.Rows[i].Cells[1].Value.ToString().Equals("pacman"))
                {
                    answer = pacman;
                }
            }
            return answer;
        }
        public string Traduction(DataGridView table)
        {
            string answer = "";
            if (table.RowCount > 0)
            {
                answer = Variable(table) + Comment(table) + Begin(table) + While(table) + Type(table) + Delay(table) + End(table);
            }
            return answer;
        }
        #region Bomberman section
        string bomberman = "for (int i = 0; i <= 12; i++)" + "\n" + "{" + "\n" +
                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x80); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xE0); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x37);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x48); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xF0); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xF); " + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x20); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xA0); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x1C); " + "\n" +
                        "digitalWrite(latchPin, 1); " + "\n" +
                        "delay(tiempo); " + "\n" +

                        "digitalWrite(latchPin, 0); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x10); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xA0); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x1E); " + "\n" +
                        "digitalWrite(latchPin, 1); " + "\n" +
                        "delay(tiempo); " + "\n" +

                        "digitalWrite(latchPin, 0); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x4); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xE0); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xF); " + "\n" +
                        "digitalWrite(latchPin, 1); " + "\n" +
                        "delay(tiempo); " + "\n" +

                        "digitalWrite(latchPin, 0); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x2); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x40); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x8); " + "\n" +
                        "digitalWrite(latchPin, 1); " + "\n" +
                        "delay(tiempo); " + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x1); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xB0); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x17); " + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x80);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xF0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x67); " + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x40); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xC0); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x63); " + "\n" +
                        "digitalWrite(latchPin, 1); " + "\n" +
                        "delay(tiempo); " + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x20); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x90); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x10); " + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x10); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x70); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x14); " + "\n" +
                        "digitalWrite(latchPin, 1); " + "\n" +
                        "delay(tiempo); " + "\n" +

                        "digitalWrite(latchPin, 0); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x8); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xF0); " + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x3c); " + "\n" +
                        "digitalWrite(latchPin, 1); " + "\n" +
                        "delay(tiempo); " + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x4);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x70);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x7F);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x2);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x30);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x1);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x18);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" + "}" + "\n" +

                "for (int i = 0; i <= 12; i++)" + "\n" + "{" + "\n" +
                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x80);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xE0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x37);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x48);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xF0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xF);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x20);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xA0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x1C);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x10);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xA0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x1E);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x4);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xE0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xB);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x2);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x40);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x8);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x1);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x20);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x1E);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x80);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x20);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x1C);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x40);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x30);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x1C);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x20);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x30);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x1E);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x10);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x40);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x16);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xC);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x80);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xD);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x2);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xC0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xD);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x1);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xE);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" + "}" + "\n" +

                "for (int i = 0; i <= 12; i++)" + "\n" + "{" + "\n" +
                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x80);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x20);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x40);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xE0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x17);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x20);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xF0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xF);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x10);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xA0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x1C);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x8);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xA0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x1E);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x4);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xF0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xF);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x2);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xE0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xB);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x1);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x80);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x1C);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x80);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x40);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x1C);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x40);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x30);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x38);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x20);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x70);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x70);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x10);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x40);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x60);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x8);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x63);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x4);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0xF7);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x2);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x86);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);" + "\n" +

                        "digitalWrite(latchPin, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x1);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                        "shiftOut(dataPin, clockPin, LSBFIRST, 0x7);" + "\n" +
                        "digitalWrite(latchPin, 1);" + "\n" +
                        "delay(tiempo);"+ "\n" + "}" + "\n";
        #endregion
        #region Shadow section
            string shadow = "for (int i = 0; i <= 15; i++)" + "\n" + "{" + "\n" + 
                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x80);" + "\n" +
                "shiftOut(dataPin, clockPin, MSBFIRST, 0x7);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x7);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x40);" + "\n" +
                "shiftOut(dataPin, clockPin, MSBFIRST, 0xC); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0xC); " + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x20);" + "\n" +
                "shiftOut(dataPin, clockPin, MSBFIRST, 0x10);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x10);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x10);" + "\n" +
                "shiftOut(dataPin, clockPin, MSBFIRST, 0x20); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x20);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x8); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x1A); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x46);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x4); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x3E); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x4F); " + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x2); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x32); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x4C);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x1); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x31);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x8C); " + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x80);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x19);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x86); " + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x70);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, MSBFIRST, 0x80);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x80);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x8);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, MSBFIRST, 0x89);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x91);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x4);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, MSBFIRST, 0x9D);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0xB9);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x2); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, MSBFIRST, 0x76); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0xEE);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" + "}" + "\n" +

             "for (int i = 0; i <= 15; i++)" + "\n" + "{ " + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x80);" + "\n" +
                "shiftOut(dataPin, clockPin, MSBFIRST, 0x7); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x7); " + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x40); " + "\n" +
                "shiftOut(dataPin, clockPin, MSBFIRST, 0xC); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0xC); " + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x20); " + "\n" +
                "shiftOut(dataPin, clockPin, MSBFIRST, 0x10);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x10); " + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x10);" + "\n" +
                "shiftOut(dataPin, clockPin, MSBFIRST, 0x20);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x20);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x8);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x1A);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x46);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x4);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x3E); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x4F); " + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x2); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x32);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x4C); " + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x1);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x31); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x8C);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x80);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x19); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x86);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x70);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0); " + "\n" +
                "shiftOut(dataPin, clockPin, MSBFIRST, 0x80);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x80); " + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +
                //
                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x8);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x21);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x84); " + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x4);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x52);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x4A); " + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x2); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0); " + "\n" +
                "shiftOut(dataPin, clockPin, MSBFIRST, 0xDE);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x7B);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" + "}" + "\n";
        #endregion
        #region Pacman section
        string pacman = "for (int i = 0; i <= 20; i++)" + "\n" + "{" + "\n" +

        "digitalWrite(latchPin, 0);" + "\n" +
        "shiftOut(dataPin, clockPin, LSBFIRST, 0x1);" + "\n" +
        "shiftOut(dataPin, clockPin, LSBFIRST, 0x80);" + "\n" +
        "shiftOut(dataPin, clockPin, LSBFIRST, 0xC0);" + "\n" +
        "shiftOut(dataPin, clockPin, LSBFIRST, 0x7);" + "\n" +
        "digitalWrite(latchPin, 1);" + "\n" +
        "delay(tiempo);" + "\n" +

        "digitalWrite(latchPin, 0);" + "\n" +
        "shiftOut(dataPin, clockPin, LSBFIRST, 0x2);" + "\n" +
        "shiftOut(dataPin, clockPin, LSBFIRST, 0x40);" + "\n" +
        "shiftOut(dataPin, clockPin, LSBFIRST, 0x30);" + "\n" +
        "shiftOut(dataPin, clockPin, LSBFIRST, 0x18);" + "\n" +
        "digitalWrite(latchPin, 1);" + "\n" +
        "delay(tiempo);" + "\n" +

        "digitalWrite(latchPin, 0);" + "\n" +
        "shiftOut(dataPin, clockPin, LSBFIRST, 0x4);" + "\n" +
        "shiftOut(dataPin, clockPin, LSBFIRST, 0x20);" + "\n" +
        "shiftOut(dataPin, clockPin, LSBFIRST, 0x8);" + "\n" +
        "shiftOut(dataPin, clockPin, LSBFIRST, 0x20); " + "\n" +
        "digitalWrite(latchPin, 1);" + "\n" +
        "delay(tiempo);" + "\n" +

        "digitalWrite(latchPin, 0);" + "\n" +
        "shiftOut(dataPin, clockPin, MSBFIRST, 0x18);" + "\n" +
        "shiftOut(dataPin, clockPin, LSBFIRST, 0x18);" + "\n" +
        "shiftOut(dataPin, clockPin, LSBFIRST, 0x4);" + "\n" +
        "shiftOut(dataPin, clockPin, LSBFIRST, 0x40);" + "\n" +
        "digitalWrite(latchPin, 1);" + "\n" +
        "delay(tiempo);" + "\n" +

        "digitalWrite(latchPin, 0);" + "\n" +
        "shiftOut(dataPin, clockPin, MSBFIRST, 0x4);" + "\n" +
        "shiftOut(dataPin, clockPin, LSBFIRST, 0x4);" + "\n" +
        "shiftOut(dataPin, clockPin, LSBFIRST, 0x18);" + "\n" +
        "shiftOut(dataPin, clockPin, LSBFIRST, 0x80); " + "\n" +
        "digitalWrite(latchPin, 1);" + "\n" +
        "delay(tiempo);" + "\n" +

        "digitalWrite(latchPin, 0);" + "\n" +
        "shiftOut(dataPin, clockPin, MSBFIRST, 0x2); " + "\n" +
        "shiftOut(dataPin, clockPin, LSBFIRST, 0x2);" + "\n" +
        "shiftOut(dataPin, clockPin, LSBFIRST, 0x60);" + "\n" +
        "shiftOut(dataPin, clockPin, LSBFIRST, 0x80);" + "\n" +
        "digitalWrite(latchPin, 1);" + "\n" +
        "delay(tiempo);" + "\n" +

        "digitalWrite(latchPin, 0);" + "\n" +
        "shiftOut(dataPin, clockPin, MSBFIRST, 0x1);" + "\n" +
        "shiftOut(dataPin, clockPin, LSBFIRST, 0x1);" + "\n" +
        "shiftOut(dataPin, clockPin, LSBFIRST, 0x80);" + "\n" +
        "shiftOut(dataPin, clockPin, LSBFIRST, 0x81);" + "\n" +
        "digitalWrite(latchPin, 1);" + "\n" +
        "delay(tiempo);" + "\n" + "}" + "\n" +

  "for (int i = 0; i <= 20; i++)" + "\n" + "{" + "\n" + 

    "digitalWrite(latchPin, 0);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x1);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x80);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0xE0);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0xF);" + "\n" +
    "digitalWrite(latchPin, 1);" + "\n" +
    "delay(tiempo);" + "\n" +

    "digitalWrite(latchPin, 0);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x2);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x40);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x20);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x18);" + "\n" +
    "digitalWrite(latchPin, 1);" + "\n" +
    "delay(tiempo);" + "\n" +

    "digitalWrite(latchPin, 0);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x4);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x20);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x20);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x20);" + "\n" +
    "digitalWrite(latchPin, 1);" + "\n" +
    "delay(tiempo);" + "\n" +

    "digitalWrite(latchPin, 0);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x8);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x10);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x40);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x40);" + "\n" +
    "digitalWrite(latchPin, 1);" + "\n" +
    "delay(tiempo);" + "\n" +

    "digitalWrite(latchPin, 0);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x10);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x8);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x80);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x40);" + "\n" +
    "digitalWrite(latchPin, 1);" + "\n" +
    "delay(tiempo);" + "\n" +

    "digitalWrite(latchPin, 0);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x20);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x4);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x81);" + "\n" +
    "digitalWrite(latchPin, 1);" + "\n" +
    "delay(tiempo);" + "\n" +

    "digitalWrite(latchPin, 0);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x40);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x2);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x82);" + "\n" +
    "digitalWrite(latchPin, 1);" + "\n" +
    "delay(tiempo);" + "\n" +

    "digitalWrite(latchPin, 0);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x80);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x1);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x84);" + "\n" +
    "digitalWrite(latchPin, 1);" + "\n" +
    "delay(tiempo);" + "\n" + "}" + "\n" +

"for (int i = 0; i <= 20; i++)" + "\n" + "{" + "\n" +

    "digitalWrite(latchPin, 0);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x1); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x80);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0xC0);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x7);" + "\n" +
    "digitalWrite(latchPin, 1);" + "\n" +
    "delay(tiempo);" + "\n" +

    "digitalWrite(latchPin, 0);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x2);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x40);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x30);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x18);" + "\n" +
    "digitalWrite(latchPin, 1);" + "\n" +
    "delay(tiempo);" + "\n" +

    "digitalWrite(latchPin, 0);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x4);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x20);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x8); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x20); " + "\n" +
    "digitalWrite(latchPin, 1);" + "\n" +
    "delay(tiempo);" + "\n" +

    "digitalWrite(latchPin, 0);" + "\n" +
    "shiftOut(dataPin, clockPin, MSBFIRST, 0x18);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x18);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x4);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x40);" + "\n" +
    "digitalWrite(latchPin, 1);" + "\n" +
    "delay(tiempo);" + "\n" +

    "digitalWrite(latchPin, 0);" + "\n" +
    "shiftOut(dataPin, clockPin, MSBFIRST, 0x4); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x4);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x18);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x80); " + "\n" +
    "digitalWrite(latchPin, 1);" + "\n" +
    "delay(tiempo);" + "\n" +

    "digitalWrite(latchPin, 0);" + "\n" +
    "shiftOut(dataPin, clockPin, MSBFIRST, 0x2);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x2);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x60);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x80);" + "\n" +
    "digitalWrite(latchPin, 1);" + "\n" +
    "delay(tiempo);" + "\n" +

    "digitalWrite(latchPin, 0);" + "\n" +
    "shiftOut(dataPin, clockPin, MSBFIRST, 0x1);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x1);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x80);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x81);" + "\n" +
    "digitalWrite(latchPin, 1);" + "\n" +
    "delay(tiempo);" + "\n" + "}" + "\n" +


"for (int i = 0; i <= 20; i++) " + "\n" + "{" + "\n" +

    "digitalWrite(latchPin, 0);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x1);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x80);" + "\n" +
    "shiftOut(dataPin, clockPin, MSBFIRST, 0x3);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x3);" + "\n" +
    "digitalWrite(latchPin, 1);" + "\n" +
    "delay(tiempo);" + "\n" +

    "digitalWrite(latchPin, 0);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x2);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x40);" + "\n" +
    "shiftOut(dataPin, clockPin, MSBFIRST, 0xc);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0xc);" + "\n" +
    "digitalWrite(latchPin, 1);" + "\n" +
    "delay(tiempo);" + "\n" +

    "digitalWrite(latchPin, 0);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x4);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x20);" + "\n" +
    "shiftOut(dataPin, clockPin, MSBFIRST, 0x10);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x10); " + "\n" +
    "digitalWrite(latchPin, 1);" + "\n" +
    "delay(tiempo);" + "\n" +

    "digitalWrite(latchPin, 0);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x8);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x10);" + "\n" +
    "shiftOut(dataPin, clockPin, MSBFIRST, 0x20);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x20);" + "\n" +
    "digitalWrite(latchPin, 1);" + "\n" +
    "delay(tiempo);" + "\n" +

    "digitalWrite(latchPin, 0);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x30);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0xC);" + "\n" +
    "shiftOut(dataPin, clockPin, MSBFIRST, 0x40);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x40);" + "\n" +
    "digitalWrite(latchPin, 1);" + "\n" +
    "delay(tiempo);" + "\n" +

    "digitalWrite(latchPin, 0);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0xC0);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x3);" + "\n" +
    "shiftOut(dataPin, clockPin, MSBFIRST, 0x80);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x80); " + "\n" +
    "digitalWrite(latchPin, 1);" + "\n" +
    "delay(tiempo);" + "\n" + "}" + "\n" +

"for (int i = 0; i <= 20; i++) " + "\n " + "{" + "\n" +

    "digitalWrite(latchPin, 0); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x1); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x80); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0xC0); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x7); " + "\n" +
    "digitalWrite(latchPin, 1); " + "\n" +
    "delay(tiempo); " + "\n" +

    "digitalWrite(latchPin, 0); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x2); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x40); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x30); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x18); " + "\n" +
    "digitalWrite(latchPin, 1); " + "\n" +
    "delay(tiempo); " + "\n" +

    "digitalWrite(latchPin, 0);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x4);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x20);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x8);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x20);" + "\n" +
    "digitalWrite(latchPin, 1);" + "\n" +
    "delay(tiempo);" + "\n" +

    "digitalWrite(latchPin, 0);" + "\n" +
    "shiftOut(dataPin, clockPin, MSBFIRST, 0x18); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x18);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x4); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x40); " + "\n" +
    "digitalWrite(latchPin, 1);" + "\n" +
    "delay(tiempo);" + "\n" +

    "digitalWrite(latchPin, 0);" + "\n" +
    "shiftOut(dataPin, clockPin, MSBFIRST, 0x4); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x4);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x18);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x80);" + "\n" +
    "digitalWrite(latchPin, 1);" + "\n" +
    "delay(tiempo);" + "\n" +

    "digitalWrite(latchPin, 0); " + "\n" +
    "shiftOut(dataPin, clockPin, MSBFIRST, 0x2); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x2); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x60); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x80); " + "\n" +
    "digitalWrite(latchPin, 1); " + "\n" +
    "delay(tiempo); " + "\n" +

    "digitalWrite(latchPin, 0); " + "\n" +
    "shiftOut(dataPin, clockPin, MSBFIRST, 0x1); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x1); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x80); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x81); " + "\n" +
    "digitalWrite(latchPin, 1); " + "\n" +
    "delay(tiempo); " + "\n" + "}" + "\n " +

"for (int i = 0; i <= 20; i++)" + "\n" + "{" + "\n" +

    "digitalWrite(latchPin, 0);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x1);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x80);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0xE0); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0xF);" + "\n" +
    "digitalWrite(latchPin, 1);" + "\n" +
    "delay(tiempo);" + "\n" +

    "digitalWrite(latchPin, 0);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x2);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x40);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x20); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x18); " + "\n" +
    "digitalWrite(latchPin, 1);" + "\n" +
    "delay(tiempo);" + "\n" +

    "digitalWrite(latchPin, 0);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x4); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x20); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x20); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x20); " + "\n" +
    "digitalWrite(latchPin, 1); " + "\n" +
    "delay(tiempo); " + "\n" +

    "digitalWrite(latchPin, 0); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x8); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x10); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x40); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x40); " + "\n" +
    "digitalWrite(latchPin, 1); " + "\n" +
    "delay(tiempo); " + "\n" +

    "digitalWrite(latchPin, 0); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x10); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x8); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x80); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x40); " + "\n" +
    "digitalWrite(latchPin, 1); " + "\n" +
    "delay(tiempo); " + "\n" +

    "digitalWrite(latchPin, 0); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x20); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x4); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x81); " + "\n" +
    "digitalWrite(latchPin, 1); " + "\n" +
    "delay(tiempo); " + "\n" +

    "digitalWrite(latchPin, 0); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x40); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x2); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x82); " + "\n" +
    "digitalWrite(latchPin, 1); " + "\n" +
    "delay(tiempo); " + "\n" +

    "digitalWrite(latchPin, 0); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x80); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x1); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x84); " + "\n" +
    "digitalWrite(latchPin, 1); " + "\n" +
    "delay(tiempo); " + "\n" + "}" + "\n " +

"for (int i = 0; i <= 20; i++) " + "\n " + "{" + "\n" +

    "digitalWrite(latchPin, 0); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x1); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x80); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0xC0); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x7); " + "\n" +
    "digitalWrite(latchPin, 1); " + "\n" +
    "delay(tiempo); " + "\n" +

    "digitalWrite(latchPin, 0); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x2); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x40); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x30); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x18); " + "\n" +
    "digitalWrite(latchPin, 1); " + "\n" +
    "delay(tiempo); " + "\n" +

    "digitalWrite(latchPin, 0); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x4); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x20); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x8); " + "\n" + 
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x20); " + "\n" +
    "digitalWrite(latchPin, 1); " + "\n" +
    "delay(tiempo); " + "\n" +

    "digitalWrite(latchPin, 0);" + "\n" +
    "shiftOut(dataPin, clockPin, MSBFIRST, 0x18);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x18);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x4); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x40);" + "\n" +
    "digitalWrite(latchPin, 1); " + "\n" +
    "delay(tiempo); " + "\n" +

    "digitalWrite(latchPin, 0); " + "\n" +
    "shiftOut(dataPin, clockPin, MSBFIRST, 0x4); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x4); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x18); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x80); " + "\n" +
    "digitalWrite(latchPin, 1); " + "\n" +
    "delay(tiempo); " + "\n" +

    "digitalWrite(latchPin, 0); " + "\n" +
    "shiftOut(dataPin, clockPin, MSBFIRST, 0x2); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x2); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x60); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x80); " + "\n" +
    "digitalWrite(latchPin, 1); " + "\n" +
    "delay(tiempo); " + "\n" +

    "digitalWrite(latchPin, 0); " + "\n" +
    "shiftOut(dataPin, clockPin, MSBFIRST, 0x1); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x1); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x80); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x81); " + "\n" +
    "digitalWrite(latchPin, 1); " + "\n" +
    "delay(tiempo); " + "\n" + "}" + "\n " +

"for (int i = 0; i <= 20; i++) " + "\n " + "{" + "\n" +

    "digitalWrite(latchPin, 0); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x1); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x80); " + "\n" +
    "shiftOut(dataPin, clockPin, MSBFIRST, 0x3); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x3); " + "\n" +
    "digitalWrite(latchPin, 1); " + "\n" +
    "delay(tiempo); " + "\n" +

    "digitalWrite(latchPin, 0); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x2); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x40); " + "\n" +
    "shiftOut(dataPin, clockPin, MSBFIRST, 0xc); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0xc); " + "\n" +
    "digitalWrite(latchPin, 1); " + "\n" +
    "delay(tiempo); " + "\n" +

    "digitalWrite(latchPin, 0); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x4); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x20); " + "\n" +
    "shiftOut(dataPin, clockPin, MSBFIRST, 0x10); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x10); " + "\n" +
    "digitalWrite(latchPin, 1); " + "\n" +
    "delay(tiempo); " + "\n" +

    "digitalWrite(latchPin, 0); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x8); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x10); " + "\n" +
    "shiftOut(dataPin, clockPin, MSBFIRST, 0x20); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x20); " + "\n" +
    "digitalWrite(latchPin, 1); " + "\n" +
    "delay(tiempo); " + "\n" +

    "digitalWrite(latchPin, 0);" + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x30); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0xC); " + "\n" +
    "shiftOut(dataPin, clockPin, MSBFIRST, 0x40); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x40); " + "\n" +
    "digitalWrite(latchPin, 1); " + "\n" +
    "delay(tiempo); " + "\n" +

    "digitalWrite(latchPin, 0); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0xC0); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x3); " + "\n" +
    "shiftOut(dataPin, clockPin, MSBFIRST, 0x80); " + "\n" +
    "shiftOut(dataPin, clockPin, LSBFIRST, 0x80); " + "\n" +
    "digitalWrite(latchPin, 1); " + "\n" +
    "delay(tiempo); " + "\n" + "}" + "\n ";
        #endregion
        #region Mario Bros section
    string mario = "for (int i = 0; i <= 12; i++)" + "\n" + "{ " + "\n" + 

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x40);" + "\n" +
                "shiftOut(dataPin, clockPin, MSBFIRST, 0x7); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x7);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x20);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x18);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x8);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x10); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x4); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x10);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x8); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0xB8);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x1C);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x4);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x84);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x26);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x2);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x44);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x26); " + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x1);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0xF8);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x18);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x80); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x10);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0xC);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x40);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x20);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x13);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x20);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x90);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x21); " + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x10); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0xF0); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x21); " + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x8); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0xB0); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x11); " + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x4);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x70);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x10);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x2);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x20);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x8);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x1);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0xE0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0xF);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" + "}" + "\n" +

             "for (int i = 0; i <= 12; i++)" + "\n" + "{ " + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x80);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0xC0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x7);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x40);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x38);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x8);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x20); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x4);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x10); " + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x10);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0xB8); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x1c); " + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x8);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x84);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x26);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x4);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x44);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x26); " + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x2); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0xF8);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x18);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x1);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x10);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x1C);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x80);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x38);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x63);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x40);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x94);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x81);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x20);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0xF2);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x83);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x10); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x6A); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x4F);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x8);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0xE4);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x3F);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x4);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0xC4);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x4F);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x2);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x88); " + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x44);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" +

                "digitalWrite(latchPin, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x1);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x70);" + "\n" +
                "shiftOut(dataPin, clockPin, LSBFIRST, 0x38);" + "\n" +
                "digitalWrite(latchPin, 1);" + "\n" +
                "delay(tiempo);" + "\n" + "}" + "\n";
        #endregion
    }
}
