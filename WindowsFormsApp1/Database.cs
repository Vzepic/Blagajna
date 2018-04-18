using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace WindowsFormsApp1
{
    public class Database
    {
        
        public string Error;
        public SqlConnection conn = new SqlConnection();

        public Database()
        {
            conn = new SqlConnection();
        }

        public void OpenConn(string Server, string Database, string Username, string Password)
        {
            string Connectionstring;
            if (Server == "")
            {
                if (Username == "")
                {
                    Connectionstring = "Data Source=(local);Initial Catalog=" + Database + ";Integrated Security=SSPI;";
                }
                else
                {
                    Connectionstring = "Data Source=(local);Initial Catalog=" + Database + ";User ID=" + Username + ";Password=" + Password + ";";
                }
            }
            else
            {
                if (Username == "")
                {
                    Connectionstring = "Data Source=" + Server + ";Initial Catalog=" + Database + ";Integrated Security=SSPI;";
                }
                else
                {
                    Connectionstring = "Data Source=" + Server + ";Initial Catalog=" + Database + ";User ID=" + Username + ";Password=" + Password + ";";
                }
            }
            conn = new SqlConnection(Connectionstring);

            try
            {
                conn.Open();
            }
            catch (SqlException sqlEx)
            {
                if (conn != null)
                    conn.Dispose();
                Error = sqlEx.Message;
                MessageBox.Show(Error);
                return;
            }
        } //konekcija na bazu

        public void CloseConn()
        {
            conn.Close();
            conn.Dispose();
        } // zatvaranje konekcije

        public int DohvatiBrojDokumenta(string Blagajna,string VrstaKnjizenja)
        {
            //dodaj blagajnu
            int Result = new int();

            SqlCommand Dohvati = new SqlCommand();
            Dohvati.Connection = conn;
            Dohvati.CommandText = "SELECT MAX(BrojDokumenta) as Broj FROM dbo.gbbla ";
            Dohvati.CommandText += "WHERE VrstaKnjizenja LIKE '" + VrstaKnjizenja + "' ";
            Dohvati.CommandText += "AND OznakaBlagajne LIKE '" + Blagajna + "' ";

            SqlDataReader BrojReader;

            BrojReader = Dohvati.ExecuteReader();

            while (BrojReader.Read())
            {
                Result = (BrojReader["Broj"] == DBNull.Value ? 0 : Convert.ToInt32(BrojReader["Broj"]));
            }

            BrojReader.Close();
            return ++Result;
        }// dohvacanje max broja dokumenta za vrstu knjizenja i blagajnu

        public List<string> DohvatiOsobe()
        {
            List<string> Result = new List<string>();

            SqlCommand Dohvati = new SqlCommand();
            Dohvati.Connection = conn;
            Dohvati.CommandText = "SELECT Distinct(Osoba) FROM dbo.gbbla ";

            SqlDataReader OsobaReader;

            OsobaReader = Dohvati.ExecuteReader();

            while (OsobaReader.Read())
            {
                Result.Add(OsobaReader["Osoba"].ToString());
            }

            OsobaReader.Close();
            return Result;
        }// dohvacanje osoba iz blagajne

        public List<string> DohvatiKonto(string Konto)
        {
            List<string> Result = new List<string>();
            SqlCommand Dohvati = new SqlCommand();
            Dohvati.Connection = conn;
            Dohvati.CommandText = "SELECT Konto,Naziv FROM dbo.gkpl ";
            Dohvati.CommandText += "WHERE Konto LIKE '" + Konto + "%' ";
            Dohvati.CommandText += "ORDER BY [Konto] ASC";


            SqlDataReader KontoReader;

            try
            {
                KontoReader = Dohvati.ExecuteReader();
            }
            catch
            {
                MessageBox.Show("Problem sa dohvacanjem konta" + Konto);
                Result.Add(" ");
                return Result;
            }



            while (KontoReader.Read())
            {
                Result.Add(KontoReader["Konto"].ToString());
                Result.Add(KontoReader["Naziv"].ToString());
            }

            KontoReader.Close();
            return Result;
        }// dohvacanje liste konta i snaziva u formatu Result[n]=konto, Result{n+1]=naziv gdje je n=2k+1

        public List<string> DohvatiMjestoTroska()
        {
            List<string> Result = new List<string>();
            List<string> Sifre = new List<string>();
            List<string> Nazivi = new List<string>();
            SqlCommand Dohvati = new SqlCommand();
            Dohvati.Connection = conn;
            Dohvati.CommandText = "SELECT SifraMjestaTroska,NazivMjestaTroska FROM dbo.gkmt ";
            Dohvati.CommandText += "ORDER BY [Redoslijed] ASC";


            SqlDataReader MTReader;

            try
            {
                MTReader = Dohvati.ExecuteReader();
            }
            catch
            {
                MessageBox.Show("Problem sa dohvacanjem mjesta troska");
                Result.Add(" ");
                return Result;
            }



            while (MTReader.Read())
            {
                Sifre.Add(MTReader["SifraMjestaTroska"].ToString());
                Nazivi.Add(MTReader["NazivMjestaTroska"].ToString());
            }

            MTReader.Close();

            int MaxLength = 0;
            foreach (string sifra in Sifre)
            {
                if (sifra.Length > MaxLength)
                {
                    MaxLength = sifra.Length;
                }
            }

            for (int i = 0; i < Sifre.Count; i++)
            {
                string ToAdd;
                ToAdd = Sifre[i];
                for (int j = Sifre[i].Length; j <= MaxLength + 1; j++)
                {
                    ToAdd += " ";
                }
                ToAdd += "|  ";
                ToAdd += Nazivi[i];
                Result.Add(ToAdd);
            }


            return Result;
        }// dohvacanje liste sifra mjesta troska i naziva u formatu Result[n]=siframjestatroska, Result{n+1]=nazivmjestatroska gdje je n=2k+1

        public DateTime DohvatiMinDatum()
        {
            DateTime Result = new DateTime();
            SqlCommand Dohvati = new SqlCommand();
            Dohvati.Connection = conn;
            Dohvati.CommandText = "SELECT Min(DatumDokumenta) as DatumDokumenta FROM dbo.gbbla ";

            SqlDataReader DatumReader;

            try
            {
                DatumReader = Dohvati.ExecuteReader();
            }
            catch
            {
                MessageBox.Show("Problem sa dohvacanjem datuma");
                Result=DateTime.Today;
                return Result;
            }



            while (DatumReader.Read())
            {
                Result=Convert.ToDateTime(DatumReader["DatumDokumenta"]);
            }

            DatumReader.Close();

            return Result;
        }// dohvacanje min datuma unosa

        public DataTable DohvatiZaPregled(string OznakaBlagajne, string VK, DateTime DatumDokumentaOd,DateTime DatumDokumentaDo,string Operator, double Iznos, string Osoba,string Konto)
        {
            DataTable result = new DataTable();
            bool DodanUvjet = false;

            string GetResult = "SELECT * FROM dbo.gbbla as K1 WHERE";

            if (OznakaBlagajne != "")
            {
                if (DodanUvjet)
                {
                    GetResult += " AND ";
                }
                GetResult += " K1.OznakaBlagajne LIKE '" + OznakaBlagajne + "'";
                DodanUvjet = true;
            }
            if (VK != "")
            {
                if (DodanUvjet)
                {
                    GetResult += " AND ";
                }
                GetResult += " K1.VrstaKnjizenja LIKE '" + VK + "'";
                DodanUvjet = true;
            }
            if (DatumDokumentaOd != null)
            {
                if (DodanUvjet)
                {
                    GetResult += " AND ";
                }
                GetResult += " K1.DatumDokumenta >= convert(datetime,'" + DatumDokumentaOd.ToShortDateString().TrimEnd('.') + "',103)";
                DodanUvjet = true;
            }
            if (DatumDokumentaDo != null)
            {
                if (DodanUvjet)
                {
                    GetResult += " AND ";
                }
                GetResult += " K1.DatumDokumenta <= convert(datetime,'" + DatumDokumentaDo.ToShortDateString().TrimEnd('.') + "',103)";
                DodanUvjet = true;
            }
            if (Iznos >= 0)
            {
                if (DodanUvjet)
                {
                    GetResult += " AND ";
                }
                switch (Operator)
                {
                    case ("#"):
                        GetResult += " K1.Iznos !=" + Iznos.ToString();
                        break;
                    case ("="):
                        GetResult += " K1.Iznos =" + Iznos.ToString();
                        break;
                    case (">"):
                        GetResult += " K1.Iznos >" + Iznos.ToString();
                        break;
                    case ("=>"):
                        GetResult += " K1.Iznos >=" + Iznos.ToString();
                        break;
                    case ("<"):
                        GetResult += " K1.Iznos <" + Iznos.ToString();
                        break;
                    case ("=<"):
                        GetResult += " K1.Iznos <=" + Iznos.ToString();
                        break;
                }
                DodanUvjet = true;
            }
            if (Osoba != "")
            {
                if (DodanUvjet)
                {
                    GetResult += " AND ";
                }
                GetResult += " K1.Osoba LIKE '%" + Osoba + "%'";
                DodanUvjet = true;
            }
            if (Konto != "")
            {
                if (DodanUvjet)
                {
                    GetResult += " AND ";
                }
                GetResult += " K1.Konto LIKE '" + Konto + "%'";
                DodanUvjet = true;
            }

            if (!DodanUvjet)
            {
                GetResult = GetResult.Substring(0, GetResult.IndexOf("WHERE"));
            }

            GetResult += " ORDER BY K1.OznakaBlagajne, K1.DatumDokumenta, K1.VrstaKnjizenja, K1.BrojDokumenta ASC";

            SqlDataAdapter adapter = new SqlDataAdapter(GetResult, conn);

            adapter.Fill(result);

            return result;
        }//čitanje gbbla

        public string UnesiUBazu(int ID,string Blagajna, string VK, string BrojDokumenta,DateTime Datum,double Iznos, string Osoba,string OpisOsoba, string Opis, string Konto, string BrojFakture, string MjestoTroska, string sif_rad)
        {
            //sta sa null ili prazno
            SqlCommand Spremi = new SqlCommand();
            Spremi.Connection = conn;
            Spremi.CommandText = "blagajna_SP";
            Spremi.CommandType = CommandType.StoredProcedure;

            if (ID != 0)
            {
                Spremi.Parameters.Add("@Id_gbbla", SqlDbType.Int).Value = Convert.ToInt32(ID);
            }
            else
            {
                Spremi.Parameters.Add("@Id_gbbla", SqlDbType.Int).Value = 99999;
            }
            Spremi.Parameters.Add("@OznakaBlagajne", SqlDbType.NVarChar, 10).Value = Blagajna;
            Spremi.Parameters.Add("@VrstaKnjizenja", SqlDbType.NVarChar, 2).Value = VK;
            Spremi.Parameters.Add("@BrojDokumenta", SqlDbType.NVarChar, 4).Value = BrojDokumenta;
            Spremi.Parameters.Add("@DatumDokumenta", SqlDbType.DateTime).Value = Datum;
            SqlParameter iznos = new SqlParameter("@Iznos", SqlDbType.Decimal);
            iznos.Precision = 12;
            iznos.Scale = 2;
            Spremi.Parameters.Add(iznos).Value = Iznos;
            Spremi.Parameters.Add("@Osoba", SqlDbType.NVarChar, 30).Value = Osoba;
            Spremi.Parameters.Add("@OsobaOpis", SqlDbType.NVarChar, 20).Value = OpisOsoba;
            Spremi.Parameters.Add("@Opis", SqlDbType.NVarChar, 40).Value = Opis;
            Spremi.Parameters.Add("@Konto", SqlDbType.NVarChar, 8).Value = Konto;
            Spremi.Parameters.Add("@BrojFakture", SqlDbType.NVarChar, 8).Value = BrojFakture;
            Spremi.Parameters.Add("@MjestoTroska", SqlDbType.NVarChar, 4).Value = MjestoTroska;
            Spremi.Parameters.Add("@SifraRadnika", SqlDbType.NVarChar, 4).Value = sif_rad;
            Spremi.Parameters.Add("@greska", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;

            Spremi.ExecuteNonQuery();

            return Spremi.Parameters["@greska"].Value.ToString();

        }

        public void Renumeriraj()
        {
            SqlCommand Renumeriraj = new SqlCommand();
            Renumeriraj.Connection = conn;
            Renumeriraj.CommandText = "RenumeriranjeBlagajne";
            Renumeriraj.CommandType = CommandType.StoredProcedure;

            Renumeriraj.ExecuteNonQuery();
        }

        public DataTable DohvatiSaldo(DateTime DatumDokumentaDo)
        {
            DataTable result = new DataTable();

            string GetResult = "SELECT DISTINCT(Blagajne.OznakaBlagajne),(CASE	WHEN T2.Saldo IS NULL THEN 0 ELSE T2.Saldo END) as Saldo ";
            GetResult += "FROM dbo.gbbla as Blagajne ";
            GetResult += "LEFT JOIN ";
            GetResult += "(SELECT OznakaBlagajne,SUM(CASE	WHEN VrstaKnjizenja='01' THEN dbo.gbbla.Iznos ";
            GetResult += "WHEN VrstaKnjizenja='02' THEN (dbo.gbbla.Iznos)*-1 ELSE 0 END) as Saldo ";
            GetResult+= "FROM dbo.gbbla where DatumDokumenta< "+ "convert(datetime, '" + DatumDokumentaDo.ToShortDateString().TrimEnd('.') + "', 103) ";
            GetResult += "GROUP By OznakaBlagajne) as T2 ON Blagajne.OznakaBlagajne=T2.OznakaBlagajne";

            SqlDataAdapter adapter = new SqlDataAdapter(GetResult, conn);

            adapter.Fill(result);

            return result;
        }//čitanje gbbla








        public List<double> DohvatiStope(DateTime Datum)
        {
            List<double> Result = new List<double>();

            SqlCommand Dohvati = new SqlCommand();
            Dohvati.Connection = conn;
            Dohvati.CommandText = "SELECT TOP 1 nstopa1,nstopa0,nstopa5,nstopa4 FROM dbo.stope_pdv ";
            Dohvati.CommandText += "WHERE dat_vrijedi<'"+Datum.Year.ToString()+"-"+Datum.Month.ToString()+"-"+Datum.Day.ToString()+"' ";
            Dohvati.CommandText += "ORDER BY dat_vrijedi DESC";

            SqlDataReader PDVReader;

            PDVReader=Dohvati.ExecuteReader();

            while(PDVReader.Read())
            {

                Result.Add((PDVReader["nstopa1"]==DBNull.Value) ? 0 : Convert.ToDouble(PDVReader["nstopa1"]));
                Result.Add((PDVReader["nstopa0"] == DBNull.Value) ? 0 : Convert.ToDouble(PDVReader["nstopa0"]));
                Result.Add((PDVReader["nstopa5"] == DBNull.Value) ? 0 : Convert.ToDouble(PDVReader["nstopa5"]));
                Result.Add((PDVReader["nstopa4"] == DBNull.Value) ? 0 : Convert.ToDouble(PDVReader["nstopa4"]));
            }

            PDVReader.Close();
            return Result;
        }// dohvacanje stopa pdva određenog datuma

        public List<string> DohvatiSaSifrom(string SifrarnikID)
        {
            List<string> Result = new List<string>();
            List<string> Sifre = new List<string>();
            List<string> Nazivi = new List<string>();
            SqlCommand Dohvati = new SqlCommand();
            Dohvati.Connection = conn;
            Dohvati.CommandText = "SELECT sifra,tekst FROM dbo.sifarnici ";
            Dohvati.CommandText += "WHERE sifarnikid LIKE '"+SifrarnikID+"' AND aktivan='True' ";
            Dohvati.CommandText += "ORDER BY [redo] ASC";

            SqlDataReader SifraReader;

            try
            {
                SifraReader = Dohvati.ExecuteReader();
            }
            catch
            {
                MessageBox.Show("Problem sa dohvacanjem sifre" + SifrarnikID);
                Result.Add(" ");
                return Result;
            }
            

            
            while(SifraReader.Read())
            {
                Sifre.Add(SifraReader["sifra"].ToString());
                Nazivi.Add(SifraReader["tekst"].ToString());
            }

            SifraReader.Close();

            int MaxLength = 0;
            foreach(string sifra in Sifre)
            {
                if (sifra.Length>MaxLength)
                {
                    MaxLength = sifra.Length;
                }
            }

            for (int i = 0; i < Sifre.Count;i++)
            {
                string ToAdd;
                ToAdd = Sifre[i];
                for(int j=Sifre[i].Length;j<=MaxLength+1;j++)
                {
                    ToAdd += " ";
                }
                ToAdd += "|  ";
                ToAdd += Nazivi[i];
                Result.Add(ToAdd);
            }

                return Result;
        }// dohvacanje liste naziva i sifri u formatu sifra|naziv

       

        public string UnesiUBazu(string id_gksta,string vk,string bro_dok,string bro_fak,string opis,string pnb,string konto,string sif_kom,string org_jed,string vrs_rac,DateTime dat_dok,DateTime dvo, DateTime dospij,double tecaj,double iznos_v,double iznos_d,double tereti_v,double tereti_d,double uplata_v,double uplata_d,double saldo_v,double saldo_d,string rb_knj,DateTime dat_por,DateTime dat_knj,char stat_por,char ozn_pdv, double ruc,double osnovica1,double stopa1,double porez1,double osnovica2,double stopa2,double porez2, double osnovica3,double stopa3,double porez3,double osnovica4,double stopa4,double porez4,double osnovica5,double stopa5,double porez5,double ne_pod,char s_ne_pod,string sif_rad)
        {
            SqlCommand Spremi=new SqlCommand();
            Spremi.Connection=conn;
            Spremi.CommandText="spremi_skk";
            Spremi.CommandType=CommandType.StoredProcedure;

            if (id_gksta != "")
            {
                Spremi.Parameters.Add("@id_gksta", SqlDbType.Int).Value = Convert.ToInt32(id_gksta);
            }
            else
            {
                Spremi.Parameters.Add("@id_gksta", SqlDbType.Int).Value = 99999;
            }
            Spremi.Parameters.Add("@vk", SqlDbType.NVarChar,2).Value=vk;
            Spremi.Parameters.Add("@bro_dok", SqlDbType.NVarChar,6).Value=bro_dok;
            Spremi.Parameters.Add("@bro_fak", SqlDbType.NVarChar,8).Value=bro_fak;
            Spremi.Parameters.Add("@opis", SqlDbType.NVarChar,20).Value=opis;
            Spremi.Parameters.Add("@pnb", SqlDbType.NVarChar,22).Value=pnb;
            Spremi.Parameters.Add("@konto", SqlDbType.NVarChar,4).Value=konto;
            Spremi.Parameters.Add("@sif_kom", SqlDbType.NVarChar,4).Value=sif_kom;
            Spremi.Parameters.Add("@org_jed", SqlDbType.NVarChar,2).Value=org_jed;
            Spremi.Parameters.Add("@vrs_rac", SqlDbType.NVarChar,2).Value=vrs_rac;
            Spremi.Parameters.Add("@dat_dok", SqlDbType.DateTime).Value = dat_dok;
            Spremi.Parameters.Add("@dvo", SqlDbType.DateTime).Value = dvo;
            Spremi.Parameters.Add("@dospij", SqlDbType.DateTime).Value = dospij;
            SqlParameter tecajP = new SqlParameter("@tecaj", SqlDbType.Decimal);
            tecajP.Precision = 11;
            tecajP.Scale = 6;
            Spremi.Parameters.Add(tecajP).Value = tecaj;
            SqlParameter iznos_vP = new SqlParameter("@iznos_v", SqlDbType.Decimal);
            iznos_vP.Precision = 11;
            iznos_vP.Scale = 6;
            Spremi.Parameters.Add(iznos_vP).Value = iznos_v;
            SqlParameter iznos_dP = new SqlParameter("@iznos_d", SqlDbType.Decimal);
            iznos_dP.Precision = 11;
            iznos_dP.Scale = 6;
            Spremi.Parameters.Add(iznos_dP).Value = iznos_d;
            SqlParameter tereti_vP = new SqlParameter("@tereti_v", SqlDbType.Decimal);
            tereti_vP.Precision = 11;
            tereti_vP.Scale = 6;
            Spremi.Parameters.Add(tereti_vP).Value = tereti_v;
            SqlParameter tereti_dP = new SqlParameter("@tereti_d", SqlDbType.Decimal);
            tereti_dP.Precision = 11;
            tereti_dP.Scale = 6;
            Spremi.Parameters.Add(tereti_dP).Value = tereti_d;
            SqlParameter uplata_vP = new SqlParameter("@uplata_v", SqlDbType.Decimal);
            uplata_vP.Precision = 11;
            uplata_vP.Scale = 6;
            Spremi.Parameters.Add(uplata_vP).Value = uplata_v;
            SqlParameter uplata_dP = new SqlParameter("@uplata_d", SqlDbType.Decimal);
            uplata_dP.Precision = 11;
            uplata_dP.Scale = 6;
            Spremi.Parameters.Add(uplata_dP).Value = uplata_d;
            SqlParameter saldo_vP = new SqlParameter("@saldo_v", SqlDbType.Decimal);
            saldo_vP.Precision = 11;
            saldo_vP.Scale = 6;
            Spremi.Parameters.Add(saldo_vP).Value = saldo_v;
            SqlParameter saldo_dP = new SqlParameter("@saldo_d", SqlDbType.Decimal);
            saldo_dP.Precision = 11;
            saldo_dP.Scale = 6;
            Spremi.Parameters.Add(saldo_dP).Value = saldo_d;
            Spremi.Parameters.Add("@rb_knj", SqlDbType.NVarChar, 4).Value = rb_knj;
            Spremi.Parameters.Add("@dat_por", SqlDbType.DateTime).Value = dat_por;
            Spremi.Parameters.Add("@dat_knj", SqlDbType.DateTime).Value = dat_knj;
            Spremi.Parameters.Add("@stat_por", SqlDbType.NVarChar, 1).Value = stat_por;
            Spremi.Parameters.Add("@ozn_pdv", SqlDbType.NVarChar, 1).Value = ozn_pdv;
            SqlParameter rucP = new SqlParameter("@ruc", SqlDbType.Decimal);
            rucP.Precision = 11;
            rucP.Scale = 6;
            Spremi.Parameters.Add(rucP).Value = ruc;
            SqlParameter osnovica1P = new SqlParameter("@osnovica1", SqlDbType.Decimal);
            osnovica1P.Precision = 11;
            osnovica1P.Scale = 6;
            Spremi.Parameters.Add(osnovica1P).Value = osnovica1;
            SqlParameter stopa1P = new SqlParameter("@stopa1", SqlDbType.Decimal);
            stopa1P.Precision = 11;
            stopa1P.Scale = 6;
            Spremi.Parameters.Add(stopa1P).Value = stopa1;
            SqlParameter porez1P = new SqlParameter("@porez1", SqlDbType.Decimal);
            porez1P.Precision = 11;
            porez1P.Scale = 6;
            Spremi.Parameters.Add(porez1P).Value = porez1;
            SqlParameter osnovica2P = new SqlParameter("@osnovica2", SqlDbType.Decimal);
            osnovica2P.Precision = 11;
            osnovica2P.Scale = 6;
            Spremi.Parameters.Add(osnovica2P).Value = osnovica2;
            SqlParameter stopa2P = new SqlParameter("@stopa2", SqlDbType.Decimal);
            stopa2P.Precision = 11;
            stopa2P.Scale = 6;
            Spremi.Parameters.Add(stopa2P).Value = stopa2;
            SqlParameter porez2P = new SqlParameter("@porez2", SqlDbType.Decimal);
            porez2P.Precision = 11;
            porez2P.Scale = 6;
            Spremi.Parameters.Add(porez2P).Value = porez2;
            SqlParameter osnovica3P = new SqlParameter("@osnovica3", SqlDbType.Decimal);
            osnovica3P.Precision = 11;
            osnovica3P.Scale = 6;
            Spremi.Parameters.Add(osnovica3P).Value = osnovica3;
            SqlParameter stopa3P = new SqlParameter("@stopa3", SqlDbType.Decimal);
            stopa3P.Precision = 11;
            stopa3P.Scale = 6;
            Spremi.Parameters.Add(stopa3P).Value = stopa3;
            SqlParameter porez3P = new SqlParameter("@porez3", SqlDbType.Decimal);
            porez3P.Precision = 11;
            porez3P.Scale = 6;
            Spremi.Parameters.Add(porez3P).Value = porez3;
            SqlParameter osnovica4P = new SqlParameter("@osnovica4", SqlDbType.Decimal);
            osnovica4P.Precision = 11;
            osnovica4P.Scale = 6;
            Spremi.Parameters.Add(osnovica4P).Value = osnovica4;
            SqlParameter stopa4P = new SqlParameter("@stopa4", SqlDbType.Decimal);
            stopa4P.Precision = 11;
            stopa4P.Scale = 6;
            Spremi.Parameters.Add(stopa4P).Value = stopa4;
            SqlParameter porez4P = new SqlParameter("@porez4", SqlDbType.Decimal);
            porez4P.Precision = 11;
            porez4P.Scale = 6;
            Spremi.Parameters.Add(porez4P).Value = porez4;
            SqlParameter osnovica5P = new SqlParameter("@osnovica5", SqlDbType.Decimal);
            osnovica5P.Precision = 11;
            osnovica5P.Scale = 6;
            Spremi.Parameters.Add(osnovica5P).Value = osnovica5;
            SqlParameter stopa5P = new SqlParameter("@stopa5", SqlDbType.Decimal);
            stopa5P.Precision = 11;
            stopa5P.Scale = 6;
            Spremi.Parameters.Add(stopa5P).Value = stopa5;
            SqlParameter porez5P = new SqlParameter("@porez5", SqlDbType.Decimal);
            porez5P.Precision = 11;
            porez5P.Scale = 6;
            Spremi.Parameters.Add(porez5P).Value = porez5;
            SqlParameter ne_podP = new SqlParameter("@ne_pod", SqlDbType.Decimal);
            ne_podP.Precision = 11;
            ne_podP.Scale = 6;
            Spremi.Parameters.Add(ne_podP).Value = ne_pod;
            Spremi.Parameters.Add("@s_ne_pod", SqlDbType.NVarChar, 1).Value = s_ne_pod;
            Spremi.Parameters.Add("@sif_rad", SqlDbType.NVarChar, 4).Value = sif_rad;
            Spremi.Parameters.Add("@greska", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;

            Spremi.ExecuteNonQuery();

            return Spremi.Parameters["@greska"].Value.ToString();

        }
        //unos u bazu ira ura, to ce trebati popraviti

        /*#region Komitent funkcije
        public string UnesiKomitenta(Komitent KomitentZaUnos)
        {
            SqlCommand SpremiKomitenta = new SqlCommand();
            SpremiKomitenta.Connection = conn;
            SpremiKomitenta.CommandText = "komitent_SP_n";
            SpremiKomitenta.CommandType = CommandType.StoredProcedure;

            SpremiKomitenta.Parameters.Add("@sif_kom", SqlDbType.NVarChar, 4).Value = KomitentZaUnos.Sifra;
            SpremiKomitenta.Parameters.Add("@iban", SqlDbType.Char, 21).Value = KomitentZaUnos.IBAN;
            SpremiKomitenta.Parameters.Add("@oib", SqlDbType.Char, 11).Value = KomitentZaUnos.OIB;
            SpremiKomitenta.Parameters.Add("@por_br_1", SqlDbType.Char, 2).Value = KomitentZaUnos.Porezni_broj1;
            SpremiKomitenta.Parameters.Add("@por_br_2", SqlDbType.Char, 15).Value = KomitentZaUnos.Porezni_broj2;
            SpremiKomitenta.Parameters.Add("@pnb", SqlDbType.Char, 30).Value = KomitentZaUnos.Poziv_na_broj;
            SpremiKomitenta.Parameters.Add("@naziv_s", SqlDbType.Char, 30).Value = KomitentZaUnos.Naziv_skraceni;
            SpremiKomitenta.Parameters.Add("@naziv_1", SqlDbType.Char, 40).Value = KomitentZaUnos.Naziv_dugi1;
            SpremiKomitenta.Parameters.Add("@naziv_2", SqlDbType.Char, 40).Value = KomitentZaUnos.Naziv_dugi2;
            SpremiKomitenta.Parameters.Add("@na_ruke", SqlDbType.Char, 4).Value = KomitentZaUnos.Na_ruke.Sifra;
            SpremiKomitenta.Parameters.Add("@pos_bro", SqlDbType.Char, 10).Value = KomitentZaUnos.AdresaKomitenta.Postanski_broj;
            SpremiKomitenta.Parameters.Add("@grad", SqlDbType.Char, 30).Value = KomitentZaUnos.AdresaKomitenta.Grad;
            SpremiKomitenta.Parameters.Add("@ulica", SqlDbType.Char, 30).Value = KomitentZaUnos.AdresaKomitenta.Ulica;
            SpremiKomitenta.Parameters.Add("@zemlja", SqlDbType.Char, 20).Value = KomitentZaUnos.AdresaKomitenta.Drzava;
            SpremiKomitenta.Parameters.Add("@telefon", SqlDbType.Char, 30).Value =KomitentZaUnos.Telefon;
            SpremiKomitenta.Parameters.Add("@tel_fin", SqlDbType.Char, 40).Value = KomitentZaUnos.Telefon_financija;
            SpremiKomitenta.Parameters.Add("@financ", SqlDbType.Char, 4).Value = KomitentZaUnos.Financije.Sifra;
            SpremiKomitenta.Parameters.Add("@fax", SqlDbType.Char, 30).Value = "";
            SpremiKomitenta.Parameters.Add("@BIC_SWIFT", SqlDbType.Char, 11).Value = KomitentZaUnos.Bic_Swift;
            SpremiKomitenta.Parameters.Add("@e_mail", SqlDbType.Char, 40).Value = KomitentZaUnos.Email;
            SpremiKomitenta.Parameters.Add("@www", SqlDbType.Char, 40).Value = KomitentZaUnos.WWW;
            SpremiKomitenta.Parameters.Add("@vrs_kom", SqlDbType.Char, 1).Value = KomitentZaUnos.Vrsta_komitenta;
            SpremiKomitenta.Parameters.Add("@sta_kom", SqlDbType.Char, 1).Value = ' ';
            SpremiKomitenta.Parameters.Add("@vrs_rac", SqlDbType.Char, 2).Value = KomitentZaUnos.Vrsta_racuna;
            SpremiKomitenta.Parameters.Add("@gru_kom", SqlDbType.Char, 1).Value = KomitentZaUnos.Grupa_komitenta;
            SpremiKomitenta.Parameters.Add("@sif_ref", SqlDbType.Char, 4).Value = KomitentZaUnos.Referent.Sifra;
            SpremiKomitenta.Parameters.Add("@dani_d", SqlDbType.Int).Value = KomitentZaUnos.Dani_d;
            SpremiKomitenta.Parameters.Add("@dani_k", SqlDbType.Int).Value = KomitentZaUnos.Dani_k;
            SpremiKomitenta.Parameters.Add("@napo_pla", SqlDbType.NVarChar, 80).Value = KomitentZaUnos.Napomena_Placanje;
            SqlParameter rabat_dP = new SqlParameter("@rabat_d", SqlDbType.Decimal);
            rabat_dP.Precision = 4;
            rabat_dP.Scale = 2;
            SpremiKomitenta.Parameters.Add(rabat_dP).Value = KomitentZaUnos.Rabat_d;
            SqlParameter rabat_kP = new SqlParameter("@rabat_k", SqlDbType.Decimal);
            rabat_kP.Precision = 4;
            rabat_kP.Scale = 2;
            SpremiKomitenta.Parameters.Add(rabat_kP).Value = KomitentZaUnos.Rabat_k;
            SqlParameter cas_sco_pP = new SqlParameter("@cas_sco_p", SqlDbType.Decimal);
            cas_sco_pP.Precision = 4;
            cas_sco_pP.Scale = 2;
            SpremiKomitenta.Parameters.Add(cas_sco_pP).Value = KomitentZaUnos.CasaSconto;
            SpremiKomitenta.Parameters.Add("@dat_prijave", SqlDbType.DateTime).Value = KomitentZaUnos.Datum_unosa;
            //SpremiKomitenta.Parameters.Add("@dat_pro", SqlDbType.DateTime).Value = DateTime.Now;
            SpremiKomitenta.Parameters.Add("@pkon_kup", SqlDbType.Char, 8).Value = "";
            SpremiKomitenta.Parameters.Add("@pkon_dob", SqlDbType.Char, 8).Value = "";
            SpremiKomitenta.Parameters.Add("@kon_dob", SqlDbType.Char, 4).Value = KomitentZaUnos.Konto_d;
            SpremiKomitenta.Parameters.Add("@kon_kup", SqlDbType.Char, 4).Value = KomitentZaUnos.Konto_k;
            SpremiKomitenta.Parameters.Add("@gl_kom", SqlDbType.Char, 4).Value = KomitentZaUnos.Glavni;
            SpremiKomitenta.Parameters.Add("@napomena", SqlDbType.Char, 60).Value = KomitentZaUnos.Napomena;
            SpremiKomitenta.Parameters.Add("@upozore", SqlDbType.NVarChar, 250).Value = KomitentZaUnos.Upozorenje;
            SpremiKomitenta.Parameters.Add("@opis", SqlDbType.NVarChar, 250).Value = KomitentZaUnos.Opis;
            SpremiKomitenta.Parameters.Add("@sif_rad", SqlDbType.Char, 4).Value = KomitentZaUnos.Radnik.Sifra;
            SpremiKomitenta.Parameters.Add("@vrati_sif_kom", SqlDbType.NVarChar, 6).Direction = ParameterDirection.Output;
            SpremiKomitenta.Parameters.Add("@Greska", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
           
            SpremiKomitenta.ExecuteNonQuery();

            return SpremiKomitenta.Parameters["@Greska"].Value.ToString();

        }//unos komitenta u bazu

        public DataTable ReadKomitent(string StartingWith, out List<Komitent> TrazeniKomitenti)
        {
            DataTable result = new DataTable();
            TrazeniKomitenti = new List<Komitent>();

            string GetResult = "SELECT * FROM dbo.komitent as K1 WHERE K1.naziv_s LIKE '%" + StartingWith + "%' OR K1.OIB LIKE '%" + StartingWith + "%'";
            SqlDataAdapter adapter = new SqlDataAdapter(GetResult, conn);

            adapter.Fill(result);

            foreach (DataRow Row in result.Rows)
            {
                Komitent DodajKomitenta = new Komitent();
                DodajKomitenta.AdresaKomitenta.Drzava = (Row["zemlja"] == DBNull.Value) ? string.Empty : Row["zemlja"].ToString().Trim();
                DodajKomitenta.AdresaKomitenta.Grad = (Row["grad"] == DBNull.Value) ? string.Empty : Row["grad"].ToString().Trim();
                DodajKomitenta.AdresaKomitenta.Postanski_broj = (Row["pos_bro"] == DBNull.Value) ?(int?) null : Convert.ToInt16(Row["pos_bro"]);
                DodajKomitenta.AdresaKomitenta.Ulica = (Row["ulica"] == DBNull.Value) ? string.Empty : Row["ulica"].ToString().Trim();
                DodajKomitenta.Bic_Swift = (Row["bic_swift"] == DBNull.Value) ? string.Empty : Row["bic_swift"].ToString().Trim();
                DodajKomitenta.CasaSconto = (Row["cas_sco_p"] == DBNull.Value) ? (double?) null : Convert.ToDouble(Row["cas_sco_p"]);
                DodajKomitenta.Dani_d = (Row["dani_d"] == DBNull.Value) ? (int?)null : Convert.ToInt16(Row["dani_d"]);
                DodajKomitenta.Dani_k = (Row["dani_k"] == DBNull.Value) ? (int?)null : Convert.ToInt16(Row["dani_k"]);
                DodajKomitenta.Datum_promijene = (Row["dat_pro"] == DBNull.Value) ? DateTime.Now : Convert.ToDateTime(Row["dat_pro"]);
                DodajKomitenta.Datum_unosa =(Row["dat_prijave"]==DBNull.Value) ? DateTime.Now : Convert.ToDateTime(Row["dat_prijave"]);
                DodajKomitenta.Email = (Row["e_mail"] == DBNull.Value) ? string.Empty : Row["e_mail"].ToString().Trim();
                DodajKomitenta.Financije.SifraRadnik = (Row["financ"] == DBNull.Value) ? string.Empty.ToCharArray() : Row["financ"].ToString().ToCharArray();
                DodajKomitenta.Glavni = (Row["gl_kom"] == DBNull.Value) ? string.Empty.ToCharArray() : Row["gl_kom"].ToString().ToCharArray();
                DodajKomitenta.Grupa_komitenta = (Row["gru_kom"] == DBNull.Value) ? (char?)null : Convert.ToChar(Row["gru_kom"]);
                DodajKomitenta.IBAN = (Row["iban"] == DBNull.Value) ? string.Empty : Row["iban"].ToString().Trim();
                DodajKomitenta.Konto_d = (Row["kon_dob"] == DBNull.Value) ? string.Empty : Row["kon_dob"].ToString().Trim();
                DodajKomitenta.Konto_k = (Row["kon_kup"] == DBNull.Value) ? string.Empty : Row["kon_kup"].ToString().Trim();
                DodajKomitenta.Na_ruke.SifraRadnik = (Row["na_ruke"] == DBNull.Value) ? string.Empty.ToCharArray() : Row["na_ruke"].ToString().ToCharArray();
                DodajKomitenta.Napomena = (Row["kon_kup"] == DBNull.Value) ? string.Empty : Row["napomena"].ToString().Trim();
                DodajKomitenta.Napomena_Placanje = (Row["napo_pla"] == DBNull.Value) ? string.Empty : Row["napo_pla"].ToString().Trim();
                DodajKomitenta.Naziv_dugi1 = (Row["naziv_1"] == DBNull.Value) ? string.Empty : Row["naziv_1"].ToString().Trim();
                DodajKomitenta.Naziv_dugi2 = (Row["naziv_2"] == DBNull.Value) ? string.Empty : Row["naziv_2"].ToString().Trim();
                DodajKomitenta.Naziv_skraceni = (Row["naziv_s"] == DBNull.Value) ? string.Empty : Row["naziv_s"].ToString().Trim();
                DodajKomitenta.OIB = (Row["oib"] == DBNull.Value) ? string.Empty : Row["oib"].ToString().Trim();
                DodajKomitenta.Opis = (Row["opis"] == DBNull.Value) ? string.Empty : Row["opis"].ToString().Trim();
                DodajKomitenta.Porezni_broj1 = (Row["por_br_1"] == DBNull.Value) ? string.Empty : Row["por_br_1"].ToString().Trim();
                DodajKomitenta.Porezni_broj2 = (Row["por_br_2"] == DBNull.Value) ? string.Empty : Row["por_br_2"].ToString().Trim();
                DodajKomitenta.Poziv_na_broj = (Row["pnb"] == DBNull.Value) ? string.Empty : Row["pnb"].ToString().Trim();
                DodajKomitenta.Rabat_d = (Row["rabat_d"] == DBNull.Value) ? (double?)null : Convert.ToDouble(Row["rabat_d"]);
                DodajKomitenta.Rabat_k = (Row["rabat_k"] == DBNull.Value) ? (double?)null : Convert.ToDouble(Row["rabat_k"]);
                DodajKomitenta.Radnik.SifraRadnik = (Row["sif_rad"] == DBNull.Value) ? string.Empty.ToCharArray() : Row["sif_rad"].ToString().ToCharArray();
                DodajKomitenta.Referent.SifraRadnik = (Row["sif_ref"] == DBNull.Value) ? string.Empty.ToCharArray() : Row["sif_ref"].ToString().ToCharArray();
                DodajKomitenta.Sifra = (Row["sif_kom"] == DBNull.Value) ? string.Empty.ToCharArray() : Row["sif_kom"].ToString().ToCharArray();
                DodajKomitenta.Telefon = (Row["telefon"] == DBNull.Value) ? string.Empty : Row["telefon"].ToString().Trim();
                DodajKomitenta.Telefon_financija = (Row["tel_fin"] == DBNull.Value) ? string.Empty : Row["tel_fin"].ToString().Trim();
                DodajKomitenta.Upozorenje = (Row["upozore"] == DBNull.Value) ? string.Empty : Row["upozore"].ToString().Trim();
                DodajKomitenta.Vrsta_komitenta = (Row["vrs_kom"] == DBNull.Value) ? (char?)null : Convert.ToChar(Row["vrs_kom"]);
                DodajKomitenta.Vrsta_racuna = (Row["vrs_rac"] == DBNull.Value) ? string.Empty : Row["vrs_rac"].ToString().Trim();
                DodajKomitenta.WWW = (Row["www"] == DBNull.Value) ? string.Empty : Row["www"].ToString().Trim();
                TrazeniKomitenti.Add(DodajKomitenta);
                

            }

            return result;
        }//čitanje komitenta iz naziva ili oiba

        public DataTable ReadKomitent(string StartingWith, string Posbroj, string Grad, string Drzava,string VrstaRac,string VrstaKom, string Oib, string Napomena, out List<Komitent> TrazeniKomitenti)
        {
            DataTable result = new DataTable();
            TrazeniKomitenti = new List<Komitent>();
            bool DodanUvjet = false;

            string GetResult = "SELECT * FROM dbo.komitent as K1 WHERE";

            if (StartingWith != "")
            {
                if (DodanUvjet)
                {
                    GetResult += " AND ";
                }
                GetResult += " K1.naziv_s LIKE '%" + StartingWith + "%'";
                DodanUvjet = true;
            }
            if (Posbroj != "")
            {
                if (DodanUvjet)
                {
                    GetResult += " AND ";
                }
                GetResult += " K1.pos_bro LIKE '%" + Posbroj + "%'";
                DodanUvjet = true;
            }
            if (Grad != "")
            {
                if (DodanUvjet)
                {
                    GetResult += " AND ";
                }
                GetResult += " K1.grad LIKE '%" + Grad + "%'";
                DodanUvjet = true;
            }
            if (Drzava != "")
            {
                if (DodanUvjet)
                {
                    GetResult += " AND ";
                }
                GetResult += " K1.zemlja LIKE '%" + Drzava + "%'";
                DodanUvjet = true;
            }
            if (VrstaRac != "")
            {
                if (DodanUvjet)
                {
                    GetResult += " AND ";
                }
                GetResult += " K1.vrs_rac LIKE '%" + VrstaRac + "%'";
                DodanUvjet = true;
            }
            if (VrstaKom != "")
            {
                if (DodanUvjet)
                {
                    GetResult += " AND ";
                }
                GetResult += " K1.vrs_kom LIKE '%" + VrstaKom + "%'";
                DodanUvjet = true;
            }
            if (Oib != "")
            {
                if (DodanUvjet)
                {
                    GetResult += " AND ";
                }
                GetResult += " K1.OIB LIKE '%" + Oib + "%'";
                DodanUvjet = true;
            }
            if (Napomena != "")
            {
                if (DodanUvjet)
                {
                    GetResult += " AND ";
                }
                GetResult += " K1.napomena LIKE '%" + Napomena + "%'";
                DodanUvjet = true;
            }

            if (!DodanUvjet)
            {
               GetResult = GetResult.Substring(0, GetResult.IndexOf("WHERE"));
            }

            SqlDataAdapter adapter = new SqlDataAdapter(GetResult, conn);

            adapter.Fill(result);

            foreach (DataRow Row in result.Rows)
            {
                Komitent DodajKomitenta = new Komitent();
                DodajKomitenta.AdresaKomitenta.Drzava = (Row["zemlja"] == DBNull.Value) ? string.Empty : Row["zemlja"].ToString().Trim();
                DodajKomitenta.AdresaKomitenta.Grad = (Row["grad"] == DBNull.Value) ? string.Empty : Row["grad"].ToString().Trim();
                DodajKomitenta.AdresaKomitenta.Postanski_broj = (Row["pos_bro"] == DBNull.Value) ? (int?)null : Convert.ToInt16(Row["pos_bro"]);
                DodajKomitenta.AdresaKomitenta.Ulica = (Row["ulica"] == DBNull.Value) ? string.Empty : Row["ulica"].ToString().Trim();
                DodajKomitenta.Bic_Swift = (Row["bic_swift"] == DBNull.Value) ? string.Empty : Row["bic_swift"].ToString().Trim();
                DodajKomitenta.CasaSconto = (Row["cas_sco_p"] == DBNull.Value) ? (double?)null : Convert.ToDouble(Row["cas_sco_p"]);
                DodajKomitenta.Dani_d = (Row["dani_d"] == DBNull.Value) ? (int?)null : Convert.ToInt16(Row["dani_d"]);
                DodajKomitenta.Dani_k = (Row["dani_k"] == DBNull.Value) ? (int?)null : Convert.ToInt16(Row["dani_k"]);
                DodajKomitenta.Datum_promijene = (Row["dat_pro"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(Row["dat_pro"]);
                DodajKomitenta.Datum_unosa = (Row["dat_prijave"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(Row["dat_prijave"]);
                DodajKomitenta.Email = (Row["e_mail"] == DBNull.Value) ? string.Empty : Row["e_mail"].ToString().Trim();
                DodajKomitenta.Financije.SifraRadnik = (Row["financ"] == DBNull.Value) ? string.Empty.ToCharArray() : Row["financ"].ToString().ToCharArray();
                DodajKomitenta.Glavni = (Row["gl_kom"] == DBNull.Value) ? string.Empty.ToCharArray() : Row["gl_kom"].ToString().ToCharArray();
                DodajKomitenta.Grupa_komitenta = (Row["gru_kom"] == DBNull.Value) ? (char?)null : Convert.ToChar(Row["gru_kom"]);
                DodajKomitenta.IBAN = (Row["iban"] == DBNull.Value) ? string.Empty : Row["iban"].ToString().Trim();
                DodajKomitenta.Konto_d = (Row["kon_dob"] == DBNull.Value) ? string.Empty : Row["kon_dob"].ToString().Trim();
                DodajKomitenta.Konto_k = (Row["kon_kup"] == DBNull.Value) ? string.Empty : Row["kon_kup"].ToString().Trim();
                DodajKomitenta.Na_ruke.SifraRadnik = (Row["na_ruke"] == DBNull.Value) ? string.Empty.ToCharArray() : Row["na_ruke"].ToString().ToCharArray();
                DodajKomitenta.Napomena = (Row["kon_kup"] == DBNull.Value) ? string.Empty : Row["napomena"].ToString().Trim();
                DodajKomitenta.Napomena_Placanje = (Row["napo_pla"] == DBNull.Value) ? string.Empty : Row["napo_pla"].ToString().Trim();
                DodajKomitenta.Naziv_dugi1 = (Row["naziv_1"] == DBNull.Value) ? string.Empty : Row["naziv_1"].ToString().Trim();
                DodajKomitenta.Naziv_dugi2 = (Row["naziv_2"] == DBNull.Value) ? string.Empty : Row["naziv_2"].ToString().Trim();
                DodajKomitenta.Naziv_skraceni = (Row["naziv_s"] == DBNull.Value) ? string.Empty : Row["naziv_s"].ToString().Trim();
                DodajKomitenta.OIB = (Row["oib"] == DBNull.Value) ? string.Empty : Row["oib"].ToString().Trim();
                DodajKomitenta.Opis = (Row["opis"] == DBNull.Value) ? string.Empty : Row["opis"].ToString().Trim();
                DodajKomitenta.Porezni_broj1 = (Row["por_br_1"] == DBNull.Value) ? string.Empty : Row["por_br_1"].ToString().Trim();
                DodajKomitenta.Porezni_broj2 = (Row["por_br_2"] == DBNull.Value) ? string.Empty : Row["por_br_2"].ToString().Trim();
                DodajKomitenta.Poziv_na_broj = (Row["pnb"] == DBNull.Value) ? string.Empty : Row["pnb"].ToString().Trim();
                DodajKomitenta.Rabat_d = (Row["rabat_d"] == DBNull.Value) ? (double?)null : Convert.ToDouble(Row["rabat_d"]);
                DodajKomitenta.Rabat_k = (Row["rabat_k"] == DBNull.Value) ? (double?)null : Convert.ToDouble(Row["rabat_k"]);
                DodajKomitenta.Radnik.SifraRadnik = (Row["sif_rad"] == DBNull.Value) ? string.Empty.ToCharArray() : Row["sif_rad"].ToString().ToCharArray();
                DodajKomitenta.Referent.SifraRadnik = (Row["sif_ref"] == DBNull.Value) ? string.Empty.ToCharArray() : Row["sif_ref"].ToString().ToCharArray();
                DodajKomitenta.Sifra = (Row["sif_kom"] == DBNull.Value) ? string.Empty.ToCharArray() : Row["sif_kom"].ToString().ToCharArray();
                DodajKomitenta.Telefon = (Row["telefon"] == DBNull.Value) ? string.Empty : Row["telefon"].ToString().Trim();
                DodajKomitenta.Telefon_financija = (Row["tel_fin"] == DBNull.Value) ? string.Empty : Row["tel_fin"].ToString().Trim();
                DodajKomitenta.Upozorenje = (Row["upozore"] == DBNull.Value) ? string.Empty : Row["upozore"].ToString().Trim();
                DodajKomitenta.Vrsta_komitenta = (Row["vrs_kom"] == DBNull.Value) ? (char?)null : Convert.ToChar(Row["vrs_kom"]);
                DodajKomitenta.Vrsta_racuna = (Row["vrs_rac"] == DBNull.Value) ? string.Empty : Row["vrs_rac"].ToString().Trim();
                DodajKomitenta.WWW = (Row["www"] == DBNull.Value) ? string.Empty : Row["www"].ToString().Trim();
                TrazeniKomitenti.Add(DodajKomitenta);
            }

            return result;
        }//čitanje komitenta iz ostalih polja

        public void ReadKomitent2(string StartingWith, string Posbroj, string Grad, string Drzava, string VrstaRac, string VrstaKom, string Oib, string Napomena, out List<Komitent> TrazeniKomitenti)
        {
            DataTable result = new DataTable();
            TrazeniKomitenti = new List<Komitent>();
            bool DodanUvjet = false;

            string GetResult = "SELECT * FROM dbo.komitent as K1 WHERE";

            if (StartingWith != "")
            {
                if (DodanUvjet)
                {
                    GetResult += " AND ";
                }
                GetResult += " K1.naziv_s LIKE '%" + StartingWith + "%'";
                DodanUvjet = true;
            }
            if (Posbroj != "")
            {
                if (DodanUvjet)
                {
                    GetResult += " AND ";
                }
                GetResult += " K1.pos_bro LIKE '%" + Posbroj + "%'";
                DodanUvjet = true;
            }
            if (Grad != "")
            {
                if (DodanUvjet)
                {
                    GetResult += " AND ";
                }
                GetResult += " K1.grad LIKE '%" + Grad + "%'";
                DodanUvjet = true;
            }
            if (Drzava != "")
            {
                if (DodanUvjet)
                {
                    GetResult += " AND ";
                }
                GetResult += " K1.zemlja LIKE '%" + Drzava + "%'";
                DodanUvjet = true;
            }
            if (VrstaRac != "")
            {
                if (DodanUvjet)
                {
                    GetResult += " AND ";
                }
                GetResult += " K1.vrs_rac LIKE '%" + VrstaRac + "%'";
                DodanUvjet = true;
            }
            if (VrstaKom != "")
            {
                if (DodanUvjet)
                {
                    GetResult += " AND ";
                }
                GetResult += " K1.vrs_kom LIKE '%" + VrstaKom + "%'";
                DodanUvjet = true;
            }
            if (Oib != "")
            {
                if (DodanUvjet)
                {
                    GetResult += " AND ";
                }
                GetResult += " K1.OIB LIKE '%" + Oib + "%'";
                DodanUvjet = true;
            }
            if (Napomena != "")
            {
                if (DodanUvjet)
                {
                    GetResult += " AND ";
                }
                GetResult += " K1.napomena LIKE '%" + Napomena + "%'";
                DodanUvjet = true;
            }

            if (!DodanUvjet)
            {
                GetResult = GetResult.Substring(0, GetResult.IndexOf("WHERE"));
            }

            GetResult += " ORDER BY K1.naziv_s ASC";

            SqlDataAdapter adapter = new SqlDataAdapter(GetResult, conn);

            adapter.Fill(result);

            foreach (DataRow Row in result.Rows)
            {
                Komitent DodajKomitenta = new Komitent();
                DodajKomitenta.AdresaKomitenta.Drzava = (Row["zemlja"] == DBNull.Value) ? string.Empty : Row["zemlja"].ToString().Trim();
                DodajKomitenta.AdresaKomitenta.Grad = (Row["grad"] == DBNull.Value) ? string.Empty : Row["grad"].ToString().Trim();
                DodajKomitenta.AdresaKomitenta.Postanski_broj = (Row["pos_bro"] == DBNull.Value) ? (int?)null : Convert.ToInt16(Row["pos_bro"]);
                DodajKomitenta.AdresaKomitenta.Ulica = (Row["ulica"] == DBNull.Value) ? string.Empty : Row["ulica"].ToString().Trim();
                DodajKomitenta.Bic_Swift = (Row["bic_swift"] == DBNull.Value) ? string.Empty : Row["bic_swift"].ToString().Trim();
                DodajKomitenta.CasaSconto = (Row["cas_sco_p"] == DBNull.Value) ? (double?)null : Convert.ToDouble(Row["cas_sco_p"]);
                DodajKomitenta.Dani_d = (Row["dani_d"] == DBNull.Value) ? (int?)null : Convert.ToInt16(Row["dani_d"]);
                DodajKomitenta.Dani_k = (Row["dani_k"] == DBNull.Value) ? (int?)null : Convert.ToInt16(Row["dani_k"]);
                DodajKomitenta.Datum_promijene = (Row["dat_pro"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(Row["dat_pro"]);
                DodajKomitenta.Datum_unosa = (Row["dat_prijave"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(Row["dat_prijave"]);
                DodajKomitenta.Email = (Row["e_mail"] == DBNull.Value) ? string.Empty : Row["e_mail"].ToString().Trim();
                DodajKomitenta.Financije.SifraRadnik = (Row["financ"] == DBNull.Value) ? string.Empty.ToCharArray() : Row["financ"].ToString().ToCharArray();
                DodajKomitenta.Glavni = (Row["gl_kom"] == DBNull.Value) ? string.Empty.ToCharArray() : Row["gl_kom"].ToString().ToCharArray();
                DodajKomitenta.Grupa_komitenta = (Row["gru_kom"] == DBNull.Value) ? (char?)null : Convert.ToChar(Row["gru_kom"]);
                DodajKomitenta.IBAN = (Row["iban"] == DBNull.Value) ? string.Empty : Row["iban"].ToString().Trim();
                DodajKomitenta.Konto_d = (Row["kon_dob"] == DBNull.Value) ? string.Empty : Row["kon_dob"].ToString().Trim();
                DodajKomitenta.Konto_k = (Row["kon_kup"] == DBNull.Value) ? string.Empty : Row["kon_kup"].ToString().Trim();
                DodajKomitenta.Na_ruke.SifraRadnik = (Row["na_ruke"] == DBNull.Value) ? string.Empty.ToCharArray() : Row["na_ruke"].ToString().ToCharArray();
                DodajKomitenta.Napomena = (Row["kon_kup"] == DBNull.Value) ? string.Empty : Row["napomena"].ToString().Trim();
                DodajKomitenta.Napomena_Placanje = (Row["napo_pla"] == DBNull.Value) ? string.Empty : Row["napo_pla"].ToString().Trim();
                DodajKomitenta.Naziv_dugi1 = (Row["naziv_1"] == DBNull.Value) ? string.Empty : Row["naziv_1"].ToString().Trim();
                DodajKomitenta.Naziv_dugi2 = (Row["naziv_2"] == DBNull.Value) ? string.Empty : Row["naziv_2"].ToString().Trim();
                DodajKomitenta.Naziv_skraceni = (Row["naziv_s"] == DBNull.Value) ? string.Empty : Row["naziv_s"].ToString().Trim();
                DodajKomitenta.OIB = (Row["oib"] == DBNull.Value) ? string.Empty : Row["oib"].ToString().Trim();
                DodajKomitenta.Opis = (Row["opis"] == DBNull.Value) ? string.Empty : Row["opis"].ToString().Trim();
                DodajKomitenta.Porezni_broj1 = (Row["por_br_1"] == DBNull.Value) ? string.Empty : Row["por_br_1"].ToString().Trim();
                DodajKomitenta.Porezni_broj2 = (Row["por_br_2"] == DBNull.Value) ? string.Empty : Row["por_br_2"].ToString().Trim();
                DodajKomitenta.Poziv_na_broj = (Row["pnb"] == DBNull.Value) ? string.Empty : Row["pnb"].ToString().Trim();
                DodajKomitenta.Rabat_d = (Row["rabat_d"] == DBNull.Value) ? (double?)null : Convert.ToDouble(Row["rabat_d"]);
                DodajKomitenta.Rabat_k = (Row["rabat_k"] == DBNull.Value) ? (double?)null : Convert.ToDouble(Row["rabat_k"]);
                DodajKomitenta.Radnik.SifraRadnik = (Row["sif_rad"] == DBNull.Value) ? string.Empty.ToCharArray() : Row["sif_rad"].ToString().ToCharArray();
                DodajKomitenta.Referent.SifraRadnik = (Row["sif_ref"] == DBNull.Value) ? string.Empty.ToCharArray() : Row["sif_ref"].ToString().ToCharArray();
                DodajKomitenta.Sifra = (Row["sif_kom"] == DBNull.Value) ? string.Empty.ToCharArray() : Row["sif_kom"].ToString().ToCharArray();
                DodajKomitenta.Telefon = (Row["telefon"] == DBNull.Value) ? string.Empty : Row["telefon"].ToString().Trim();
                DodajKomitenta.Telefon_financija = (Row["tel_fin"] == DBNull.Value) ? string.Empty : Row["tel_fin"].ToString().Trim();
                DodajKomitenta.Upozorenje = (Row["upozore"] == DBNull.Value) ? string.Empty : Row["upozore"].ToString().Trim();
                DodajKomitenta.Vrsta_komitenta = (Row["vrs_kom"] == DBNull.Value) ? (char?)null : Convert.ToChar(Row["vrs_kom"]);
                DodajKomitenta.Vrsta_racuna = (Row["vrs_rac"] == DBNull.Value) ? string.Empty : Row["vrs_rac"].ToString().Trim();
                DodajKomitenta.WWW = (Row["www"] == DBNull.Value) ? string.Empty : Row["www"].ToString().Trim();
                TrazeniKomitenti.Add(DodajKomitenta);
            }

            return;
        }//čitanje komitenta iz ostalih polja

        public List<string> DohvatiKomitente(string Unos)
        {
            List<string> Result = new List<string>();
            List<string> Sifre = new List<string>();
            List<string> Nazivi = new List<string>();

            SqlCommand Dohvati = new SqlCommand();
            Dohvati.Connection = conn;
            Dohvati.CommandText = "SELECT sif_kom, naziv_s FROM dbo.komitent ";
            Dohvati.CommandText += "WHERE naziv_s LIKE '" + Unos + "%' OR sif_kom LIKE '" + Unos + "%' ";
            Dohvati.CommandText += "ORDER BY naziv_s,sif_kom ASC";

            SqlDataReader KomitentReader;

            KomitentReader = Dohvati.ExecuteReader();

            while (KomitentReader.Read())
            {

                Sifre.Add(KomitentReader["sif_kom"].ToString());
                Nazivi.Add(KomitentReader["naziv_s"].ToString());

            }

            KomitentReader.Close();

            int MaxLength = 0;
            foreach (string sifra in Sifre)
            {
                if (sifra.Length > MaxLength)
                {
                    MaxLength = sifra.Length;
                }
            }

            for (int i = 0; i < Sifre.Count; i++)
            {
                string ToAdd;
                ToAdd = Sifre[i];
                for (int j = Sifre[i].Length; j <= MaxLength + 1; j++)
                {
                    ToAdd += " ";
                }
                ToAdd += "|  ";
                ToAdd += Nazivi[i].Trim();
                Result.Add(ToAdd);
            }

            return Result;
        }//dohvacanje komitenta u formatu naziv_s|oib (vjerojatno redundantno)
        #endregion*/
        
    }   
}
