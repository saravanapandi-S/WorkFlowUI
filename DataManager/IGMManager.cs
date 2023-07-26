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

namespace DataManager
{
    public class IGMManager
    {
        #region Constructor Method
        public IGMManager()
        {
            _dbFactory = new SQLFactory();

        }
        #endregion
        #region Membervariable
        private IDataBaseFactory _dbFactory = null;
        #endregion


        public List<MyIGM> ManifestPortMaster(MyIGM Data)
        {
            List<MyIGM> ViewList = new List<MyIGM>();
            DataTable dt = BindManifestPortMaster(Data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ViewList.Add(new MyIGM
                {
                    ID = dt.Rows[i]["ID"].ToString(),
                    PortName = dt.Rows[i]["PortName"].ToString()
                });
            }
            return ViewList;
        }

        public DataTable BindManifestPortMaster(MyIGM Data)
        {
            string _Query = "select ID, PortCode + '-' + PortName as PortName from NVO_PortMaster where CountryID=" + Data.CountryID;
            return GetViewData(_Query, "");
        }

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

    }
}
