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
    /// <summary>
    /// Esempio di utilizzo del servizio WS FILL per la verifica e la normalizzazione degli indirizzi italiani 
    /// 
    /// L'end point del servizio è 
    ///     http://ec2-46-137-97-173.eu-west-1.compute.amazonaws.com/smws/fill?wsdl
    ///     
    /// Per l'utilizzo registrarsi sul sito http://streetmaster.it e richiedere la chiave per il servizio FILL 
    /// 
    ///  2016 - Software by StreetMaster (c)
    /// </summary>
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
                MessageBox.Show("E' necessario specificare una chiave valida per il servizio FILL");
                txtKey.Focus();
                return;
            }

            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            // oggetto client per l'utilizzo del ws FILL
            var fillObj = new FillWS.FillClient();

            // classe di input
            var inFill = new FillWS.inputCommon();

            // valorizzazione input
            inFill.localita = txtInComune.Text;
            inFill.cap = txtInCap.Text;
            inFill.provincia = txtInProvincia.Text;
            inFill.indirizzo = txtInIndirizzo.Text;

            // chiamata al servizio
            totOutFillWS = fillObj.Fill(inFill, txtKey.Text);

            // lettura campi generali del risultato
            txtOutEsito.Text = totOutFillWS.norm.ToString();
            txtOutCodErr.Text = totOutFillWS.codErr.ToString();
            txtOutNumCand.Text = totOutFillWS.numCand.ToString();

            currCand = 0;

            // dettaglio del primo candidato se esiste
            // nella form di output e' riportato solo un sottoinsieme di tutti i valori restituiti
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
            // dettaglio del successivo candidato se esiste
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
            // dettagli del precedente candidato se esiste
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
