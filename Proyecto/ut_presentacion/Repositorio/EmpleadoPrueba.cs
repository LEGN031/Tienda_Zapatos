﻿using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorio
{
    [TestClass]
    public class EmpleadoPrueba
    {
        private readonly IConexion? iConexion;
        private List<Empleados>? lista;
        private Empleados? entidad;

        public EmpleadoPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
        }
        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
            
        }

        public bool Listar()
        {
            this.lista = this.iConexion!.Empleados!.ToList();
            return lista.Count > 0;
        }
        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Empleados()!;
            this.iConexion!.Empleados!.Add(this.entidad);
            this.iConexion.SaveChanges();
            return true;
        }
        public bool Modificar()
        {
            this.entidad!.Nombre = "Nombre Modificar";
            this.entidad!.Cedula = "Cedula Modificar";
            this.entidad!.Telefono = "Telefono Modificar";
            this.entidad!.Salario = 200.0m;
            var entry = this.iConexion!.Entry<Empleados>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion.SaveChanges();
            return true;
        }
        public bool Borrar()
        {
            this.iConexion!.Empleados!.Remove(this.entidad!);
            this.iConexion.SaveChanges();
            return true;
        }
    }
}
