using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;

namespace IEToolBar
{
    class EFilingDALCP204 : EFilingDAL
    {
        public EFilingDALCP204()
        {
        }

        public EFilingDALCP204(string strTaxPayer, string strYA, string strAuditor, string strTaxAgent)
        {
            this.strTaxPayer = strTaxPayer;
            this.strYA = strYA;
            this.strAuditor = strAuditor;
            this.strTaxAgent = strTaxAgent;
        }

        public DataSet GetFormDataCP204(string strPage)
        {
            string strQuery = "";
            OdbcCommand cmdOdbc = new OdbcCommand();
            OdbcDataAdapter daOdbc;
            DataTable dtTemp = new DataTable();
            DataSet dsData = new DataSet();

            try
            {
                if (connOdbc.State == ConnectionState.Closed)
                    connOdbc.Open();
                //switch (strPage)
                //{
                //   case "CP2042009Page1":
                strQuery = "select bcp_correspond_add1, bcp_correspond_add2, bcp_correspond_add3, bcp_correspond_post, bcp_correspond_city, bcp_correspond_state, bcp_curr_corr_add1, bcp_curr_corr_add2, bcp_curr_corr_add3, bcp_curr_corr_post, bcp_curr_corr_city, bcp_curr_corr_state, bcp_estimated_tax, convert(nvarchar(20), bcp_newco_date, 103), bcp_indicate, convert(nvarchar(20), bcp_acc_period_fr, 103), convert(nvarchar(20), bcp_acc_period_to, 103), convert(nvarchar(20), bcp_basis_period_fr, 103), convert(nvarchar(20), bcp_basis_period_to, 103), convert(nvarchar(20), bcp_newco_bas_fr, 103), convert(nvarchar(20), bcp_newco_bas_to, 103), convert(nvarchar(20), bcp_newco_bas_sub_fr, 103), convert(nvarchar(20), bcp_newco_bas_sub_to, 103), convert(nvarchar(20), bcp_sme_period_fr, 103), convert(nvarchar(20), bcp_sme_period_to, 103) from borang_cp204 where bcp_ref_no=? and bcp_ya=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P1_BORANG_CP204");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select ta_add_line1, ta_add_line2, ta_add_line3, ta_add_postcode, ta_add_city, ta_add_state, ta_tel_no, ta_roc_no, ta_email from taxa_profile where ta_co_name=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxagent", strTaxAgent.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P1_FIRM");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        
                //        break;
                    
                //}
            }
            catch (Exception ex)
            { System.Windows.Forms.MessageBox.Show(ex.ToString()); }
            return dsData;
        }

    }
}
