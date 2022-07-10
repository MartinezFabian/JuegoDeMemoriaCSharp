namespace JuegoDeMemoriaCSharp
{
    public partial class Form1 : Form
    {
        List<string> listaPalabras; 
        int movimientos = 0;
        int contadorClick = 0;
        int contadorAciertos = 0;
        const int limiteMovimientos = 30;
        Button btnClick1 = null;
        Button btnClick2 = null;
        bool timerEncendido = false;


        public Form1()
        {
            InitializeComponent();

            timer1.Enabled = false;
            timer1.Stop();

            LeerArchivo();
            AsignarPalabras();
        }

        private void LeerArchivo()
        {
            listaPalabras = new List<string>();

            FileInfo fileInfo = new FileInfo("Palabras.txt");
            FileStream fs = fileInfo.OpenRead();
            StreamReader sr = new StreamReader(fs);

            string palabra;

            while ((palabra = sr.ReadLine()) != null)
            { 
                listaPalabras.Add(palabra);
            }
        }

        private void AsignarPalabras()
        {
            //Desordenar lista palabras de forma aleatoria

            Random random = new Random();

            var listaAux = listaPalabras.OrderBy(valor => random.Next());

            listaPalabras = listaAux.ToList();

            //Asignar palabras
            btn1.Text = listaPalabras[0];
            btn2.Text = listaPalabras[1];
            btn3.Text = listaPalabras[2];
            btn4.Text = listaPalabras[3];
            btn5.Text = listaPalabras[4];
            btn6.Text = listaPalabras[5];
            btn7.Text = listaPalabras[6];
            btn8.Text = listaPalabras[7];
            btn9.Text = listaPalabras[8];
            btn10.Text = listaPalabras[9];

            //Desordenar lista palabras de forma aleatoria

            random = new Random();

            listaAux = listaPalabras.OrderBy(valor => random.Next());

            listaPalabras = listaAux.ToList();

            //Asignar palabras
            btn11.Text = listaPalabras[0];
            btn12.Text = listaPalabras[1];
            btn13.Text = listaPalabras[2];
            btn14.Text = listaPalabras[3];
            btn15.Text = listaPalabras[4];
            btn16.Text = listaPalabras[5];
            btn17.Text = listaPalabras[6];
            btn18.Text = listaPalabras[7];
            btn19.Text = listaPalabras[8];
            btn20.Text = listaPalabras[9];
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (!timerEncendido)
            {
                if (movimientos < limiteMovimientos)
                {
                    if (contadorClick == 0)
                    {
                        contadorClick++;

                        btnClick1 = (Button)sender;

                        btnClick1.BackColor = Color.White;
                    }
                    else if (contadorClick == 1)
                    {
                        contadorClick++;

                        btnClick2 = (Button)sender;

                        btnClick2.BackColor = Color.White;
                    }

                    if (contadorClick == 2)
                    {
                        contadorClick = 0;
                        movimientos++;
                        lblMovimientos.Text = "Movimientos: " + movimientos.ToString();

                        if (btnClick1.Text == btnClick2.Text)
                        {
                            contadorAciertos++;

                            if (contadorAciertos == 10)
                            {

                                if (MessageBox.Show("Ganaste! ¿Jugar de Nuevo?", ":)",
                                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    ReiniciarJuego();
                                }
                                else
                                {
                                    Environment.Exit(0);
                                }
                            }
                        }
                        else
                        {
                            timer1.Enabled = true;
                            timer1.Start();
                            timerEncendido = true;
                        }
                    }
                }
                else
                {
                    if (MessageBox.Show("Perdiste! ¿Jugar de Nuevo?", ":C",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        ReiniciarJuego();
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btnClick1.BackColor = Color.DarkSlateGray;
            btnClick2.BackColor = Color.DarkSlateGray;

            timer1.Stop();

            timerEncendido = false;
        }

        private void ReiniciarJuego()
        {
            btn1.BackColor = Color.DarkSlateGray;
            btn2.BackColor = Color.DarkSlateGray;
            btn3.BackColor = Color.DarkSlateGray;
            btn4.BackColor = Color.DarkSlateGray;
            btn5.BackColor = Color.DarkSlateGray;
            btn6.BackColor = Color.DarkSlateGray;
            btn7.BackColor = Color.DarkSlateGray;
            btn8.BackColor = Color.DarkSlateGray;
            btn9.BackColor = Color.DarkSlateGray;
            btn10.BackColor = Color.DarkSlateGray;
            btn11.BackColor = Color.DarkSlateGray;
            btn12.BackColor = Color.DarkSlateGray;
            btn13.BackColor = Color.DarkSlateGray;
            btn14.BackColor = Color.DarkSlateGray;
            btn15.BackColor = Color.DarkSlateGray;
            btn16.BackColor = Color.DarkSlateGray;
            btn17.BackColor = Color.DarkSlateGray;
            btn18.BackColor = Color.DarkSlateGray;
            btn19.BackColor = Color.DarkSlateGray;
            btn20.BackColor = Color.DarkSlateGray;

            movimientos = 0;
            contadorClick = 0;
            contadorAciertos = 0;

            LeerArchivo();
            AsignarPalabras();
        }
    }
}