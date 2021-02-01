using System;
using System.Threading;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }


        private void fillNumbers()
        {

            int massiveCount = Convert.ToInt32(textBox1.Text);
            int minNumber = Convert.ToInt32(textBox2.Text);
            int maxNumber = Convert.ToInt32(textBox3.Text);
            int[] arrayNums = new int[massiveCount];
            Random random = new Random();
            for (int i = 0; i < massiveCount; i++)
            {
                int nums = random.Next(minNumber - 1, maxNumber + 1);
                arrayNums[i] = Convert.ToInt32(listBox1.Items.Add(nums));
            }
            foreach (var i in listBox1.Items)
            {
                listBox2.Items.Add(i);
                listBox3.Items.Add(i);
                listBox4.Items.Add(i);
            }
        }
        private void sortBubble()
        {
            System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
            stopWatch.Start();
            int temp;
            int pass = 0;
            int swap = 0;
                
            for (int j = 0; j <= listBox2.Items.Count-1; j++)
                {
                    for (int i = 0; i <= listBox2.Items.Count -2; i++)
                    {
                         pass++;
                        if (Convert.ToInt32(listBox2.Items[i]) > Convert.ToInt32(listBox2.Items[i + 1]))
                        {
                            swap++;
                            temp = Convert.ToInt32(listBox2.Items[i + 1]);
                            listBox2.Invoke(new Action(() => listBox2.Items[i + 1] = Convert.ToInt32(listBox2.Items[i])));
                            listBox2.Invoke(new Action(() => listBox2.Items[i] = temp));
                        }
                    }
                }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
             ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            label3.Invoke(new Action(() => label2.Text = elapsedTime));
            label2.Invoke(new Action(() => label3.Text = pass.ToString() + "  " + swap.ToString()));
            label7.Invoke(new Action(() => label7.Text = "Сортировка закончена"));
        }
        private void shellSort()
        {
            System.Diagnostics.Stopwatch stopWatch2 = new System.Diagnostics.Stopwatch();
            stopWatch2.Start();
             
            int i, j, inc, temp;
            inc = 3;
            int pass2 = 0;
            int swap2 = 0;
            while (inc > 0)
            {
                for (i = 0; i < listBox3.Items.Count; i++)
                {
                    pass2++;
                    j = i;
                    temp = Convert.ToInt32(listBox3.Items[i]);
                    while ((j >= inc) && ((Convert.ToInt32(listBox3.Items[j - inc]) > temp)))
                    {
                        listBox3.Invoke(new Action(() => listBox3.Items[j] = Convert.ToInt32(listBox3.Items[j - inc])));
                        j = j - inc;
                        swap2++;
                    }
                    listBox3.Invoke(new Action(() => listBox3.Items[j] = temp));
                }
                if (inc / 2 != 0)
                    inc = inc / 2;
                else if (inc == 1)
                    inc = 0;
                else
                    inc = 1;
            }
            stopWatch2.Stop();
            TimeSpan ts2 = stopWatch2.Elapsed;
            string elapsedTime2 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
             ts2.Hours, ts2.Minutes, ts2.Seconds,
            ts2.Milliseconds / 10);
                label8.Invoke(new Action(() => label8.Text = elapsedTime2));
                label9.Invoke(new Action(() => label9.Text = pass2.ToString() + "  " + swap2.ToString()));
                label10.Invoke(new Action(() => label10.Text = "Сортировка закончена"));
        }

        private void InsertionSort()
        {
            System.Diagnostics.Stopwatch stopWatch3 = new System.Diagnostics.Stopwatch();
            stopWatch3.Start();
            int pass3 = 0;
            int swap3 = 0;
            for (int i = 0; i < listBox4.Items.Count - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    pass3++;
                    if (Convert.ToInt32(listBox4.Items[j - 1]) > Convert.ToInt32(listBox4.Items[j]))
                    {
                        int temp = Convert.ToInt32(listBox4.Items[j - 1]);
                        listBox4.Invoke(new Action(() => listBox4.Items[j - 1] = Convert.ToInt32(listBox4.Items[j])));
                        listBox4.Invoke(new Action(() => listBox4.Items[j] = temp));
                        swap3++;
                    }
                }
            }

            stopWatch3.Stop();
            TimeSpan ts3 = stopWatch3.Elapsed;
            string elapsedTime3 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
             ts3.Hours, ts3.Minutes, ts3.Seconds,
            ts3.Milliseconds / 10);
            label13.Invoke(new Action(() => label13.Text = elapsedTime3));
            label12.Invoke(new Action(() => label12.Text = pass3.ToString() + "  " + swap3.ToString()));
            label11.Invoke(new Action(() => label11.Text = "Сортировка закончена"));
        }


        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            fillNumbers();
           
            Thread t = new Thread(sortBubble);
            t.Start();
            Thread t2 = new Thread(shellSort);
            t2.Start();
            Thread t3 = new Thread(InsertionSort);
            t3.Start();

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

    }
}