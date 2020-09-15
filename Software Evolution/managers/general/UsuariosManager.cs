using Software_Evolution.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Software_Evolution.models;
using Npgsql;
using System.Data;
using System.Windows.Forms;

namespace Software_Evolution.managers.general
{
    public class UsuariosManager
    {
        private readonly QueryManager queryManager = QueryManager.Instance;

        public Usuario AuthUser(String username,String password)
        {
            var clave = (username == "postgres") ? password : ToMD5(password);
            try
            {
                var conexion = ConexionManager.Instance.GetConnection(username, clave);
                conexion.Open();
                NpgsqlDataAdapter da = new NpgsqlDataAdapter($"select * from t_usuario where  f_id_usuario='{username}' and f_activo=true", conexion);
                NpgsqlCommandBuilder comando = new NpgsqlCommandBuilder(da);
                var tabla = new DataTable();
                da.Fill(tabla);
                da.Dispose();
                comando.Dispose();
                conexion.Close();
                if (tabla.Rows.Count == 0)
                {
                    throw new Exception("La cuenta de su usuario esta desactivado");
                }
                var res = tabla.Rows[0];                
                var usuario =new Usuario(res.Field<int>("f_codigo_usuario"), res.Field<String>("f_id_usuario"), clave,
                    res.Field<String>("f_apellido"), res.Field<String>("f_nombre"), res.Field<String>("f_direccion"), res.Field<int>("f_id_grupo"), res.Field<Boolean>("f_permisos_libre"),
                    res.Field<String>("f_telefono"), res.Field<String>("f_email"));
                return usuario;
            }
            catch(Exception ex)
            {
                if(ex is NpgsqlException)
                {
                    throw new Exception("Usuario o contraseña incorrectos");
                }
                else
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public String ToMD5(String text)
        {
            var md5 = MD5.Create();
            var bytes = System.Text.Encoding.ASCII.GetBytes(text);
            var hasbytes = md5.ComputeHash(bytes);
            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hasbytes.Length; i++)
            {
                sb.Append(hasbytes[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public DataTable getAllUsuarios()
        {
            queryManager.Open();
            var res = queryManager.Query("select * from t_usuario where f_activo=true order by f_codigo_usuario");
            queryManager.Close();
            return res;
        }

        public DataTable getUsuarioTipoArticulos(int usuarioid)
        {
            queryManager.Open();
            var res = queryManager.Query($"select e.f_id,e.f_descripcion from t_tipos_articulos_por_usuario t,t_tipo_articulos e where t.f_id_tipo_articulo=e.f_id and t.f_id_usuario={usuarioid}");
            queryManager.Close();
            return res;
        }

        public DataRow getUsuarioById(int usuarioid)
        {
            queryManager.Open();
            var res = queryManager.Query($"select * from t_usuario where f_codigo_usuario={usuarioid}");
            if (res.Rows.Count > 0)
            {
                return res.Rows[0];
            }
            return null;
        }

        public void AsignarPermisosTablasSelect(String username,int tipo)
        {
            try 
            {
                queryManager.BeginWork();
                //*---------------permisos a los esquemas--------------*//
                var result = queryManager.Query("SELECT distinct schemaname FROM pg_stat_all_tables WHERE  schemaname<>'public' and relname LIKE 't_%' ");
                foreach (DataRow r in result.Rows)
                {
                    queryManager.Execute($"GRANT USAGE ON SCHEMA {r.Field<String>("schemaname")} to \"{username}\"");
                }
                //*------------------------end--------------------------*//

                //*--------permisos a las tablas---------------*//
                var sql = (tipo == 1) ?
                    " SELECT schemaname,relname FROM pg_stat_all_tables WHERE relname LIKE 't_%' ORDER BY schemaname" :
                    " SELECT n.nspname as schemaname,c.relname FROM pg_catalog.pg_class c " +
                    " LEFT JOIN pg_catalog.pg_user u ON u.usesysid = c.relowner LEFT JOIN pg_catalog.pg_namespace n ON n.oid = c.relnamespace " +
                    " WHERE c.relkind IN ('v') AND n.nspname NOT IN ('pg_catalog', 'pg_toast')   AND pg_catalog.pg_table_is_visible(c.oid) ORDER BY 1,2";
                var rtablas = queryManager.Query(sql);
                String tabla = "";
                foreach(DataRow r in rtablas.Rows){
                    tabla += $",{r.Field<String>("schemaname")}.{r.Field<String>("relname")}";
                }
                queryManager.Execute($" grant  select on {tabla.Substring(1)} to \"{username}\"");
                queryManager.CommitWork();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AsignarPermisosTablas(String username, int tipo)
        {
            try
            {
                queryManager.BeginWork();
                //*---------------permisos a los esquemas--------------*//
                var result = queryManager.Query("SELECT distinct schemaname FROM pg_stat_all_tables WHERE  schemaname<>'public' and relname LIKE 't_%' ");
                foreach (DataRow r in result.Rows)
                {
                    queryManager.Execute($"GRANT USAGE ON SCHEMA {r.Field<String>("schemaname")} to \"{username}\"");
                }
                //*------------------------end--------------------------*//

                //*--------permisos a las tablas---------------*//
                var sql = (tipo == 1) ?
                    " SELECT schemaname,relname FROM pg_stat_all_tables WHERE relname LIKE 't_%' ORDER BY schemaname" :
                    " SELECT n.nspname as schemaname,c.relname FROM pg_catalog.pg_class c " +
                    " LEFT JOIN pg_catalog.pg_user u ON u.usesysid = c.relowner LEFT JOIN pg_catalog.pg_namespace n ON n.oid = c.relnamespace " +
                    " WHERE c.relkind IN ('v') AND n.nspname NOT IN ('pg_catalog', 'pg_toast')   AND pg_catalog.pg_table_is_visible(c.oid) ORDER BY 1,2";
                var rtablas = queryManager.Query(sql);
                String tabla = "";
                foreach (DataRow r in rtablas.Rows)
                {
                    tabla += $",{r.Field<String>("schemaname")}.{r.Field<String>("relname")}";
                }
                queryManager.Execute($" grant  select, insert ,update, delete on {tabla.Substring(1)} to \"{username}\"");
                queryManager.CommitWork();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UsuarioExiste(string username)
        {
            var res = queryManager.Query($"select f_id_usuario from t_usuario where  f_id_usuario='{username}'");
            return res.Rows.Count > 0;
        }


        public void CreateUsuario(bool nuevo,Dictionary<String,object> datos,DataTable tiposarticulos,bool creausuarios,string clave)
        {
            queryManager.BeginWork();
            try
            {
                if (nuevo)
                {
                    var secuencia = queryManager.GetSecuencia(queryManager.GetTipoDoc(52));
                    datos["f_codigo_usuario"] = secuencia;
                    queryManager.CreateRecord("t_usuario", datos);
                    var createrol = (creausuarios) ? " createrole " : "";
                    var sql = $" create ROLE \"{datos["f_id_usuario"].ToString()}\" with LOGIN PASSWORD '{clave}' {createrol}";
                    queryManager.Execute(sql);
                }
                else
                {
                    queryManager.UpdateRecord("t_usuario", datos, $" where f_codigo_usuario={datos["f_codigo_usuario"].ToString()}");
                    if (clave != "")
                    {
                        var createrol = (creausuarios) ? " createrole " : "";
                        var sql = $" alter ROLE \"{datos["f_id_usuario"].ToString()}\" with LOGIN PASSWORD '{clave}' {createrol}";
                        queryManager.Execute(sql);
                    }
                }
                queryManager.Execute($"delete from t_tipos_articulos_por_usuario where f_id_usuario={datos["f_codigo_usuario"].ToString()}");
                foreach (DataRow r in tiposarticulos.Rows)
                {
                    queryManager.Execute($"insert into t_tipos_articulos_por_usuario (f_id_usuario,f_id_tipo_articulo) values ({datos["f_codigo_usuario"].ToString()},{r.Field<int>("f_id")})");
                }
            }catch(Exception ex)
            {
                queryManager.RollBack();
                throw ex;
            }
            queryManager.CommitWork();
            AsignarPermisosTablas(datos["f_id_usuario"].ToString(), 1);
            AsignarPermisosTablas(datos["f_id_usuario"].ToString(), 2);
        }

        public string UpdateUserPassword(string username,string clave)
        {
            try
            {
                var md5pass = ToMD5(clave);
                queryManager.Execute($"alter user \"{username}\" with PASSWORD '{md5pass}'");
                queryManager.Execute($"update t_usuario set f_password='{md5pass}' where f_id_usuario='{username}'");
                return md5pass;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void permisos_de_usuarios2(MenuStrip menu,int usuarioid, int opcion,string tabla)
        {
            int id;
            try
            {
                queryManager.Open();
                var sql = $"select *,cast(f_columna as varchar)||'-'||cast(f_fila as varchar)||'-'||cast(f_submenu as varchar) as c from {tabla} where f_usuario={usuarioid}";
                var permisos = queryManager.Query(sql);
                queryManager.Execute("delete from t_permisos_usuario_temp");
                List<Dictionary<string, object>> permisos_temp = new List<Dictionary<string, object>>();
                id = 0;
              
              
                for(int columna=0;columna< menu.Items.Count;columna++)
                {
                    id++;
                    var modulo = menu.Items[columna] as ToolStripMenuItem;
                    var marcadocol = permisos.Select($"c='{columna}-{0}-0'").Length > 0;
                    var rcol =new Dictionary<string, object>();
                    rcol["f_id"] = id;
                    rcol["f_fila"] = 0;
                    rcol["f_columna"] = columna;
                    rcol["f_caption"] = modulo.Text.Replace("&","");
                    rcol["f_caption_columna"]= modulo.Text.Replace("&", "");   
                    rcol["f_marcado"] = marcadocol;
                    permisos_temp.Add(rcol);

                    for(int fila=0;fila<modulo.DropDownItems.Count;fila++)
                    {
                        id++;
                        var marcadofil = permisos.Select($"c='{columna}-{fila + 1}-{0}'").Length > 0;
                        var rfil = new Dictionary<string, object>
                        {
                            ["f_id"] = id,
                            ["f_fila"] = fila + 1,
                            ["f_columna"] = columna,
                            ["f_caption"] = modulo.DropDownItems[fila].Text.Replace("&", ""),
                            ["f_caption_columna"] = modulo.Text.Replace("&", ""),
                            ["f_marcado"] = marcadofil
                        };
                        permisos_temp.Add(rfil);
                        if (modulo.DropDownItems[fila] is ToolStripMenuItem menuopt)
                        {
                            for (int submenu=0;submenu<menuopt.DropDownItems.Count; submenu++)
                            {
                                if (menuopt.DropDownItems[submenu] is ToolStripMenuItem submenuopt)
                                {
                                    id++;
                                    var marcadosub = permisos.Select($"c='{columna}-{fila + 2}-{submenu + 1}'").Length > 0;
                                    var rsub = new Dictionary<string, object>();
                                    rsub["f_id"] = id;
                                    rsub["f_fila"] = fila + 2;
                                    rsub["f_columna"] = columna;
                                    rsub["f_submenu"] = submenu + 1;
                                    rsub["f_caption"] = submenuopt.Text.Replace("&", "");
                                    rsub["f_caption_columna"] = modulo.Text.Replace("&", "");
                                    rsub["f_marcado"] = marcadosub;
                                    permisos_temp.Add(rsub);                                 
                                }                                 
                            }
                        }
                        
                      
                    }
  
                }
                foreach(Dictionary<String,object> val in permisos_temp)
                {
                    queryManager.CreateRecord("t_permisos_usuario_temp", val);
                }
                queryManager.Close();
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetPermisosTemp() {
            queryManager.Open();
            var result = queryManager.Query($"select * from t_permisos_usuario_temp order by f_columna");
            queryManager.Close();
            return result;
        }

        public void Salvar_permisos2(int usuarioid,string tabla,DataTable data)
        {
            try
            {
                queryManager.BeginWork();
                if (tabla == "t_permisos_usuario")
                {
                    queryManager.Execute($"update t_usuario set f_permisos_libre=true where f_codigo_usuario={usuarioid}");
                }
                queryManager.Execute($"delete from {tabla} where f_usuario={usuarioid}");
                foreach(DataRow row in data.Rows)
                {
                    if (row.Field<bool>("f_marcado"))
                    {
                        var insert = $"insert into {tabla} (f_usuario,f_fila,f_columna,f_submenu,f_marcado,f_id) values " +
                            $"({usuarioid},{row.Field<int>("f_fila")},{row.Field<int>("f_columna")},{row.Field<int>("f_submenu")},true,{row.Field<int>("f_id")})";
                        queryManager.Execute(insert);
                    }                    
                }
                queryManager.Execute("delete from t_permisos_usuario_temp");
                queryManager.CommitWork();

            }catch(Exception ex)
            {
                queryManager.RollBack();
                throw ex;
            }
        }

        public void IniciarMenu(MenuStrip menu, bool visible)
        {
            for (int columna = 0; columna < menu.Items.Count; columna++)
            {
                menu.Items[columna].Visible = visible;

                for (int fila = 0; fila < (menu.Items[columna] as ToolStripMenuItem).DropDownItems.Count; fila++)
                {
                    (menu.Items[columna] as ToolStripMenuItem).DropDownItems[fila].Visible = visible;
                    if ((menu.Items[columna] as ToolStripMenuItem).DropDownItems[fila] is ToolStripMenuItem subm)
                    {
                        for (int submenu = 0; submenu < subm.DropDownItems.Count; submenu++)
                        {
                            subm.DropDownItems[submenu].Visible = visible;
                        }
                    }
                }

            }
        }

        public void PermisosUsuarios(MenuStrip menu, int usuarioid)
        {

            var usuario = getUsuarioById(usuarioid);
            if(usuario is null)
            {
                throw new Exception("El usuario no es valido");
            }
            var sql = usuario.Field<bool>("f_permisos_libre") ? $"select *,cast(f_columna as varchar)||'-'||cast(f_fila as varchar)||'-'||cast(f_submenu as varchar) as c from t_permisos_usuario where f_usuario={usuarioid}" :
                                                              $"select *,cast(f_columna as varchar)||'-'||cast(f_fila as varchar)||'-'||cast(f_submenu as varchar) as c from t_permisos_grupo where f_usuario={usuario.Field<int>("f_id_grupo")}";
            var permisos = queryManager.Query(sql);

            for (int columna = 0; columna < menu.Items.Count; columna++)
            {
                var marcadocol = permisos.Select($"c='{columna}-{0}-0'").Length > 0;
                menu.Items[columna].Visible = marcadocol;

                for (int fila = 0; fila < (menu.Items[columna] as ToolStripMenuItem).DropDownItems.Count; fila++)
                {
                    var marcadofil = permisos.Select($"c='{columna}-{fila+1}-0'").Length > 0;
                    (menu.Items[columna] as ToolStripMenuItem).DropDownItems[fila].Visible = marcadofil;
                    if ((menu.Items[columna] as ToolStripMenuItem).DropDownItems[fila] is ToolStripMenuItem subm)
                    {
                        for (int submenu = 0; submenu < subm.DropDownItems.Count; submenu++)
                        {
                            var marcadosub = permisos.Select($"c='{columna}-{fila+2}-{submenu+1}'").Length > 0;
                            subm.DropDownItems[submenu].Visible = marcadosub;
                        }
                    }
                }

            }
        }

    }
}
