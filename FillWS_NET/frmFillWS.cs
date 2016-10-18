using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FillWS_NET
{
    public partial class frmFillWS : Form
    {
        int currCand = 0;
        
        FillWS.totOutFill totOutFillWS;
        public frmFillWS()
        {
            InitializeComponent();
        }

        private void btnCallVerify_Click(object sender, EventArgs e)
        {
            
            if (txtKey.Text==String.Empty)
            {
                MessageBox.Show("E' necessario specificare una chiave valida per il servizio Verify");
                txtKey.Focus();
                return;
            }

            Cursor = Cursors.WaitCursor;
            Application.DoEvents();
            var fillObj = new FillWS.FillClient();

            var inFill = new FillWS.inputCommon();

            inFill.localita = txtInComune.Text;
            inFill.cap = txtInCap.Text;
            inFill.provincia = txtInProvincia.Text;

            inFill.indirizzo = txtInIndirizzo.Text;

            totOutFillWS = fillObj.Fill(inFill, txtKey.Text);

            txtOutEsito.Text = totOutFillWS.norm.ToString();
            txtOutCodErr.Text = totOutFillWS.codErr.ToString();
            txtOutNumCand.Text = totOutFillWS.numCand.ToString();

            currCand = 0;
            if (totOutFillWS.numCand > 0)
            {
                txtOutCap.Text = totOutFillWS.outItem[currCand].cap;
                txtOutComune.Text = totOutFillWS.outItem[currCand].comune;
                txtOutFrazione.Text = totOutFillWS.outItem[currCand].frazione;
                txtOutIndirizzo.Text = totOutFillWS.outItem[currCand].indirizzo;
                txtOutProvincia.Text = totOutFillWS.outItem[currCand].provincia;
                txtOutScoreComune.Text = totOutFillWS.outItem[currCand].scoreComune.ToString();
                txtOutScoreStrada.Text = totOutFillWS.outItem[currCand].scoreStrada.ToString();
                txtOutX.Text = totOutFillWS.outItem[currCand].geo.x.ToString("0.#####");
                txtOutY.Text = totOutFillWS.outItem[currCand].geo.y.ToString("0.#####");
                txtOutRegione.Text = totOutFillWS.outItem[currCand].detail.regione;
                txtOutIstatProv.Text = totOutFillWS.outItem[currCand].detail.istatProv;
                txtOutIstatComune.Text = totOutFillWS.outItem[currCand].detail.istatComune;
            }
            Cursor = Cursors.Default;
        }

        private void btnMovePrev_Click(object sender, EventArgs e)
        {
            if (currCand > 0)
            {
                currCand-=1;
                txtOutCap.Text = totOutFillWS.outItem[currCand].cap;
                txtOutComune.Text = totOutFillWS.outItem[currCand].comune;
                txtOutFrazione.Text = totOutFillWS.outItem[currCand].frazione;
                txtOutIndirizzo.Text = totOutFillWS.outItem[currCand].indirizzo;
                txtOutProvincia.Text = totOutFillWS.outItem[currCand].provincia;
                txtOutScoreComune.Text = totOutFillWS.outItem[currCand].scoreComune.ToString();
                txtOutScoreStrada.Text = totOutFillWS.outItem[currCand].scoreStrada.ToString();
                txtOutX.Text = totOutFillWS.outItem[currCand].geo.x.ToString("0.#####");
                txtOutY.Text = totOutFillWS.outItem[currCand].geo.y.ToString("0.#####");
                txtOutRegione.Text = totOutFillWS.outItem[currCand].detail.regione;
                txtOutIstatProv.Text = totOutFillWS.outItem[currCand].detail.istatProv;
                txtOutIstatComune.Text = totOutFillWS.outItem[currCand].detail.istatComune;
            }
        }

        private void btnMoveNext_Click(object sender, EventArgs e)
        {
            if (currCand< totOutFillWS.numCand-1)
            {
                currCand += 1;
                txtOutCap.Text = totOutFillWS.outItem[currCand].cap;
                txtOutComune.Text = totOutFillWS.outItem[currCand].comune;
                txtOutFrazione.Text = totOutFillWS.outItem[currCand].frazione;
                txtOutIndirizzo.Text = totOutFillWS.outItem[currCand].indirizzo;
                txtOutProvincia.Text = totOutFillWS.outItem[currCand].provincia;
                txtOutScoreComune.Text = totOutFillWS.outItem[currCand].scoreComune.ToString();
                txtOutScoreStrada.Text = totOutFillWS.outItem[currCand].scoreStrada.ToString();
                txtOutX.Text = totOutFillWS.outItem[currCand].geo.x.ToString("0.#####");
                txtOutY.Text = totOutFillWS.outItem[currCand].geo.y.ToString("0.#####");
                txtOutRegione.Text = totOutFillWS.outItem[currCand].detail.regione;
                txtOutIstatProv.Text = totOutFillWS.outItem[currCand].detail.istatProv;
                txtOutIstatComune.Text = totOutFillWS.outItem[currCand].detail.istatComune;
            }
        }
    
    }
}
