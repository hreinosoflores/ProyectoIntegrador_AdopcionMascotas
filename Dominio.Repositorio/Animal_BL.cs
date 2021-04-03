using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Infraestructura.Data.SqlServer;

namespace Dominio.Repositorio
{
    public class Animal_BL
    {
        Animal_DAL a_dal = new Animal_DAL();

        public string registrar(Animal a)
        {

            return a_dal.registrar(a);
        }

        public string editar(Animal a)
        {
            return a_dal.editar(a);
        }

        public List<Animal> listaAnimales()
        {
            return a_dal.listaAnimales();
        }

        public List<Animal_Tuneado> lista(long? dueño, long? tipo, long? raza) {

            return a_dal.lista(dueño,tipo,raza);
        }


        public List<Animal_Tuneado> mis_mascotas_anadidas(long dueño)
        {
            return a_dal.mis_mascotas_anadidas(dueño);
        }

        public List<Animal_Tuneado> mis_mascotas_favoritas(long interesado)
        {
            return a_dal.mis_mascotas_favoritas(interesado);
        }

        public Animal_Tuneado detalle(long cod)
        {
            return a_dal.detalle(cod);
        }

        public long cod_autogenerado()
        {
            return a_dal.cod_autogenerado();
        }
    }
}
