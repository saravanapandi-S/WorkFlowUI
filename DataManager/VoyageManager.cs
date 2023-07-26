using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using DataBaseFactory;
using System.Data;
using System.Data.Common;
using DataTier;
using System.Data.SqlClient;
using System.Collections;
using System.Globalization;
namespace DataManager
{
    public class VoyageManager
    {
        List<myVoyage> ListVoyage = new List<myVoyage>();

        #region Membervariable
        private IDataBaseFactory _dbFactory = null;

        #endregion
        #region Constructor Method
        public VoyageManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion

        #region
        public List<myVoyage> GetVesseldorpdown(myVoyage Data)
        {
            DataTable dt = GetVesselValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListVoyage.Add(new myVoyage
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesselName = dt.Rows[i]["VesselName"].ToString(),

                });
            }
            return ListVoyage;

        }
        public DataTable GetVesselValues(myVoyage Data)
        {
            string _Query = "select ID,VesselName from NVO_VesselMaster where status=1";

            return GetViewData(_Query, "");

        }
        public List<myVoyage> GetTerminaldropdown(myVoyage Data)
        {
            DataTable dt = GetTerminalRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListVoyage.Add(new myVoyage

                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    TerminalName = dt.Rows[i]["TerminalName"].ToString()
                });
            }
            return ListVoyage;
        }
        public DataTable GetTerminalRecord(myVoyage Data)
        {
            string _Query = "select ID,(TerminalCode +'-'+ TerminalName) AS TerminalName from NVO_TerminalMaster where Status=1 order by ID ";
            return GetViewData(_Query, "");
        }
        public List<myVoyage> GetVoyageNoteTypedropdown(myVoyage Data)
        {
            DataTable dt = GetVoyageNoteTypeRecord(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListVoyage.Add(new myVoyage

                {
                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VoyageNoteTypes = dt.Rows[i]["GeneralName"].ToString()
                });
            }
            return ListVoyage;
        }
        public DataTable GetVoyageNoteTypeRecord(myVoyage Data)
        {
            string _Query = "select ID,GeneralName from NVO_GeneralMaster where status=1 and SeqNo=77";
            return GetViewData(_Query, "");
        }
        #endregion
        #region Insert voyages

        public List<myVoyage> InsertVoyageContracts(myVoyage Data)
        {


            DbConnection con = null;
            DbTransaction trans;
            DataTable dtchk = GetVoyageExValues(Data);
            if (Data.ID == 0)
            {
                if (dtchk.Rows.Count >= 1)
                {

                    ListVoyage.Add(new myVoyage
                    {
                        ID = Data.ID,

                        AlertMegId = "1",
                        AlertMessage = "Vessel-VoyageNo Already Exists"
                    });
                    return ListVoyage;

                }
            }

            try
            {
                con = _dbFactory.GetConnection();
                con.Open();
                trans = _dbFactory.GetTransaction(con);
                DbCommand Cmd = _dbFactory.GetCommand();
                Cmd.Connection = con;
                Cmd.Transaction = trans;

                try
                {

                    Cmd.CommandText = " IF((select count(*) from NVO_Voyage where ID=@ID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_Voyage(VesselID,ETA,UserID,ETD,ATA,ATD,VoyageNo,PortID,CutOffDate,EGMDate,EGMNo,IGMDate,IGMNo) " +
                                     " values (@VesselID,@ETA,@UserID,@ETD,@ATA,@ATD,@VoyageNo,@PortID,@CutOffDate,@EGMDate,@EGMNo,@IGMDate,@IGMNo) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_Voyage SET VesselID=@VesselID,UserID=@UserID,ETD=@ETD,ATA=@ATA,ATD=@ATD,VoyageNo=@VoyageNo,PortID=@PortID,CutOffDate=@CutOffDate,EGMDate=@EGMDate,EGMNo=@EGMNo,IGMDate=@IGMDate,IGMNo=@IGMNo where ID=@ID";

                    Cmd.Parameters.Add(_dbFactory.GetParameter("@ID", Data.ID));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VesselID", Data.VesselID));
                    if (Data.ETD != null)
                    {
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ETD", Data.ETD));
                    }
                    else
                    {
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ETD", DBNull.Value));
                    }
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@ETD", Data.ETD));
                    if (Data.ETA != "")
                    {
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ETA", Data.ETA));
                    }
                    else
                    {
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ETA", DBNull.Value));
                    }
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@ETA", Data.ETA));
                    if (Data.ATA != "")
                    {
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ATA", Data.ATA));
                    }
                    else
                    {
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ATA", DBNull.Value));
                    }
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@ATA", Data.ATA));
                    if (Data.ATD != "")
                    {
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ATD", Data.ATD));
                    }
                    else
                    {
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@ATD", DBNull.Value));
                    }
                   /* Cmd.Parameters.Add(_dbFactory.GetParameter("@ATD", Data.ATD))*/;
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@VoyageNo", Data.VoyageNo.ToUpper()));
                    if (Data.CutOffDate != "")
                    {
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CutOffDate", Data.CutOffDate));
                    }
                    else
                    {
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@CutOffDate", DBNull.Value));
                    }
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@CutOffDate", Data.CutOffDate));
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@RotationNo", Data.RotationNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@PortID", Data.PortID));
                    if (Data.EGMDate != "")
                    {
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@EGMDate", Data.EGMDate));
                    }
                    else
                    {
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@EGMDate", DBNull.Value));
                    }
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@EGMDate", Data.EGMDate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@EGMNo", Data.EGMNo));
                    if (Data.IGMDate != "")
                    {
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@IGMDate", Data.IGMDate));
                    }
                    else
                    {
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@IGMDate", DBNull.Value));
                    }
                    //Cmd.Parameters.Add(_dbFactory.GetParameter("@IGMDate", Data.IGMDate));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@IGMNo", Data.IGMNo));
                    Cmd.Parameters.Add(_dbFactory.GetParameter("@UserID", 1));

                    int result = Cmd.ExecuteNonQuery();
                    Cmd.Parameters.Clear();

                    if (Data.ID == 0)
                    {
                        Cmd.CommandText = "select ident_current('NVO_Voyage')";
                        Data.ID = Int32.Parse(Cmd.ExecuteScalar().ToString());

                    }
                    string[] Array1 = Data.Itemsv1.Split(new[] { "Insert:" }, StringSplitOptions.None);
                    for (int i = 1; i < Array1.Length; i++)
                    {

                        var CharSplit = Array1[i].ToString().TrimEnd(',').Split(',');

                        Cmd.CommandText = " IF((select count(*) from NVO_VoyTerminalDtls where TID=@TID AND VoyID=@VoyID)<=0) " +
                                     " BEGIN " +
                                     " INSERT INTO  NVO_VoyTerminalDtls(TerminalID,VoyID,RotationNo,TerminalName) " +
                                     " values (@TerminalID,@VoyID,@RotationNo,@TerminalName) " +
                                     " END  " +
                                     " ELSE " +
                                     " UPDATE NVO_VoyTerminalDtls SET TerminalID=@TerminalID,VoyID=@VoyID,RotationNo=@RotationNo,TerminalName=@TerminalName where TID=@TID and VoyID=@VoyID ";


                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TID", CharSplit[0]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TerminalID", CharSplit[1]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@VoyID", Data.ID));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@RotationNo", CharSplit[2]));
                        Cmd.Parameters.Add(_dbFactory.GetParameter("@TerminalName", CharSplit[3]));

                        result = Cmd.ExecuteNonQuery();
                        Cmd.Parameters.Clear();

                    }

                    if (Data.Itemsv2 != "")
                    {
                        string[] Array2 = Data.Itemsv2.Split(new[] { "Insert:" }, StringSplitOptions.None);
                        for (int i = 1; i < Array2.Length; i++)
                        {

                            var CharSplit = Array2[i].ToString().TrimEnd(',').Split(',');

                            Cmd.CommandText = " IF((select count(*) from NVO_VoyNotesDtls where NID=@NID AND VoyID=@VoyID)<=0) " +
                                         " BEGIN " +
                                         " INSERT INTO  NVO_VoyNotesDtls(VoyID,NotesType,Notes,DtCreated) " +
                                         " values (@VoyID,@NotesType,@Notes,@DtCreated) " +
                                         " END  " +
                                         " ELSE " +
                                         " UPDATE NVO_VoyNotesDtls SET VoyID=@VoyID,NotesType=@NotesType,Notes=@Notes,DtCreated=@DtCreated where NID=@NID and VoyID=@VoyID";


                            Cmd.Parameters.Add(_dbFactory.GetParameter("@NID", CharSplit[0]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@VoyID", Data.ID));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@NotesType", CharSplit[1]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@Notes", CharSplit[2]));
                            Cmd.Parameters.Add(_dbFactory.GetParameter("@DtCreated", System.DateTime.Now));

                            result = Cmd.ExecuteNonQuery();
                            Cmd.Parameters.Clear();

                        }
                    }
                    trans.Commit();
                    ListVoyage.Add(new myVoyage
                    {
                        ID = Data.ID,
                        AlertMegId = "2",
                        AlertMessage = "Saved Successfully"
                    }
                        );
                    return ListVoyage;
                }
                catch (Exception ex)
                {
                    string ss = ex.ToString();
                    trans.Rollback();
                    ListVoyage.Add(new myVoyage
                    {
                        ID = Data.ID,
                        AlertMegId = "3",
                        AlertMessage = ex.Message
                    });
                    return ListVoyage;
                }

            }


            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                if (con != null && con.State != ConnectionState.Closed)
                    con.Close();

            }
        }
        public DataTable GetVoyageExValues(myVoyage Data)
        {


            string _Query = "select * from NVO_Voyage where vesselID = " + Data.VesselID + " and VoyageNo='" + Data.VoyageNo + "'";
            return GetViewData(_Query, "");
        }
        public List<myVoyage> GetVoyageViewlist(myVoyage Data)
        {
            DataTable dt = GetVoyageViewlistvalues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListVoyage.Add(new myVoyage
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesselName = dt.Rows[i]["VesselName"].ToString(),
                    VoyageNo = dt.Rows[i]["VoyageNo"].ToString(),
                    ETA = dt.Rows[i]["ETA"].ToString(),
                    PortName = dt.Rows[i]["PortName"].ToString(),
                    //TerminalName = dt.Rows[i]["TerminalName"].ToString(),
                    VesselID = Int32.Parse(dt.Rows[i]["VesselID"].ToString()),
                });
            }
            return ListVoyage;
        }
        public DataTable GetVoyageViewlistvalues(myVoyage Data)
        {
            string strWhere = "";



            string _Query = "select NVO_Voyage.ID,(select VesselName from NVO_VesselMaster where NVO_VesselMaster.ID=NVO_Voyage.VesselID) as vesselname," +
                " convert(varchar, ETA, 103) as ETA,VoyageNo," +
                " (select PortName from NVO_PortMaster where NVO_PortMaster.ID=NVO_Voyage.PortID) as PortName, * " +
                //" (select terminalname from NVO_TerminalMaster where NVO_TerminalMaster.ID=NVO_VoyTerminalDtls.TerminalID ) as TerminalName, * " +
                " from NVO_Voyage ";
            //" inner join NVO_VoyTerminalDtls on NVO_VoyTerminalDtls.VoyID = NVO_Voyage.ID";

            if (Data.VoyageNo != "")
                if (strWhere == "")
                    strWhere += _Query + " where VoyageNo like '%" + Data.VoyageNo + "%'";
                else
                    strWhere += " and VoyageNo like '%" + Data.VoyageNo + "%'";

            if (Data.VesselID.ToString() != "" && Data.VesselID.ToString() != "0" && Data.VesselID.ToString() != null && Data.VesselID.ToString() != "?")
                if (strWhere == "")
                    strWhere += _Query + " where VesselID= " + Data.VesselID.ToString();
                else
                    strWhere += " and VesselID= " + Data.VesselID.ToString();


            if (strWhere == "")
                strWhere = _Query;

            return GetViewData(strWhere, "");

        }

        public List<myVoyage> GetVoyageEdit(myVoyage Data)
        {
            DataTable dt = GetVoyageRecord(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListVoyage.Add(new myVoyage
                {

                    ID = Int32.Parse(dt.Rows[i]["ID"].ToString()),
                    VesselID = Int32.Parse(dt.Rows[i]["VesselID"].ToString()),
                    VoyageNo = dt.Rows[i]["VoyageNo"].ToString(),
                    ETA = dt.Rows[i]["ETADate"].ToString(),
                    ETD = dt.Rows[i]["ETDDate"].ToString(),
                    ATA = dt.Rows[i]["ATADate"].ToString(),
                    ATD = dt.Rows[i]["ATDDate"].ToString(),
                    PortID = Int32.Parse(dt.Rows[i]["PortID"].ToString()),
                    CutOffDate = dt.Rows[i]["CutOffDateDt"].ToString(),
                    //RotationNo= dt.Rows[i]["RotationNo"].ToString(),
                    EGMDate = dt.Rows[i]["EGMDateDt"].ToString(),
                    EGMNo = dt.Rows[i]["EGMNo"].ToString(),
                    IGMDate = dt.Rows[i]["IGMDateDt"].ToString(),
                    IGMNo = dt.Rows[i]["IGMNo"].ToString(),
                });
            }
            return ListVoyage;

        }
        public DataTable GetVoyageRecord(myVoyage Data)
        {
            string _Query = " select convert(varchar, ETA, 23) as ETADate,convert(varchar, ETD, 23) as ETDDate,convert(varchar, ETD, 23) as ATADate," +
                " convert(varchar, ATA, 23) as ATDDate,convert(varchar, CutOffDate, 23) as CutOffDateDt," +
                " convert(varchar, EGMDate, 23) as EGMDateDt, convert(varchar, IGMDate, 23) as IGMDateDt,* from NVO_Voyage where ID=" + Data.ID;

            return GetViewData(_Query, "");

        }

        public List<myVoyage> GetVoyageEditTerminal(myVoyage Data)
        {
            DataTable dt = GetVoyageTerminalRecord(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListVoyage.Add(new myVoyage
                {

                    TID = Int32.Parse(dt.Rows[i]["TID"].ToString()),
                    TerminalID = Int32.Parse(dt.Rows[i]["TerminalID"].ToString()),
                    RotationNo = dt.Rows[i]["RotationNo"].ToString(),
                    TerminalName = dt.Rows[i]["TerminalName"].ToString(),

                });
            }
            return ListVoyage;

        }
        public DataTable GetVoyageTerminalRecord(myVoyage Data)
        {
            string _Query = " select * from NVO_VoyTerminalDtls where VoyID=" + Data.ID;
            return GetViewData(_Query, "");

        }
        public List<myVoyage> GetVoyNoteEdit(myVoyage Data)
        {
            DataTable dt = GetVoyNoteEditRecord(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListVoyage.Add(new myVoyage
                {

                    NID = Int32.Parse(dt.Rows[i]["NID"].ToString()),
                    NotesType = Int32.Parse(dt.Rows[i]["NotesType"].ToString()),
                    Notes = dt.Rows[i]["Notes"].ToString(),
                });
            }
            return ListVoyage;

        }
        public DataTable GetVoyNoteEditRecord(myVoyage Data)
        {
            string _Query = " select * from NVO_VoyNotesDtls where VoyID=" + Data.ID;
            return GetViewData(_Query, "");

        }
        public List<myVoyage> GetTeminalDeletet(myVoyage Data)
        {
            DataTable dt = GetTeminalDeletetValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVoyage.Add(new myVoyage
                {

                    TID = Int32.Parse(dt.Rows[i]["TID"].ToString()),
                    TerminalID = Int32.Parse(dt.Rows[i]["TerminalID"].ToString()),
                    RotationNo = dt.Rows[i]["Notes"].ToString(),
                    TerminalName = dt.Rows[i]["Notes"].ToString(),
                });
            }


            return ListVoyage;
        }

        public DataTable GetTeminalDeletetValues(myVoyage Data)
        {

            string _Query = "Delete from NVO_VoyTerminalDtls where TID=" + Data.TID;


            return GetViewData(_Query, "");

        }
        public List<myVoyage> GetVoyageNoteDelete(myVoyage Data)
        {
            DataTable dt = GetVoyageNoteDeleteValues(Data);

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                ListVoyage.Add(new myVoyage
                {

                    NID = Int32.Parse(dt.Rows[i]["NID"].ToString()),
                    NotesType = Int32.Parse(dt.Rows[i]["NotesType"].ToString()),
                    Notes = dt.Rows[i]["Notes"].ToString(),
                });
            }


            return ListVoyage;
        }

        public DataTable GetVoyageNoteDeleteValues(myVoyage Data)
        {

            string _Query = "Delete from NVO_VoyNotesDtls where NID=" + Data.NID;


            return GetViewData(_Query, "");

        }






        #endregion
        public DataTable GetViewData(string Query, string CmdType)
        {
            DbConnection con = null;
            DataTable DT = null;
            try
            {
                if (Query != "")
                {
                    con = _dbFactory.GetConnection();
                    con.Open();

                    DbCommand cmd = _dbFactory.GetCommand();
                    cmd.Connection = con;

                    if (CmdType == "SP")
                        cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = Query;
                    DbDataAdapter adapter = _dbFactory.GetAdapter();
                    adapter.SelectCommand = cmd;
                    DT = new DataTable();
                    adapter.Fill(DT);
                }
                return DT;

            }


            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null && con.State != ConnectionState.Closed)
                    con.Close();

            }
        }

        public string Getvalue(string Query)
        {
            DbConnection con = null;
            try
            {
                string Result = "";
                if (Query != "")
                {
                    con = _dbFactory.GetConnection();
                    con.Open();
                    DbCommand cmd = _dbFactory.GetCommand();
                    cmd.Connection = con;
                    cmd.CommandText = Query;
                    object objresult = cmd.ExecuteScalar();
                    if (objresult != null)
                        Result = objresult.ToString();

                }
                return Result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con != null && con.State != ConnectionState.Closed)
                    con.Close();

            }
        }
    }

}



