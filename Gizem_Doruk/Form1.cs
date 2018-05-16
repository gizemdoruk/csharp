using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gizem_Doruk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int maxuser;
        int maxsong;
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] allLines = File.ReadAllLines("exhibitA-input.csv");
            string[] columnTitles = allLines[0].Split(',');


            var query = allLines.Skip(1).Select((r, index) => new
            {
                i = index,
                Data = r.Split(',')
            }).ToList();


            maxuser =    Convert.ToInt16(query[0].Data[2]);
            maxsong = Convert.ToInt16(query[0].Data[1]);
            
            for (int i = 0; i < query.Count; i++)
                {
                    if(maxsong < Convert.ToInt16(query[i].Data[1]))
                        maxsong = Convert.ToInt16(query[i].Data[1]);

                    if (maxuser < Convert.ToInt16(query[i].Data[2]))
                        maxuser = Convert.ToInt16(query[i].Data[2]);

            }

            label2.Text = maxuser.ToString()+ " users ";
            label1.Text = maxsong.ToString()+ " songs";

            string[] date = new string[3];


            int[,] userlist = new int[maxuser+1, maxsong+1];
            int[] usersonglist = new int[maxuser + 1];
            for (int i = 0; i < query.Count; i++)
            {
                date = query[i].Data[3].Split('/');
                if (date[0]=="10")
                userlist[Convert.ToInt16(query[i].Data[2]),Convert.ToInt16(query[i].Data[1])]++;

            }


            //Q2
            for (int i = 0; i < maxuser + 1; i++)
            {
                for (int x = 0; x < maxsong + 1; x++)
                {

                    if (userlist[i, x] > 0)
                        usersonglist[i]++;

                }

            }

            int q2ans = 0;
            int q3ans = usersonglist[0];
            for (int i = 0; i < maxuser + 1; i++)
            {
                if (usersonglist[i] == 346)
                    q2ans++;
                if (usersonglist[i] > q3ans)
                    q3ans = usersonglist[i];

            }


                label3.Text = "q2 ANS = "+q2ans.ToString() + " Users";
                label4.Text = "q3 ANS = " + q3ans.ToString() + " distinct songs";



        }


    }
}
