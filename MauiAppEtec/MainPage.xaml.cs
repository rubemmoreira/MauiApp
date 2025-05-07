using System;

namespace MauiAppEtec
{
    public partial class MainPage : ContentPage
    {
        string vez = "X";
        int jogadas = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (!string.IsNullOrEmpty(btn.Text)) // Se o botão já foi clicado
                return;

            btn.Text = vez;
            jogadas++;

            // Verificar vitória
            if (VerificarVitoria(vez))
            {
                DisplayAlert("Parabéns!", $"O {vez} ganhou!", "OK");
                Zerar();
                return;
            }

            // Verificar empate
            if (jogadas == 9)
            {
                DisplayAlert("Empate!", "O jogo terminou sem vencedor.", "OK");
                Zerar();
                return;
            }

            // Alternar jogador
            vez = vez == "X" ? "O" : "X";
        }

        private bool VerificarVitoria(string jogador)
        {
            // Verificar linhas
            if (btn10.Text == jogador && btn11.Text == jogador && btn12.Text == jogador) return true;
            if (btn20.Text == jogador && btn21.Text == jogador && btn22.Text == jogador) return true;
            if (btn30.Text == jogador && btn31.Text == jogador && btn32.Text == jogador) return true;

            // Verificar colunas
            if (btn10.Text == jogador && btn20.Text == jogador && btn30.Text == jogador) return true;
            if (btn11.Text == jogador && btn21.Text == jogador && btn31.Text == jogador) return true;
            if (btn12.Text == jogador && btn22.Text == jogador && btn32.Text == jogador) return true;

            // Verificar diagonais
            if (btn10.Text == jogador && btn21.Text == jogador && btn32.Text == jogador) return true;
            if (btn12.Text == jogador && btn21.Text == jogador && btn30.Text == jogador) return true;

            return false;
        }

        void Zerar()
        {
            // Lista de todos os botões do jogo da velha
            var buttons = new List<Button> { btn10, btn11, btn12, btn20, btn21, btn22, btn30, btn31, btn32 };

            foreach (var btn in buttons)
            {
                btn.Text = "";
                btn.IsEnabled = true;
            }

            vez = "X";
            jogadas = 0;
        }
    }
}