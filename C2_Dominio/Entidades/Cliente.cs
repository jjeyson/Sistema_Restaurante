using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2_Dominio.Entidades
{
    public class Cliente
    {
        // Atributos persistentes
        public String dni { set; get; }
        public String razonSocial { set; get; }
        public String nombre { set; get; }
        public String ruc { set; get; }
        public String correoElectronico { set; get; }
        public Boolean esEmpresa { set; get; }
        public String direccion { set; get; }
        public DateTime fechaNacimiento { set; get; }
        public DateTime fechaRegistro { set; get; }
        public Boolean habilitado { set; get; }

        // Atributos auxiliares
        public int numeroError { set; get; }
        #region metodos
        public Boolean correoElectronicoNoSuperaCapacidad(String correo)
        {
            if (correo.Length > 20) return false; return true;
        }
        public Boolean direccionNoSuperaCapacidad(String direcc)
        {
            if (direcc.Length > 50) return false; return true;
        }
        public Boolean dniEsOchoDigitos(String ndoc)
        {
            if (ndoc.Length == 8) return true; else return false;
        }
        public Boolean dniEsTodoNumerico(String ndoc)
        {
            Boolean validacion = true;
            foreach (char d in ndoc)
            {
                if (d < 0x30 || d > 0x39) { validacion = false; break; }
            }
            return validacion;
        }
        public Boolean dniVacio(String ndoc)
        {
            if (ndoc.Trim().Length == 0) return true; else return false;
        }
        public Boolean fechaNacMenorFechaReg(DateTime fecha)
        {
            if (fecha < DateTime.Today) return true; return false;
        }
        public Boolean nombreNoSuperaCapacidad(String nomb)
        {
            if (nomb.Length > 50) return false; return true;
        }
        public Boolean nombreVacio(String nomb)
        {
            if (nomb.Trim().Length == 0) return true; else return false;
        }
        public Boolean razonsocialEsVacio(String razsocial)
        {
            if (razsocial.Trim().Length == 0) return true; else return false;
        }
        public Boolean razonSocialNoSuperaCapacidad(String razsocial)
        {
            if (razsocial.Length > 50) return false; return true;
        }
        public Boolean rucEsOnceDigitos(String r)
        {
            if (r.Length == 11) return true; else return false;
        }
        public Boolean rucEsTodoNumerico(String nruc)
        {
            Boolean validacion = true;
            foreach (char d in nruc)
            {
                if (d < 0x30 || d > 0x39) { validacion = false; break; }
            }
            return validacion;
        }
        public Boolean rucEsVacio(String r)
        {
            if (r.Trim().Length == 0) return true; return false;
        }
        public Boolean verificarHoyCumpleaños()
        {
            DateTime fechaHoy = DateTime.Today;
            if (fechaHoy.Month == this.fechaNacimiento.Month && fechaHoy.Day == this.fechaNacimiento.Day)
                return true;
            else
                return false;
        }
        #endregion
    }
}
