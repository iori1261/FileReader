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
using static System.Net.Mime.MediaTypeNames;

namespace FileReader
{
    public partial class Form1 : Form
    {
        String filePath;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            //ファイルの存在をチェック
            //File.Exists(チェックしたいファイルのパス)
            OpenFileDialog fileDialog = new OpenFileDialog();
            //タイトルの設定
            fileDialog.Title = "ファイルをしてください";
            //フィルターの設定(テキストファイルのみすべてのファイル)
            fileDialog.Filter = "Text files (*.txt)|*.txt|All files(*.*)|*.*";
            //ダイアログを表示(ファイルの選択された)
            if(fileDialog.ShowDialog() == DialogResult.OK) 
            {
                filePath = fileDialog.FileName; 
            }

            //ファイルのパス情報を表示する
            lblFilePath.Text = fileDialog.FileName;

            if (File.Exists(filePath))
            {
                //ファイルの読み込みを行う
                StreamReader sr = new StreamReader(filePath);

                //全業を読み込んでtxttextに表示する
                txtText.Text = sr.ReadToEnd();

                //StreamReaderをクローズする
                sr.Close();
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            //テキストボックスの内容をファイルに保存する。
            //①書き込み前にファイルの存在チェック
            if (File.Exists(filePath))
            {
                //②対象ファイルをオープン 第2引数 true:追記 false:上書き
                StreamWriter sw = new StreamWriter(filePath,false);
                //③対象ファイルに内容を保存
                sw.Write(txtText.Text);
                //④使用後はクローズ
                sw.Close();

            }
        }
    }
}
