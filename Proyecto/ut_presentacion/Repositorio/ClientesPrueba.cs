﻿using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorio
{
    public class ClientesPrueba
    {
        private readonly IConexion? iConexion;
        private List<Clientes>? lista;
        private Clientes? entidad;
        public ClientesPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
        }
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
        }
        
        public bool Listar()
        {
            this.lista = this.iConexion!.Clientes!.ToList();
            return lista.Count > 0;
        }
        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Clientes()!;
            this.iConexion!.Clientes!.Add(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
        public bool Modificar()
        {
            this.entidad!.Nombre = "Nombre Modificar";
            this.entidad!.Cedula = "Cedula Modificar";
            this.entidad!.Telefono = "Telefono Modificar";
            this.entidad!.Direccion = "Direccion Modificar";
            var entry = this.iConexion!.Entry<Clientes>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }
        public bool Borrar()
        {
            this.iConexion!.Clientes!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
