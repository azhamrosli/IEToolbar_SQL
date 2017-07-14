using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;

namespace IEToolBar
{
    public class EFilingDALM2016 : EFilingDALB
    {
        public EFilingDALM2016()
        {
        }

        public EFilingDALM2016(string strTaxPayer, string strYA, string strTaxAgent)
        {
            this.strTaxPayer = strTaxPayer;
            this.strYA = strYA;
            this.strTaxAgent = strTaxAgent;
        }

        public DataSet GetFormDataM2016(string strPage)
        {
            string strQuery = "";
            OdbcCommand cmdOdbc = new OdbcCommand();
            OdbcDataAdapter daOdbc;
            DataTable dtTemp = new DataTable();
            DataSet dsData = new DataSet();
            string ErrorLog = "";
            try
            {
                if (connOdbc.State == ConnectionState.Closed)
                    connOdbc.Open();
                switch (strPage)
                {
                    case "M2016Page1":
                        ErrorLog = "P1_TAX_PROFILE";
                        strQuery = "SELECT TP_PASSPORT_NO, convert(nvarchar(20), TP_PASSWPORTDUEDATE, 103), TP_RESIDENCE, TP_COUNTRY, TP_GENDER, " +
                        "TP_STATUS, convert(nvarchar(20), TP_DATE_MARRIAGE, 103) as TP_DATE_MARRIAGE_DATA, convert(nvarchar(20), TP_DATE_DIVORCE, 103) as TP_DATE_DIVORCE_DATA, TP_TYPE_ASSESSMENT, TP_KUP, " +
                        "TP_CURR_ADD_LINE1, TP_CURR_ADD_LINE2, TP_CURR_ADD_LINE3, TP_CURR_POSTCODE, TP_CURR_CITY, " +
                        "TP_CURR_STATE, TP_REG_ADD_LINE1, TP_REG_ADD_LINE2, TP_REG_ADD_LINE3, TP_REG_POSTCODE, " +
                        "TP_REG_CITY, TP_REG_STATE, TP_COM_ADD_LINE1, TP_COM_ADD_LINE2, TP_COM_ADD_LINE3, " +
                        "TP_COM_POSTCODE, TP_COM_CITY, TP_COM_STATE, TP_TEL1, TP_TEL2, " +
                        "TP_EMAIL, TP_BANK, TP_BANK_ACC, TP_EMPLOYERNAME, TP_EMPLOYER_NO2, " +
                        "TP_EMPLOYER_NO3, TP_ASSESSMENTON " +
                        "FROM TAXP_PROFILE WHERE TP_5=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P1_TAX_PROFILE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P1_TAXP_PROFILE2";
                        //weihong FORMAT(TP_WORKER_APPROVEDATE)
                        strQuery = "SELECT convert(nvarchar(20), TP_DOB, 103), convert(nvarchar(20), TP_WORKER_APPROVEDATE, 103), TP_COM_ADD_STATUS ,[TP_BWA],[TP_LHDNM_BRANCH],[TP_BUSINESS_ECOMMERCE],[TP_JKDM],[TP_DISPOSAL1976],[TP_LDMN_DISPOSAL],[TP_GST],[TP_TEL_KOD],[TP_MOBILE_KOD],[TP_FAX_KOD],[TP_MOTHER_IC],[TP_FATHER_IC] " +
                        "FROM TAXP_PROFILE2 WHERE TP_REF_NO=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P1_TAXP_PROFILE2");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P1_TAX_PROFILE_OTHERS";
                        strQuery = "SELECT TP_BWA FROM TAXP_PROFILE2 WHERE TP_REF_NO=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P1_TAX_PROFILE_OTHERS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P1_ADJUSTED_LOSS";
                        strQuery = "select sum(cast(tca_cbl as money)) from tax_adjusted_loss where tc_key in (select tc_key from tax_computation where tc_ref_no =? and tc_ya=?)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P1_ADJUSTED_LOSS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P2_TAX_PROFILE";
                        //====== PAGE 2 ========================================================
                        strQuery = "SELECT TP_HW_NAME, TP_HW_REF_NO_PREFIX, TP_HW_REF_NO1, TP_HW_REF_NO2, TP_HW_REF_NO3, " +
                        "TP_HW_IC_NEW1, TP_HW_IC_NEW2, TP_HW_IC_NEW3, TP_HW_POLICE_NO, TP_HW_ARMY_NO, " +
                        "TP_HW_PASSPORT_NO, convert(nvarchar(20), TP_PASSWPORTDUEDATE2, 103) " +
                        "FROM TAXP_PROFILE WHERE TP_5=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P2_TAX_PROFILE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P2_TAXP_PROFILE2";
                        strQuery = "SELECT TP_HW_LAST_PASSPORT_NO, convert(nvarchar(20), TP_HW_DOB, 103),TP_BUSINESS_ECOMMERCE,TP_JKDM,TP_DISPOSAL1976,TP_LDMN_DISPOSAL,TP_GST,TP_TEL_KOD,TP_MOBILE_KOD,TP_FAX_KOD,TP_MOTHER_IC,TP_FATHER_IC,TP_BWA,TP_DOB " +
                        "FROM TAXP_PROFILE2 WHERE TP_REF_NO=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P2_TAXP_PROFILE2");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P2_TAX_PROFILE_HW_OTHERS";
                        //lyeyc
                        strQuery = "SELECT TP_HW_NAME, TP_HW_REF_NO_PREFIX, TP_HW_REF_NO1, TP_HW_REF_NO2, TP_HW_REF_NO3, TP_HW_IC_NEW1, TP_HW_IC_NEW2, TP_HW_IC_NEW3, TP_HW_POLICE_NO, TP_HW_ARMY_NO, TP_HW_PASSPORT_NO, TP_HW_TYPEOFINCOME, convert(nvarchar(20), TP_PASSWPORTDUEDATE2, 103), convert(nvarchar(20), TP_HW_DOB, 103) FROM TAXP_PROFILE_HW_OTHERS WHERE TP_REF_NO=? ORDER BY TP_HW_ORDER";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P2_TAX_PROFILE_HW_OTHERS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P3_INCOME_ADJUSTED";
                        //== PAGE 3 ============================================================
                        strQuery = "SELECT ADJ_BUSINESS, ADJSI_NET_STAT_INCOME " +
                        "FROM INCOME_ADJUSTED WHERE ADJ_REF_NO=? AND ADJ_YA=? ORDER BY ADJ_BUSINESS";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_INCOME_ADJUSTED");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P3_INCOME_OTHERSOURCE";
                        //weihong
                        strQuery = "SELECT OS_RT_SEC4A_RENTAL, OS_OTHER_GAINS_TOTAL, OS_PENSION_AND_ETC, OS_SEC4A, OS_RY_GROSS_ROYALTY110, OS_RY_ROYALTY_INCOME, OS_INT_GROSS_RECEIVED, OS_INT_LOAN, OS_RT_GROSS_RENTAL, OS_DV_GROSS_DIVIDEND " +
                        "FROM INCOME_OTHERSOURCE WHERE OS_REF_NO=? AND OS_YA=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_INCOME_OTHERSOURCE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        //weihong

                        ErrorLog = "P3_BUSINESS_SOURCE";
                        strQuery = "SELECT BC_CODE, BC_SOURCEKEY, BC_BUSINESSSOURCE " +
                        "FROM BUSINESS_SOURCE WHERE BC_KEY=? AND BC_YA=? ORDER BY BC_SOURCEKEY";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_BUSINESS_SOURCE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        dsData.Tables["P3_BUSINESS_SOURCE"].PrimaryKey = new DataColumn[] { dsData.Tables["P3_BUSINESS_SOURCE"].Columns["BC_BUSINESSSOURCE"] };
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P3_INCOME_PARTNERSHIP";
                        strQuery = "SELECT PS_SOURCE, PS_SCH_7A_STAT_INCOME " +
                        "FROM INCOME_PARTNERSHIP WHERE PN_REF_NO=? AND PN_YA=? ORDER BY PS_SOURCE";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_INCOME_PARTNERSHIP");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P3_TAXP_PARTNERSHIP";
                        strQuery = "SELECT PS_FILE_NO2, PS_FILE_NO3, PS_SOURCEKEY, PS_SOURCENO " +
                        "FROM TAXP_PARTNERSHIP WHERE PS_KEY=? AND PS_YA=? ORDER BY PS_SOURCEKEY";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_TAXP_PARTNERSHIP");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        dsData.Tables["P3_TAXP_PARTNERSHIP"].PrimaryKey = new DataColumn[] { dsData.Tables["P3_TAXP_PARTNERSHIP"].Columns["PS_SOURCENO"] };
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P3_TAX_COMPUTATION";
                        //weihong
                        //0 TC_BUSINESSLOSS_BF
                        //1 TC_EMPLOYMENT_INCOME
                        //2 TC_EXEMPT_CLAIM
                        //3 TC_EXEMPT_COUNTRY
                        //4 TC_DIVIDEND
                        //5 TC_INTEREST
                        //6 TC_DISCOUNT
                        //7 TC_RENTAL_ROYALTY
                        //8 TC_PREMIUM
                        //9 TC_PENSION_AND_ETC
                        //10 TC_OTHER_GAIN_PROFIT
                        //11 TC_SEC4A
                        //12 TC_ADDITION_43
                        //13 TC_BUSINESSLOSS_CY
                        //14 TC_3
                        //15 TC_INCOME_TRANSFER_FROM_HW
                        //16 TC_INSTALLMENT_PAYMENT_SELF
                        //17 TC_INSTALLMENT_PAYMENT_HW
                        //18 TC_PROSPECTING
                        //19 TC_EXEMPT_AMOUNT
                        //20 TC_HK3_TRANSFER_FROM_HW
                        //21 TC_EXHK3_TRANSFER_FROM_HW
                        strQuery = "SELECT TC_BUSINESSLOSS_BF, TC_EMPLOYMENT_INCOME, TC_EXEMPT_CLAIM, TC_EXEMPT_COUNTRY, TC_DIVIDEND, " +
                        "TC_INTEREST, TC_DISCOUNT, TC_RENTAL_ROYALTY, TC_PREMIUM, TC_PENSION_AND_ETC, " +
                        "TC_OTHER_GAIN_PROFIT, TC_SEC4A, TC_ADDITION_43, TC_BUSINESSLOSS_CY, TC_3, " +
                        "TC_INCOME_TRANSFER_FROM_HW, TC_INSTALLMENT_PAYMENT_SELF, TC_INSTALLMENT_PAYMENT_HW, TC_PROSPECTING, TC_EXEMPT_AMOUNT, TC_HK3_TRANSFER_FROM_HW, TC_EXHK3_TRANSFER_FROM_HW,TC_DONATION_GIFT " +
                        "FROM TAX_COMPUTATION WHERE TC_REF_NO=? AND TC_YA=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_TAX_COMPUTATION");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P3_RENTAL";
                        //LEESH 2016
                        strQuery = "select os_rt_rental_bf from income_othersource where os_ref_no =? and os_ya =?";
                        //LEESH END
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_RENTAL");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P3_INCOME_EXCLUDE_RENTAL";
                        strQuery = "SELECT ((cast(TAX_COMPUTATION.TC_INTEREST as money)+cast(TAX_COMPUTATION.TC_DISCOUNT as money)+" +
                        "cast(TAX_COMPUTATION.TC_RENTAL_ROYALTY as money)+cast(TAX_COMPUTATION.TC_PREMIUM as money)+" +
                        "cast(TAX_COMPUTATION.TC_PENSION_AND_ETC as money)+cast(TAX_COMPUTATION.TC_OTHER_GAIN_PROFIT as money)+" +
                        "cast(TAX_COMPUTATION.TC_SEC4A as money))- cast(INCOME_OTHERSOURCE.OS_RT_RENTAL_BF as money )) " +
                        "FROM TAX_COMPUTATION INNER JOIN INCOME_OTHERSOURCE " +
                        "ON TAX_COMPUTATION.TC_REF_NO=INCOME_OTHERSOURCE.OS_REF_NO " +
                        "AND TAX_COMPUTATION.TC_YA = INCOME_OTHERSOURCE.OS_YA " +
                        "WHERE TAX_COMPUTATION.TC_REF_NO=? AND TAX_COMPUTATION.TC_YA=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_INCOME_EXCLUDE_RENTAL");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P3_CHARGEABLE_INCOME";
                        strQuery = "SELECT INTEREST, ROYALTIES, SECTION4A, OTHERINCOME, TOTALGROSSINCOME " +
                        "FROM CHARGEABLE_INCOME WHERE TC_KEY IN (SELECT TC_KEY FROM TAX_COMPUTATION WHERE TC_REF_NO=? and TC_YA=?)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_CHARGEABLE_INCOME");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P3_TAX_GIFTS";
                        strQuery = "select SUM(cast(TCG_AMOUNT as money)) " +
                        "FROM TAX_GIFTS WHERE TC_KEY IN (SELECT TC_KEY FROM TAX_COMPUTATION WHERE TC_REF_NO=? and TC_YA=?)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_TAX_GIFTS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        dsData.Tables["P3_TAX_GIFTS"].PrimaryKey = new DataColumn[] { dsData.Tables["P3_TAX_GIFTS"].Columns["TCG_KEY"] };
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        //strQuery = "SELECT TOP 5 PY_INCOME_TYPE, PY_PAYMENT_YEAR, PY_AMOUNT, PY_EPF " +
                        //"FROM PRECEDING_YEAR_DETAIL WHERE PY_KEY IN (SELECT PY_KEY FROM PRECEDING_YEAR WHERE PY_REF_NO=? and PY_YA=?) ORDER BY PY_DKEY";
                        //cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        //daOdbc = new OdbcDataAdapter(cmdOdbc);
                        //dtTemp = new DataTable("P3_PRECEDING_YEAR_DETAIL");
                        //daOdbc.Fill(dtTemp);
                        //dsData.Tables.Add(dtTemp);
                        //daOdbc.Dispose();
                        //cmdOdbc.Dispose();

                        ErrorLog = "P3_TAX_PROFILE";
                        strQuery = "SELECT TP_HW_NAME, TP_HW_REF_NO_PREFIX, TP_HW_REF_NO1, TP_HW_REF_NO2, TP_HW_REF_NO3, " +
                        "TP_HW_IC_NEW1, TP_HW_IC_NEW2, TP_HW_IC_NEW3, TP_HW_POLICE_NO, TP_HW_ARMY_NO, " +
                        "TP_HW_PASSPORT_NO, TP_HW_TYPEOFINCOME " +
                        "FROM TAXP_PROFILE WHERE TP_5=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_TAX_PROFILE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        //NGOHCS B2010.2 
                        ErrorLog = "P3_TAX_PROFILE_OTHER";
                        strQuery = "SELECT TP_HW_NAME, TP_HW_REF_NO_PREFIX, TP_HW_REF_NO1, TP_HW_REF_NO2, TP_HW_REF_NO3, " +
                        "TP_HW_IC_NEW1, TP_HW_IC_NEW2, TP_HW_IC_NEW3, TP_HW_POLICE_NO, TP_HW_ARMY_NO, " +
                        "TP_HW_PASSPORT_NO, TP_HW_TYPEOFINCOME " +
                        "FROM TAXP_PROFILE_HW_OTHERS WHERE TP_REF_NO=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_TAX_PROFILE_OTHER");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        //NGOHCS B2010.2 END

                        ErrorLog = "P3_INCOME_EMPLOYMENT";
                        //weihong Gross income from employment case "M2010Page3":
                        strQuery = "select EI_SCHEDULE1, EI_GROSS from INCOME_EMPLOYMENT where EI_REF_NO=? and EI_YA=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_INCOME_EMPLOYMENT");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        //weihong

                        ErrorLog = "P3_PROFIT_LOSS_ACCOUNT";
                        //weihong Total gross income from all source 
                        strQuery = "select PL_SALES from PROFIT_LOSS_ACCOUNT where PL_REF_NO=? and PL_YA=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_PROFIT_LOSS_ACCOUNT");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        //weihong

                        //simkh 2016
                        ErrorLog = "P3_PRECEDING_YEAR_DETAIL";
                        strQuery = "SELECT TOP 5 PY_INCOME_TYPE, PY_PAYMENT_YEAR, PY_AMOUNT, PY_EPF " +
                       "FROM PRECEDING_YEAR_DETAIL WHERE PY_KEY IN (SELECT PY_KEY FROM PRECEDING_YEAR WHERE PY_REF_NO=? and PY_YA=?) ORDER BY PY_DKEY";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_PRECEDING_YEAR_DETAIL");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        //simkh end

                        //== PAGE 5============================================================
                        ErrorLog = "P4_CHARGEABLE_INCOME";
                        strQuery = "SELECT CHARGEABLE0, CHARGEABLE1, CHARGEABLE2, CHARGEABLE3, CHARGEABLE4, " +
                        "CHARGEABLE5, CHARGEABLE6, RATE1 " +
                        "FROM CHARGEABLE_INCOME WHERE TC_KEY IN (SELECT TC_KEY FROM TAX_COMPUTATION WHERE TC_REF_NO=? and TC_YA=?)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_CHARGEABLE_INCOME");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P3_TAX_REBATE";
                        strQuery = "SELECT TCR_KEY, TCR_AMOUNT " +
                        "FROM TAX_REBATE WHERE TC_KEY IN (SELECT TC_KEY FROM TAX_COMPUTATION WHERE TC_REF_NO=? and TC_YA=?) ORDER BY TCR_KEY";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_TAX_REBATE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        dsData.Tables["P3_TAX_REBATE"].PrimaryKey = new DataColumn[] { dsData.Tables["P3_TAX_REBATE"].Columns["TCR_KEY"] };
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P4_TAX_COMPUTATION";
                        strQuery = "SELECT TC_SEC110_DIVIDEND, TC_SEC110_OTHERS, TC_SEC130, TC_2 " +
                        "FROM TAX_COMPUTATION WHERE TC_REF_NO=? AND TC_YA=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_TAX_COMPUTATION");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P5_TAX_COMPUTATION";
                        //== PAGE 6============================================================
                        strQuery = "SELECT TC_AL_CY_UNASORBED_LOSS, TC_AL_BAL_UNASORBED_LOSS, TC_PIONEER, TC_PIONEER_CF,TC_AL_BALANCE_CF " +
                        "FROM TAX_COMPUTATION WHERE TC_REF_NO=? AND TC_YA=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P5_TAX_COMPUTATION");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P5_INCOME_ADJUSTED";
                        strQuery = "SELECT ADCA_UTIL, ADCA_BAL_CF" +
                        " FROM INCOME_ADJUSTED WHERE ADJ_REF_NO=? AND ADJ_YA=? ORDER BY ADJ_BUSINESS";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P5_INCOME_ADJUSTED");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P5_INCOME_PARTNERSHIP";
                        strQuery = "SELECT PSCA_UTIL, PSCA_BAL_CF" +
                        " FROM INCOME_PARTNERSHIP WHERE PN_REF_NO=? AND PN_YA=? ORDER BY PS_SOURCE";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P5_INCOME_PARTNERSHIP");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P5_NON_RESIDENT";
                        strQuery = "SELECT NR_SECTION, NR_GROSS_TOTAL, NR_WITHHOLD, NR_WITHHOLD_107A " +
                        "FROM NON_RESIDENT WHERE NR_REF_NO=? AND NR_YA=? ORDER BY NR_SECTION";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P5_NON_RESIDENT");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        dsData.Tables["P5_NON_RESIDENT"].PrimaryKey = new DataColumn[] { dsData.Tables["P5_NON_RESIDENT"].Columns["NR_SECTION"] };
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P5_ADJUSTED_LOSS";
                        strQuery = "select sum(cast(tca_cbl as money)) from tax_adjusted_loss where tc_key in (select tc_key from tax_computation where tc_ref_no =? and tc_ya=?)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P5_ADJUSTED_LOSS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P6_INCOME_ADJ_FURTHER";
                        //== PAGE 7==============================================================
                        strQuery = "SELECT ADJD_CLAIM_CODE, ADJD_AMOUNT " +
                                                "FROM INCOME_ADJ_FURTHER WHERE ADJ_KEY IN (SELECT ADJ_KEY FROM INCOME_ADJUSTED WHERE ADJ_REF_NO=? and ADJ_YA=?) ORDER BY ADJD_NO";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P6_INCOME_ADJ_FURTHER");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P6_TAX_INCENTIVE_CLAIM";
                        strQuery = "SELECT TIC_KEY, TIC_CF " +
                        "FROM TAX_INCENTIVE_CLAIM WHERE TC_KEY IN (SELECT TC_KEY FROM TAX_COMPUTATION WHERE TC_REF_NO=? and TC_YA=?) ORDER BY TIC_KEY";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P6_TAX_INCENTIVE_CLAIM");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        dsData.Tables["P6_TAX_INCENTIVE_CLAIM"].PrimaryKey = new DataColumn[] { dsData.Tables["P6_TAX_INCENTIVE_CLAIM"].Columns["TIC_KEY"] };
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        //== PAGE 8==============================================================
                        ErrorLog = "P7_MAIN_PROFIT_LOSS_ACCOUNT";
                        strQuery = "SELECT PL_SALES, PL_OP_STK, PL_PURCHASES_PRO_COST, PL_CLS_STK, PL_OTH_BSIN, " +
                        "PL_1, PL_4, PL_2, PL_3, PL_5, " +
                        "PL_NT_INCOME, PL_EXP_LOANINTEREST, PL_EXP_SALARY, PL_EXP_RENTAL,PL_EXP_CONTRACT, " +
                        "PL_EXP_COMMISSION, PL_BAD_DEBTS, PL_TRAVEL, PL_REP_MAINT, PL_PRO_ADV, " +
                        "PL_TOT_EXP, PL_DISALLOWED_EXP, PL_JKDM " +
                        "FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO =? AND PL_YA =? AND PL_MAINCOMPANY = '1' ORDER BY PL_KEY";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_MAIN_PROFIT_LOSS_ACCOUNT");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P7_PROFIT_LOSS_ACCOUNT";
                        strQuery = "SELECT PL_SALES, PL_OP_STK, PL_PURCHASES_PRO_COST, PL_CLS_STK, PL_OTH_BSIN, " +
                        "PL_1, PL_4, PL_2, PL_3, PL_5, " +
                        "PL_NT_INCOME, PL_EXP_LOANINTEREST, PL_EXP_SALARY, PL_EXP_RENTAL,PL_EXP_CONTRACT, " +
                        "PL_EXP_COMMISSION, PL_BAD_DEBTS, PL_TRAVEL, PL_REP_MAINT, PL_PRO_ADV, " +
                        "PL_TOT_EXP, PL_DISALLOWED_EXP, PL_JKDM " +
                        "FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO =? AND PL_YA =? ORDER BY PL_KEY";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_PROFIT_LOSS_ACCOUNT");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        // csNgoh BEfiling SU7
                        ErrorLog = "P7_MAIN_EXPENSES_OTHER";
                        strQuery = "SELECT sum(cast([exa_amount] as money)) FROM [PL_EXPENSES] WHERE [EXA_KEY] IN " +
                        "(SELECT PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? AND PL_MAINCOMPANY = '1') " +
                        "AND (EXA_PLTYPE BETWEEN 18 AND 20 OR EXA_PLTYPE = 46)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_MAIN_EXPENSES_OTHER");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P7_EXPENSES_OTHER";
                        strQuery = "SELECT sum(cast([exa_amount] as money)) FROM [PL_EXPENSES] WHERE [EXA_KEY] IN " +
                        "(SELECT TOP 1 PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? ORDER BY PL_KEY) " +
                        "AND (EXA_PLTYPE BETWEEN 18 AND 20 OR EXA_PLTYPE = 46)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_EXPENSES_OTHER");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P7_MAIN_LOSS_NONALLOW";
                        strQuery = "SELECT sum(cast([exa_amount] as money)) FROM [PL_EXP_NONALLOWLOSS] WHERE [EXA_KEY] IN " +
                        "(SELECT PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? AND PL_MAINCOMPANY = '1')";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_MAIN_LOSS_NONALLOW");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P7_LOSS_NONALLOW";
                        strQuery = "SELECT sum(cast([exa_amount] as money)) FROM [PL_EXP_NONALLOWLOSS] WHERE [EXA_KEY] IN " +
                        "(SELECT TOP 1 PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? ORDER BY PL_KEY)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_LOSS_NONALLOW");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P7_MAIN_EXPENSES_NONALLOW";
                        strQuery = "SELECT sum(cast([exa_amount] as money)) FROM [PL_EXP_NONALLOWEXPEND] WHERE [EXA_KEY] IN " +
                        "(SELECT PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? AND PL_MAINCOMPANY = '1')";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_MAIN_EXPENSES_NONALLOW");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P7_EXPENSES_NONALLOW";
                        strQuery = "SELECT sum(cast([exa_amount] as money)) FROM [PL_EXP_NONALLOWEXPEND] WHERE [EXA_KEY] IN " +
                        "(SELECT TOP 1 PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? ORDER BY PL_KEY)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_EXPENSES_NONALLOW");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P7_MAIN_EXPENSES_PERSONAL";
                        strQuery = "SELECT sum(cast([exa_amount] as money)) FROM [PL_EXP_PERSONAL] WHERE [EXA_KEY] IN " +
                        "(SELECT PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? AND PL_MAINCOMPANY = '1')";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_MAIN_EXPENSES_PERSONAL");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P7_EXPENSES_PERSONAL";
                        strQuery = "SELECT sum(cast([exa_amount] as money)) FROM [PL_EXP_PERSONAL] WHERE [EXA_KEY] IN " +
                        "(SELECT TOP 1 PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? ORDER BY PL_KEY)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_EXPENSES_PERSONAL");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P7_MAIN_BUSINESS_SOURCE";
                        strQuery = "SELECT BC_BUS_ENTITY, BC_CODE, BC_COMPANY,BC_TYPE " +
                        "FROM BUSINESS_SOURCE WHERE BC_KEY =? AND BC_YA =? AND BC_BUSINESSSOURCE IN " +
                        "(SELECT PL_MAIN_BUSINESS FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? AND PL_MAINCOMPANY = '1') ";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));

                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_MAIN_BUSINESS_SOURCE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        //ErrorLog = "P7_MAIN_BUSINESS_SOURCE";
                        //strQuery = "SELECT BC_BUS_ENTITY, BC_CODE, BC_COMPANY, BC_TYPE " +
                        //"FROM BUSINESS_SOURCE WHERE BC_KEY =? AND BC_YA =? AND BC_BUSINESSSOURCE IN " +
                        //"(SELECT PL_MAIN_BUSINESS FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? AND PL_MAINCOMPANY = '1' ORDER BY PL_KEY) ";
                        //cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                        //daOdbc = new OdbcDataAdapter(cmdOdbc);
                        //dtTemp = new DataTable("P7_MAIN_BUSINESS_SOURCE");
                        //daOdbc.Fill(dtTemp);
                        //dsData.Tables.Add(dtTemp);
                        //daOdbc.Dispose();
                        //cmdOdbc.Dispose();

                        ErrorLog = "P7_BUSINESS_SOURCE";
                        strQuery = "SELECT BC_BUS_ENTITY, BC_CODE, BC_COMPANY, BC_TYPE " +
                        "FROM BUSINESS_SOURCE WHERE BC_KEY =? AND BC_YA =? AND BC_BUSINESSSOURCE IN " +
                        "(SELECT TOP 1 PL_MAIN_BUSINESS FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? ORDER BY PL_KEY) ";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_BUSINESS_SOURCE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();


                        // csNgoh BEFiling2008
                        ErrorLog = "P7_MAIN_PNL";
                        strQuery = "select pl_key from profit_loss_account where pl_ref_no = ? and pl_ya = ? and pl_key not in " +
                        "(SELECT PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? " +
                        "AND PL_MAINCOMPANY = '1')";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_MAIN_PNL");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P7_OTHER_PNL";
                        strQuery = "select pl_key from profit_loss_account where pl_ref_no = ? and pl_ya = ? and pl_key not in " +
                        "(SELECT TOP 1 PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? " +
                        "AND PL_YA=? ORDER BY PL_KEY)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_OTHER_PNL");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P7_MAIN_INCOME_OTHERBUSINESS";
                        strQuery = "select sum(cast(exa_amount as money)) from pl_income_otherbusiness where exa_key = " +
                        "(SELECT PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? " +
                        "AND PL_MAINCOMPANY = '1')";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_MAIN_INCOME_OTHERBUSINESS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P7_INCOME_OTHERBUSINESS";
                        strQuery = "select sum(cast(exa_amount as money)) from pl_income_otherbusiness where exa_key = " +
                        "(SELECT TOP 1 PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? " +
                        "AND PL_YA=? ORDER BY PL_KEY)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_INCOME_OTHERBUSINESS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        // end csNgoh BEFiling2008

                        ErrorLog = "P7_MAIN_PROFIT_LOSS_ACCOUNT_GROSS";
                        strQuery = "SELECT (SUM(cast(PL_SALES as money)) - (SUM(cast(PL_OP_STK as money)) + SUM(cast(PL_PURCHASES_PRO_COST as money)) - SUM(cast(PL_CLS_STK as money)))) " +
                        "FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO =? AND PL_YA =? AND PL_KEY NOT IN " +
                        "(SELECT PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? AND PL_MAINCOMPANY = '1')";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_MAIN_PROFIT_LOSS_ACCOUNT_GROSS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P7_PROFIT_LOSS_ACCOUNT_GROSS";
                        strQuery = "SELECT (SUM(cast(PL_SALES as money)) - (SUM(cast(PL_OP_STK as money)) + SUM(cast(PL_PURCHASES_PRO_COST as money)) - SUM(cast(PL_CLS_STK as money)))) " +
                        "FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO =? AND PL_YA =? AND PL_KEY NOT IN " +
                        "(SELECT TOP 1 PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? ORDER BY PL_KEY)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_PROFIT_LOSS_ACCOUNT_GROSS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P7_MAIN_BALANCE_SHEET";
                        strQuery = "SELECT BS_LAND, BS_MACHINERY, BS_TRANSPORT, BS_OTH_FA, BS_INVESTMENT, " +
                        "BS_STOCK, BS_TRADE_DEBTORS, BS_OTH_DEBTORS, BS_CASH, BS_BANK, " +
                        "BS_OTH_CA, BS_LOAN, BS_TRADE_CR, BS_OTHER_CR, BS_CAPITALACCOUNT, " +
                        "BS_BROUGHT_FORWARD, BS_CY_PROFITLOSS, BS_CAP_CONTRIBUTION, BS_DRAWING, BS_CARRIED_FORWARD, " +
                        "BS_OTH_LIAB, BS_LT_LIAB " +
                        "FROM BALANCE_SHEET WHERE BS_REF_NO =? AND BS_YA =? AND BS_SOURCENO IN " +
                        "(SELECT PL_MAIN_BUSINESS FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? AND PL_MAINCOMPANY = '1') ORDER BY BS_SOURCENO";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_MAIN_BALANCE_SHEET");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P7_BALANCE_SHEET";
                        strQuery = "SELECT BS_LAND, BS_MACHINERY, BS_TRANSPORT, BS_OTH_FA, BS_INVESTMENT, " +
                        "BS_STOCK, BS_TRADE_DEBTORS, BS_OTH_DEBTORS, BS_CASH, BS_BANK, " +
                        "BS_OTH_CA, BS_LOAN, BS_TRADE_CR, BS_OTHER_CR, BS_CAPITALACCOUNT, " +
                        "BS_BROUGHT_FORWARD, BS_CY_PROFITLOSS, BS_CAP_CONTRIBUTION, BS_DRAWING, BS_CARRIED_FORWARD, " +
                        "BS_OTH_LIAB, BS_LT_LIAB " +
                        "FROM BALANCE_SHEET WHERE BS_REF_NO =? AND BS_YA =? AND BS_SOURCENO IN " +
                        "(SELECT PL_MAIN_BUSINESS FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=?) ORDER BY BS_SOURCENO";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_BALANCE_SHEET");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P7_MAIN_PL_EXPENSES";
                        strQuery = "SELECT sum(cast(exa_amount as money)) " +
                        "FROM PL_EXPENSES WHERE EXA_KEY IN " +
                        "(SELECT PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? AND PL_MAINCOMPANY = '1') AND [EXA_DEDUCTIBLE]='No'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_MAIN_PL_EXPENSES");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P7_PL_EXPENSES";
                        strQuery = "SELECT sum(cast(exa_amount as money)) " +
                        "FROM PL_EXPENSES WHERE EXA_KEY IN " +
                        "(SELECT TOP 1 PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? ORDER BY PL_KEY) AND [EXA_DEDUCTIBLE]='No'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_PL_EXPENSES");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P7_MAIN_PL_EXP_NONALLOWEXPEND";
                        strQuery = "SELECT sum(cast(exa_amount as money)) " +
                        "FROM PL_EXP_NONALLOWEXPEND WHERE EXA_KEY IN " +
                        "(SELECT PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? AND PL_MAINCOMPANY = '1') AND [EXA_DEDUCTIBLE]='No'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_MAIN_PL_EXP_NONALLOWEXPEND");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P7_PL_EXP_NONALLOWEXPEND";
                        strQuery = "SELECT sum(cast(exa_amount as money)) " +
                        "FROM PL_EXP_NONALLOWEXPEND WHERE EXA_KEY IN " +
                        "(SELECT TOP 1 PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? ORDER BY PL_KEY) AND [EXA_DEDUCTIBLE]='No'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_PL_EXP_NONALLOWEXPEND");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P7_MAIN_PL_EXP_PERSONAL";
                        strQuery = "SELECT sum(cast(exa_amount as money)) " +
                        "FROM PL_EXP_PERSONAL WHERE EXA_KEY IN " +
                        "(SELECT PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? AND PL_MAINCOMPANY = '1') AND [EXA_DEDUCTIBLE]='No'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_MAIN_PL_EXP_PERSONAL");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P7_PL_EXP_PERSONAL";
                        strQuery = "SELECT sum(cast(exa_amount as money)) " +
                        "FROM PL_EXP_PERSONAL WHERE EXA_KEY IN " +
                        "(SELECT TOP 1 PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? ORDER BY PL_KEY) AND [EXA_DEDUCTIBLE]='No'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_PL_EXP_PERSONAL");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P7_MAIN_PL_PRODUCTION_COST";
                        strQuery = "SELECT sum(cast(exa_amount as money)) " +
                        "FROM PL_PRODUCTION_COST WHERE EXA_KEY IN " +
                        "(SELECT PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? AND PL_MAINCOMPANY = '1') AND [EXA_DEDUCTIBLE]='No' and (EXA_PLTYPE = 43 or EXA_PLTYPE = 45)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_MAIN_PL_PRODUCTION_COST");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P7_PL_PRODUCTION_COST";
                        strQuery = "SELECT sum(cast(exa_amount as money)) " +
                        "FROM PL_PRODUCTION_COST WHERE EXA_KEY IN " +
                        "(SELECT TOP 1 PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? ORDER BY PL_KEY) AND [EXA_DEDUCTIBLE]='No' and (EXA_PLTYPE = 43 or EXA_PLTYPE = 45)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_PL_PRODUCTION_COST");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        //== PAGE 9=================================================================
                        ErrorLog = "P8_TAXA_PROFILE";
                        strQuery = "select TA_TEL_NO " +
                       "FROM TAXA_PROFILE WHERE TA_CO_NAME=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxagent", strTaxAgent));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_TAXA_PROFILE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P8_TAXADM_PROFILE";
                        strQuery = "SELECT TP_ADM_NAME, TP_ADM_IC_NEW1, TP_ADM_IC_NEW2, TP_ADM_IC_NEW3, TP_ADM_POLICE_NO, TP_ADM_ARMY_NO, TP_ADM_PASSPORT_NO " +
                        "FROM TAXP_PROFILE WHERE TP_5=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_TAXADM_PROFILE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        //== PAGE 11 ==================================================================
                        ErrorLog = "P11_HK3_MASTER";
                        strQuery = "select convert(nvarchar(20), div_date, 106) as [Date of Payment], isnull(convert(nvarchar(20), div_year_end, 106),convert(nvarchar(20), div_date, 106)) as [Year End], div_serialno as [Waran No], div_company as [Company Name], div_gross as [Gross Dividend], DIV_RATE as [Tax Rate], "
                       + "div_tax as [Tax Deducted], div_net as [Net Dividend], os_dv_interest as [Dividend Interest]"
                       + "from income_othersource inner join income_os_dividend on income_othersource.os_key = income_os_dividend.os_key "
                       + "where income_othersource.os_ref_no =? and income_othersource.os_ya =?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P11_HK3_MASTER");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        //== PAGE 12 ===================================================================
                        ErrorLog = "P12_HK3_MASTER";
                        strQuery = "select convert(nvarchar(20), div_date, 106) as [Date of Payment], isnull(convert(nvarchar(20), div_year_end, 106),convert(nvarchar(20), div_date, 106)) as [Year End], div_serialno as [Waran No], div_company as [Company Name], div_gross as [Gross Dividend], DIV_RATE as [Tax Rate], "
                       + "div_tax as [Tax Deducted], div_net as [Net Dividend], os_dv_interest as [Dividend Interest] "
                       + "from income_othersource inner join income_os_dividend on income_othersource.os_key = income_os_dividend.os_key "
                       + "where income_othersource.os_ref_no = ? and income_othersource.os_ya =?";

                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P12_HK3_MASTER");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ErrorLog = "P12_HK3HW_MASTER";
                        strQuery = "select convert(nvarchar(20), div_date, 106) as [Date of Payment], isnull(convert(nvarchar(20), div_year_end, 106),convert(nvarchar(20), div_date, 106)) as [Year End], div_serialno as [Waran No], div_company as [Company Name], div_gross as [Gross Dividend], DIV_RATE as [Tax Rate], "
                        + "div_tax as [Tax Deducted], div_net as [Net Dividend], os_dv_interest as [Dividend Interest] "
                        + "from income_othersource inner join income_os_dividend on income_othersource.os_key = income_os_dividend.os_key "
                        + "where income_othersource.os_ref_no in (select tp_hw_ref_no1 from taxp_profile_hw_others where tp_ref_no = ? and income_othersource.os_ya =?) "
                        + "UNION select convert(nvarchar(20), div_date, 106) as [Date of Payment], isnull(convert(nvarchar(20), div_year_end, 106),convert(nvarchar(20), div_date, 106)) as [Year End], div_serialno as [Waran No], div_company as [Company Name], div_gross as [Gross Dividend], DIV_RATE as [Tax Rate], "
                        + "div_tax as [Tax Deducted], div_net as [Net Dividend], os_dv_interest as [Dividend Interest] "
                        + "from income_othersource inner join income_os_dividend on income_othersource.os_key = income_os_dividend.os_key "
                        + "where income_othersource.os_ref_no = (select tp_hw_ref_no1 from taxp_profile where (tp_ref_no1+tp_ref_no2+tp_ref_no3) = ?) and income_othersource.os_ya =?";

                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer2", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya2", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P12_HK3HW_MASTER");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        break;

                    case "M2016Page2":
                        
                        //lyeyc (end)
                        break;

                    case "M2016Page3":
                        
                        break;



                    case "M2016Page4":
                        //strQuery = "SELECT TOP 5 PY_INCOME_TYPE, PY_PAYMENT_YEAR, PY_AMOUNT, PY_EPF " +
                        //"FROM PRECEDING_YEAR_DETAIL WHERE PY_KEY IN (SELECT PY_KEY FROM PRECEDING_YEAR WHERE PY_REF_NO=? and PY_YA=?) ORDER BY PY_DKEY";
                        //cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        //daOdbc = new OdbcDataAdapter(cmdOdbc);
                        //dtTemp = new DataTable("P3_PRECEDING_YEAR_DETAIL");
                        //daOdbc.Fill(dtTemp);
                        //dsData.Tables.Add(dtTemp);
                        //daOdbc.Dispose();
                        //cmdOdbc.Dispose();
                        break;

                    case "M2016Page5":
                        
                        break;

                    case "M2016Page6":
                        
                        break;

                    case "M2016Page7":
                        
                        break;

                    case "M2016Page8":
                        
                        break;

                    case "M2016Page9":
                       
                        break;

                    case "M2016Page11":
                       
                        break;

                    case "M2016Page12":

                       
                        break;
                }
            }
            catch (Exception ex)
            { System.Windows.Forms.MessageBox.Show(ErrorLog + " || " + ex.ToString()); }
            return dsData;
        }
    }
}
