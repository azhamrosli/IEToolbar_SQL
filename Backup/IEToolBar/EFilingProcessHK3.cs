using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace IEToolBar
{
    class EFilingProcessHK3
    {
        Boolean boolFilled = false;
        int intIndex;
        string[] strData;
        string strYA = "";

        public EFilingProcessHK3()
        {
        }

        public EFilingProcessHK3(string[] strData , string strYA)
        {
            //this.dtTemp1 = DateTime.Parse(dgEFHK3.SelectedRows[0].Cells[0].Value.ToString());
            //this.dtTemp2 = DateTime.Parse(dgEFHK3.SelectedRows[0].Cells[1].Value.ToString());
            this.strData = new string[9];
            this.strData[0] = strData[0].ToString();
            this.strData[1] = strData[1].ToString();
            this.strData[2] = strData[2].ToString();
            this.strData[3] = strData[3].ToString();
            this.strData[4] = strData[4].ToString();
            this.strData[5] = strData[5].ToString();
            this.strData[6] = strData[6].ToString();
            this.strData[7] = strData[7].ToString();
            //strData[7] = dgEFHK3.SelectedRows[0].Cells[7].Value.ToString();
            this.strData[8] = strData[8].ToString();
            this.strYA = strYA;
        }

        public void ProcessDocument(mshtml.HTMLDocument htmlDoc)
        {
            switch (this.strYA)
            {
                case "2008":
                    ProcessFormHK32008(htmlDoc);
                    break;
                case "2009":
                    ProcessFormHK32009(htmlDoc);
                    break;
                case "2010":
                    ProcessFormHK32010(htmlDoc);
                    break;
                //LEESH FEB 2012
                case "2011":
                    ProcessFormHK32011(htmlDoc);
                    break;
                //LEESH END
                case "2012":
                    ProcessFormHK32012(htmlDoc);
                    break;
            }
        }

        private void ProcessFormHK32008(mshtml.HTMLDocument htmlDoc)
        {
            boolFilled = false;
            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("textarea"))
            {
                switch (inpElement1.name)
                {
                    case "GridView1$ctl01$txtEmpty_nama_syarikat":
                        inpElement1.value = strData[3].ToString().ToUpper();
                        break;
                }
            }
            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("input"))
            {
                if (inpElement1.name == "txtfaedah")
                {
                    inpElement1.value = strData[8];
                    inpElement1.blur();
                    break;
                }
            }
            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("input"))
            {
                switch (inpElement1.name)
                {
                    case "GridView1$ctl01$txtEmpty_tkh_bayaran":
                        inpElement1.value = strData[0];
                        boolFilled = true;
                        break;
                    case "GridView1$ctl01$txtEmpty_bg_thn_berakhir":
                        inpElement1.value = strData[1];
                        break;
                    case "GridView1$ctl01$txtEmpty_no_waran_siri":
                        inpElement1.value = strData[2];
                        break;
                    case "GridView1$ctl01$txtEmpty_div_kasar":
                        inpElement1.value = strData[4];
                        break;
                    case "GridView1$ctl01$txtEmpty_kadar_cukai":
                        inpElement1.value = strData[5];
                        break;
                    case "GridView1$ctl01$txtEmpty_cukai_dipotong":
                        inpElement1.value = strData[6];
                        break;
                    //case "GridView1$ctl01$txtEmpty_div_bersih":
                    //    inpElement1.value = strData[7];
                    //    break;
                    //case "GridView1$ctl01$txtEmpty_div_bersih2":
                    //    inpElement1.value = strData[8];
                    //    break;  
                    //case "txtfaedah":
                    //    inpElement1.value = strData[8];
                    //    inpElement1.blur();
                    //    break;
                    case "GridView1$ctl01$btnEmpty_Add":
                        inpElement1.click();
                        break;

                }
            }
            for (intIndex = 3; ; intIndex++)
            {
                if (boolFilled == true)
                { break; }
                else
                {
                    string strWaranNo = "GridView1$ctl" + intIndex.ToString("0#") + "$txtno_waran_siri_Add";
                    string strCompanyName = "GridView1$ctl" + intIndex.ToString("0#") + "$txtnama_syarikat_Add";
                    string strPaymentDate = "GridView1$ctl" + intIndex.ToString("0#") + "$txtTkh_bayaran_Add";
                    string strYearEnd = "GridView1$ctl" + intIndex.ToString("0#") + "$txtbg_thn_berakhir_Add";
                    string strGrossDiv = "GridView1$ctl" + intIndex.ToString("0#") + "$txtdiv_kasar_Add";
                    string strTaxRate = "GridView1$ctl" + intIndex.ToString("0#") + "$txtkadar_cukai_Add";
                    string strTaxDeduct = "GridView1$ctl" + intIndex.ToString("0#") + "$txtcukai_dipotong_Add";
                    //string strFaedah = "txtfaedah";
                    //string strNetDiv = "GridView1$ctl" + intIndex.ToString("0#") + "$txtdiv_bersih_Add";

                    foreach (mshtml.HTMLInputElement inpElement2 in htmlDoc.getElementsByTagName("input"))
                    {
                        if (inpElement2.name.ToString() == strWaranNo)
                        {
                            inpElement2.value = strData[2];
                            boolFilled = true;
                        }
                        else if (inpElement2.name.ToString() == strCompanyName)
                        {
                            inpElement2.value = strData[3].ToString().ToUpper();
                        }
                        else if (inpElement2.name.ToString() == strPaymentDate)
                        {
                            inpElement2.value = strData[0];
                        }
                        else if (inpElement2.name.ToString() == strYearEnd)
                        {
                            inpElement2.value = strData[1];
                        }
                        else if (inpElement2.name.ToString() == strGrossDiv)
                        {
                            inpElement2.value = strData[4];
                        }
                        else if (inpElement2.name.ToString() == strTaxRate)
                        {
                            inpElement2.value = strData[5];
                        }
                        else if (inpElement2.name.ToString() == strTaxDeduct)
                        {
                            inpElement2.value = strData[6];
                        }
                        //else if (inpElement2.name.ToString() == strFaedah)
                        //{
                        //    inpElement2.value = strData[8];
                        //}
                        //else if (inpElement2.name.ToString() == strNetDiv)
                        //{
                        //    inpElement2.value = strData[7];
                        //}
                    }
                }
            }

            if (boolFilled == true)
            {
                intIndex = intIndex - 1;
                string strLnkAdd = "GridView1_ctl" + intIndex.ToString("0#") + "_btnTambahFooter";
                foreach (mshtml.HTMLAnchorElement ancElement in htmlDoc.getElementsByTagName("a"))
                {
                    if (ancElement.id != null)
                    {
                        if (ancElement.id.ToString() == strLnkAdd)
                        {
                            ancElement.click();
                        }
                    }
                }
            }
        }

        private void ProcessFormHK32009(mshtml.HTMLDocument htmlDoc)
        {
            boolFilled = false;
            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("textarea"))
            {
                switch (inpElement1.name)
                {
                    case "GridView1$ctl01$txtEmpty_nama_syarikat":
                        inpElement1.value = strData[3].ToString().ToUpper();
                        break;
                }
            }
            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("input"))
            {
                if (inpElement1.name == "txtfaedah")
                {
                    inpElement1.value = strData[8];
                    inpElement1.blur();
                    break;
                }
            }
            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("input"))
            {
                switch (inpElement1.name)
                {
                    case "GridView1$ctl01$txtEmpty_tkh_bayaran":
                        inpElement1.value = strData[0];
                        boolFilled = true;
                        break;
                    case "GridView1$ctl01$txtEmpty_bg_thn_berakhir":
                        inpElement1.value = strData[1];
                        break;
                    case "GridView1$ctl01$txtEmpty_no_waran_siri":
                        inpElement1.value = strData[2];
                        break;
                    case "GridView1$ctl01$txtEmpty_div_kasar":
                        inpElement1.value = strData[4];
                        break;
                    case "GridView1$ctl01$txtEmpty_kadar_cukai":
                        inpElement1.value = strData[5];
                        break;
                    case "GridView1$ctl01$txtEmpty_cukai_dipotong":
                        inpElement1.value = strData[6];
                        break;
                    //case "GridView1$ctl01$txtEmpty_div_bersih":
                    //    inpElement1.value = strData[7];
                    //    break;
                    //case "GridView1$ctl01$txtEmpty_div_bersih2":
                    //    inpElement1.value = strData[8];
                    //    break;  
                    //case "txtfaedah":
                    //    inpElement1.value = strData[8];
                    //    inpElement1.blur();
                    //    break;
                    case "GridView1$ctl01$btnEmpty_Add":
                        inpElement1.click();
                        break;

                }
            }
            for (intIndex = 3; ; intIndex++)
            {
                if (boolFilled == true)
                { break; }
                else
                {
                    string strWaranNo = "GridView1$ctl" + intIndex.ToString("0#") + "$txtno_waran_siri_Add";
                    string strCompanyName = "GridView1$ctl" + intIndex.ToString("0#") + "$txtnama_syarikat_Add";
                    string strPaymentDate = "GridView1$ctl" + intIndex.ToString("0#") + "$txtTkh_bayaran_Add";
                    string strYearEnd = "GridView1$ctl" + intIndex.ToString("0#") + "$txtbg_thn_berakhir_Add";
                    string strGrossDiv = "GridView1$ctl" + intIndex.ToString("0#") + "$txtdiv_kasar_Add";
                    string strTaxRate = "GridView1$ctl" + intIndex.ToString("0#") + "$txtkadar_cukai_Add";
                    string strTaxDeduct = "GridView1$ctl" + intIndex.ToString("0#") + "$txtcukai_dipotong_Add";
                    //string strFaedah = "txtfaedah";
                    string strNetDiv = "GridView1$ctl" + intIndex.ToString("0#") + "$txtdiv_bersih_Add";

                    foreach (mshtml.HTMLInputElement inpElement2 in htmlDoc.getElementsByTagName("textarea"))
                    {
                        if (inpElement2.name.ToString() == strCompanyName)
                        {
                            inpElement2.value = strData[3].ToString().ToUpper();
                        }
                    }
                    foreach (mshtml.HTMLInputElement inpElement2 in htmlDoc.getElementsByTagName("input"))
                    {
                        if (inpElement2.name.ToString() == strWaranNo)
                        {
                            inpElement2.value = strData[2];
                            boolFilled = true;
                        }
                        else if (inpElement2.name.ToString() == strPaymentDate)
                        {
                            inpElement2.value = strData[0];
                        }
                        else if (inpElement2.name.ToString() == strYearEnd)
                        {
                            inpElement2.value = strData[1];
                        }
                        else if (inpElement2.name.ToString() == strGrossDiv)
                        {
                            inpElement2.value = strData[4];
                        }
                        else if (inpElement2.name.ToString() == strTaxRate)
                        {
                            inpElement2.value = strData[5];
                        }
                        else if (inpElement2.name.ToString() == strTaxDeduct)
                        {
                            inpElement2.value = strData[6];
                        }
                        //else if (inpElement2.name.ToString() == strFaedah)
                        //{
                        //    inpElement2.value = strData[8];
                        //}
                        else if (inpElement2.name.ToString() == strNetDiv)
                        {
                            inpElement2.value = strData[7];
                        }
                    }
                }
            }

            if (boolFilled == true)
            {
                intIndex = intIndex - 1;
                string strLnkAdd = "GridView1_ctl" + intIndex.ToString("0#") + "_btnTambahFooter";
                foreach (mshtml.HTMLAnchorElement ancElement in htmlDoc.getElementsByTagName("a"))
                {
                    if (ancElement.id != null)
                    {
                        if (ancElement.id.ToString() == strLnkAdd)
                        {
                            ancElement.click();
                        }
                    }
                }
            }
        }

        private void ProcessFormHK32010(mshtml.HTMLDocument htmlDoc)
        {
            boolFilled = false;
            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("textarea"))
            {
                switch (inpElement1.name)
                {
                    case "GridView1$ctl01$txtEmpty_nama_syarikat":
                        inpElement1.value = strData[3].ToString().ToUpper();
                        break;
                }
            }
            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("input"))
            {
                if (inpElement1.name == "txtfaedah")
                {
                    inpElement1.value = strData[8];
                    inpElement1.blur();
                    break;
                }
            }
            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("input"))
            {
                switch (inpElement1.name)
                {
                    case "GridView1$ctl01$txtEmpty_tkh_bayaran":
                        inpElement1.value = strData[0];
                        boolFilled = true;
                        break;
                    case "GridView1$ctl01$txtEmpty_bg_thn_berakhir":
                        inpElement1.value = strData[1];
                        break;
                    case "GridView1$ctl01$txtEmpty_no_waran_siri":
                        inpElement1.value = strData[2];
                        break;
                    case "GridView1$ctl01$txtEmpty_div_kasar":
                        inpElement1.value = strData[4];
                        break;
                    case "GridView1$ctl01$txtEmpty_kadar_cukai":
                        inpElement1.value = strData[5];
                        break;
                    case "GridView1$ctl01$txtEmpty_cukai_dipotong":
                        inpElement1.value = strData[6];
                        break;
                    //case "GridView1$ctl01$txtEmpty_div_bersih":
                    //    inpElement1.value = strData[7];
                    //    break;
                    //case "GridView1$ctl01$txtEmpty_div_bersih2":
                    //    inpElement1.value = strData[8];
                    //    break;  
                    //case "txtfaedah":
                    //    inpElement1.value = strData[8];
                    //    inpElement1.blur();
                    //    break;
                    case "GridView1$ctl01$btnEmpty_Add":
                        inpElement1.click();
                        break;

                }
            }
            for (intIndex = 3; ; intIndex++)
            {
                if (boolFilled == true)
                { break; }
                else
                {
                    string strWaranNo = "GridView1$ctl" + intIndex.ToString("0#") + "$txtno_waran_siri_Add";
                    string strCompanyName = "GridView1$ctl" + intIndex.ToString("0#") + "$txtnama_syarikat_Add";
                    string strPaymentDate = "GridView1$ctl" + intIndex.ToString("0#") + "$txtTkh_bayaran_Add";
                    string strYearEnd = "GridView1$ctl" + intIndex.ToString("0#") + "$txtbg_thn_berakhir_Add";
                    string strGrossDiv = "GridView1$ctl" + intIndex.ToString("0#") + "$txtdiv_kasar_Add";
                    string strTaxRate = "GridView1$ctl" + intIndex.ToString("0#") + "$txtkadar_cukai_Add";
                    string strTaxDeduct = "GridView1$ctl" + intIndex.ToString("0#") + "$txtcukai_dipotong_Add";
                    //string strFaedah = "txtfaedah";
                    string strNetDiv = "GridView1$ctl" + intIndex.ToString("0#") + "$txtdiv_bersih_Add";

                    foreach (mshtml.HTMLInputElement inpElement2 in htmlDoc.getElementsByTagName("textarea"))
                    {
                        if (inpElement2.name.ToString() == strCompanyName)
                        {
                            inpElement2.value = strData[3].ToString().ToUpper();
                        }
                    }
                    foreach (mshtml.HTMLInputElement inpElement2 in htmlDoc.getElementsByTagName("input"))
                    {
                        if (inpElement2.name.ToString() == strWaranNo)
                        {
                            inpElement2.value = strData[2];
                            boolFilled = true;
                        }
                        else if (inpElement2.name.ToString() == strPaymentDate)
                        {
                            inpElement2.value = strData[0];
                        }
                        else if (inpElement2.name.ToString() == strYearEnd)
                        {
                            inpElement2.value = strData[1];
                        }
                        else if (inpElement2.name.ToString() == strGrossDiv)
                        {
                            inpElement2.value = strData[4];
                        }
                        else if (inpElement2.name.ToString() == strTaxRate)
                        {
                            inpElement2.value = strData[5];
                        }
                        else if (inpElement2.name.ToString() == strTaxDeduct)
                        {
                            inpElement2.value = strData[6];
                        }
                        //else if (inpElement2.name.ToString() == strFaedah)
                        //{
                        //    inpElement2.value = strData[8];
                        //}
                        else if (inpElement2.name.ToString() == strNetDiv)
                        {
                            inpElement2.value = strData[7];
                        }
                    }
                }
            }

            if (boolFilled == true)
            {
                intIndex = intIndex - 1;
                string strLnkAdd = "GridView1_ctl" + intIndex.ToString("0#") + "_btnTambahFooter";
                foreach (mshtml.HTMLAnchorElement ancElement in htmlDoc.getElementsByTagName("a"))
                {
                    if (ancElement.id != null)
                    {
                        if (ancElement.id.ToString() == strLnkAdd)
                        {
                            ancElement.click();
                        }
                    }
                }
            }
        }

        private void ProcessFormHK32011(mshtml.HTMLDocument htmlDoc)
        {
            //LEESH FEB 2012
            boolFilled = false;
            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("textarea"))
            {
                switch (inpElement1.name)
                {
                    case "GridView1$ctl01$txtEmpty_nama_syarikat":
                        inpElement1.value = strData[3].ToString().ToUpper();
                        break;
                }
            }
            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("input"))
            {
                if (inpElement1.name == "txtfaedah")
                {
                    inpElement1.value = strData[8];
                    inpElement1.blur();
                    break;
                }
            }
            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("input"))
            {
                switch (inpElement1.name)
                {
                    case "GridView1$ctl01$txtEmpty_tkh_bayaran":
                        inpElement1.value = strData[0];
                        boolFilled = true;
                        break;
                    case "GridView1$ctl01$txtEmpty_bg_thn_berakhir":
                        inpElement1.value = strData[1];
                        break;
                    case "GridView1$ctl01$txtEmpty_no_waran_siri":
                        inpElement1.value = strData[2];
                        break;
                    case "GridView1$ctl01$txtEmpty_div_kasar":
                        inpElement1.value = strData[4];
                        break;
                    case "GridView1$ctl01$txtEmpty_kadar_cukai":
                        inpElement1.value = strData[5];
                        break;
                    case "GridView1$ctl01$txtEmpty_cukai_dipotong":
                        inpElement1.value = strData[6];
                        break;
                    //case "GridView1$ctl01$txtEmpty_div_bersih":
                    //    inpElement1.value = strData[7];
                    //    break;
                    //case "GridView1$ctl01$txtEmpty_div_bersih2":
                    //    inpElement1.value = strData[8];
                    //    break;  
                    //case "txtfaedah":
                    //    inpElement1.value = strData[8];
                    //    inpElement1.blur();
                    //    break;
                    case "GridView1$ctl01$btnEmpty_Add":
                        inpElement1.click();
                        break;

                }
            }
            for (intIndex = 3; ; intIndex++)
            {
                if (boolFilled == true)
                { break; }
                else
                {
                    string strWaranNo = "GridView1$ctl" + intIndex.ToString("0#") + "$txtno_waran_siri_Add";
                    string strCompanyName = "GridView1$ctl" + intIndex.ToString("0#") + "$txtnama_syarikat_Add";
                    string strPaymentDate = "GridView1$ctl" + intIndex.ToString("0#") + "$txtTkh_bayaran_Add";
                    string strYearEnd = "GridView1$ctl" + intIndex.ToString("0#") + "$txtbg_thn_berakhir_Add";
                    string strGrossDiv = "GridView1$ctl" + intIndex.ToString("0#") + "$txtdiv_kasar_Add";
                    string strTaxRate = "GridView1$ctl" + intIndex.ToString("0#") + "$txtkadar_cukai_Add";
                    string strTaxDeduct = "GridView1$ctl" + intIndex.ToString("0#") + "$txtcukai_dipotong_Add";
                    //string strFaedah = "txtfaedah";
                    string strNetDiv = "GridView1$ctl" + intIndex.ToString("0#") + "$txtdiv_bersih_Add";

                    foreach (mshtml.HTMLInputElement inpElement2 in htmlDoc.getElementsByTagName("textarea"))
                    {
                        if (inpElement2.name.ToString() == strCompanyName)
                        {
                            inpElement2.value = strData[3].ToString().ToUpper();
                        }
                    }
                    foreach (mshtml.HTMLInputElement inpElement2 in htmlDoc.getElementsByTagName("input"))
                    {
                        if (inpElement2.name.ToString() == strWaranNo)
                        {
                            inpElement2.value = strData[2];
                            boolFilled = true;
                        }
                        else if (inpElement2.name.ToString() == strPaymentDate)
                        {
                            inpElement2.value = strData[0];
                        }
                        else if (inpElement2.name.ToString() == strYearEnd)
                        {
                            inpElement2.value = strData[1];
                        }
                        else if (inpElement2.name.ToString() == strGrossDiv)
                        {
                            inpElement2.value = strData[4];
                        }
                        else if (inpElement2.name.ToString() == strTaxRate)
                        {
                            inpElement2.value = strData[5];
                        }
                        else if (inpElement2.name.ToString() == strTaxDeduct)
                        {
                            inpElement2.value = strData[6];
                        }
                        //else if (inpElement2.name.ToString() == strFaedah)
                        //{
                        //    inpElement2.value = strData[8];
                        //}
                        else if (inpElement2.name.ToString() == strNetDiv)
                        {
                            inpElement2.value = strData[7];
                        }
                    }
                }
            }

            if (boolFilled == true)
            {
                intIndex = intIndex - 1;
                string strLnkAdd = "GridView1_ctl" + intIndex.ToString("0#") + "_btnTambahFooter";
                foreach (mshtml.HTMLAnchorElement ancElement in htmlDoc.getElementsByTagName("a"))
                {
                    if (ancElement.id != null)
                    {
                        if (ancElement.id.ToString() == strLnkAdd)
                        {
                            ancElement.click();
                        }
                    }
                }
                //LEESH END
            }
        }

        private void ProcessFormHK32012(mshtml.HTMLDocument htmlDoc)
        {
            //LEESH FEB 2012
            boolFilled = false;
            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("textarea"))
            {
                switch (inpElement1.name)
                {
                    case "GridView1$ctl01$txtEmpty_nama_syarikat":
                        inpElement1.value = strData[3].ToString().ToUpper();
                        break;
                }
            }
            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("input"))
            {
                if (inpElement1.name == "txtfaedah")
                {
                    inpElement1.value = strData[8];
                    inpElement1.blur();
                    break;
                }
            }
            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("input"))
            {
                switch (inpElement1.name)
                {
                    case "GridView1$ctl01$txtEmpty_tkh_bayaran":
                        inpElement1.value = strData[0];
                        boolFilled = true;
                        break;
                    case "GridView1$ctl01$txtEmpty_bg_thn_berakhir":
                        inpElement1.value = strData[1];
                        break;
                    case "GridView1$ctl01$txtEmpty_no_waran_siri":
                        inpElement1.value = strData[2];
                        break;
                    case "GridView1$ctl01$txtEmpty_div_kasar":
                        inpElement1.value = strData[4];
                        break;
                    case "GridView1$ctl01$txtEmpty_kadar_cukai":
                        inpElement1.value = strData[5];
                        break;
                    case "GridView1$ctl01$txtEmpty_cukai_dipotong":
                        inpElement1.value = strData[6];
                        break;
                    //case "GridView1$ctl01$txtEmpty_div_bersih":
                    //    inpElement1.value = strData[7];
                    //    break;
                    //case "GridView1$ctl01$txtEmpty_div_bersih2":
                    //    inpElement1.value = strData[8];
                    //    break;  
                    //case "txtfaedah":
                    //    inpElement1.value = strData[8];
                    //    inpElement1.blur();
                    //    break;
                    case "GridView1$ctl01$btnEmpty_Add":
                        inpElement1.click();
                        break;

                }
            }
            for (intIndex = 3; ; intIndex++)
            {
                if (boolFilled == true)
                { break; }
                else
                {
                    string strWaranNo = "GridView1$ctl" + intIndex.ToString("0#") + "$txtno_waran_siri_Add";
                    string strCompanyName = "GridView1$ctl" + intIndex.ToString("0#") + "$txtnama_syarikat_Add";
                    string strPaymentDate = "GridView1$ctl" + intIndex.ToString("0#") + "$txtTkh_bayaran_Add";
                    string strYearEnd = "GridView1$ctl" + intIndex.ToString("0#") + "$txtbg_thn_berakhir_Add";
                    string strGrossDiv = "GridView1$ctl" + intIndex.ToString("0#") + "$txtdiv_kasar_Add";
                    string strTaxRate = "GridView1$ctl" + intIndex.ToString("0#") + "$txtkadar_cukai_Add";
                    string strTaxDeduct = "GridView1$ctl" + intIndex.ToString("0#") + "$txtcukai_dipotong_Add";
                    //string strFaedah = "txtfaedah";
                    string strNetDiv = "GridView1$ctl" + intIndex.ToString("0#") + "$txtdiv_bersih_Add";

                    foreach (mshtml.HTMLInputElement inpElement2 in htmlDoc.getElementsByTagName("textarea"))
                    {
                        if (inpElement2.name.ToString() == strCompanyName)
                        {
                            inpElement2.value = strData[3].ToString().ToUpper();
                        }
                    }
                    foreach (mshtml.HTMLInputElement inpElement2 in htmlDoc.getElementsByTagName("input"))
                    {
                        if (inpElement2.name.ToString() == strWaranNo)
                        {
                            inpElement2.value = strData[2];
                            boolFilled = true;
                        }
                        else if (inpElement2.name.ToString() == strPaymentDate)
                        {
                            inpElement2.value = strData[0];
                        }
                        else if (inpElement2.name.ToString() == strYearEnd)
                        {
                            inpElement2.value = strData[1];
                        }
                        else if (inpElement2.name.ToString() == strGrossDiv)
                        {
                            inpElement2.value = strData[4];
                        }
                        else if (inpElement2.name.ToString() == strTaxRate)
                        {
                            inpElement2.value = strData[5];
                        }
                        else if (inpElement2.name.ToString() == strTaxDeduct)
                        {
                            inpElement2.value = strData[6];
                        }
                        //else if (inpElement2.name.ToString() == strFaedah)
                        //{
                        //    inpElement2.value = strData[8];
                        //}
                        else if (inpElement2.name.ToString() == strNetDiv)
                        {
                            inpElement2.value = strData[7];
                        }
                    }
                }
            }

            if (boolFilled == true)
            {
                intIndex = intIndex - 1;
                string strLnkAdd = "GridView1_ctl" + intIndex.ToString("0#") + "_btnTambahFooter";
                foreach (mshtml.HTMLAnchorElement ancElement in htmlDoc.getElementsByTagName("a"))
                {
                    if (ancElement.id != null)
                    {
                        if (ancElement.id.ToString() == strLnkAdd)
                        {
                            ancElement.click();
                        }
                    }
                }
                //LEESH END
            }
        }

    }


}
